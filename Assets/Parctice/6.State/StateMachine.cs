/*
* @创建日期: 2022/08 11:05:53
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: StateMachine
*/
using System;
using UnityEngine;

namespace Locomotion
{
    [RequireComponent(typeof(Animator))]
    public class StateMachine : MonoBehaviour, ILocomotionContext
    {
        protected Animator m_Animator;
        protected ILocomotionState m_CurrentState;

        void Start()
        {
            m_Animator = GetComponent<Animator>();
            SetState(StateFactory.GetState(ELocomotionType.Idle));
        }

        public virtual void SetState(ILocomotionState newState)
        {
            m_CurrentState?.ExitState(this);
            m_CurrentState = newState;
            m_CurrentState?.EnterState(this);
        }

        void Update()
        {
            m_CurrentState?.UpdateState(this);
        }

        private void OnGUI()
        {
            string content = m_CurrentState != null ? m_CurrentState.ToString() : "(no current state)";
            GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        }

        public void PlayAnimation(ELocomotionType locomotionType)
        {
            if(m_Animator==null)
            {
                Debug.LogError("该对象没有Animator组件!");
                return;
            }

            if(!m_Animator.enabled)
            {
                Debug.LogError("Animator组件没有启用!");
                return;
            }

            var aniName = AnimationUtil.GetAnimationName(locomotionType);
            if(string.IsNullOrEmpty(aniName))
            {
                Debug.LogError($"该物体没有{locomotionType}类型的动作名字");
                return;
            }
            
            int stateId = Animator.StringToHash(aniName);
            bool hasAction = m_Animator.HasState(0, stateId);
            if(!hasAction)
            {
                //Debug.LogError($"找不到指定的动画状态{aniName}");
                return;
            }
            m_Animator.Play(aniName, 0);
        }
    }
}