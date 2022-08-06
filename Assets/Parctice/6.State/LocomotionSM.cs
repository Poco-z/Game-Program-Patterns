/*
* @创建日期: 2022/08 11:05:53
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: StateMachine
*/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Locomotion
{
    [RequireComponent(typeof(Animator))]
    public class LocomotionSM : MonoBehaviour, ILocomotionContext
    {
        protected ILocomotionState m_CurrentState;
        protected List<StateComponent> m_StateComponents = new List<StateComponent>();

        #region  unity func
        void Awake()
        {
            InitCommands();
        }
        void Start()
        {  
            SetState(StateFactory.GetState(ELocomotionType.Idle));
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

        void OnDestroy()
        {
            m_CurrentState = null;
            foreach (var command in m_StateComponents)
            {
                command?.CleanUp();
            }
            m_StateComponents.Clear();     
        }
        #endregion

        #region  logic func
        public virtual void InitCommands()
        {
            m_StateComponents.Add(new AnimatorComponent(base.GetComponent<Animator>()));
        }

        public virtual void SetState(ILocomotionState newState)
        {
            m_CurrentState?.ExitState(this);
            m_CurrentState = newState;
            m_CurrentState?.EnterState(this);
        }

        public T GetComponent<T>() where T : StateComponent
        {
            foreach (var command in m_StateComponents)
            {
                if (command is T)
                {
                    return command as T;
                }
            }
            return null;
        }
        #endregion

    }
}