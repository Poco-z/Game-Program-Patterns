/*
* @创建日期: 2022/08 11:05:53
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: MovementSM 动画状态机
*/
using System;
using UnityEngine;

namespace Locomotion
{
    [RequireComponent(typeof(Animator))]
    public class MovementSM : MonoBehaviour
    {
        protected Animator m_Animator;

        void Start()
        {
            m_Animator = GetComponent<Animator>();
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
                Debug.LogError($"找不到指定的动画状态{locomotionType}");
                return;
            }

            m_Animator.Play(aniName, 0);
        }
    }
}