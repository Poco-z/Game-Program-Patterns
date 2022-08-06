/*
* @创建日期: 2022/08 10:59:10
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: ILocomotionContext
*/
using System;
using UnityEngine;

namespace Locomotion
{
    public enum ELocomotionType
    {
        Idle,
        Walk,
        Jump,
    }

    public interface ILocomotionContext
    {
        void SetState(ILocomotionState newState);
        T GetComponent<T>() where T : StateComponent;
    }

    public interface ILocomotionState
    {
        void EnterState(ILocomotionContext context);
        void UpdateState(ILocomotionContext context);
        void ExitState(ILocomotionContext context);
    }

    public class BaseLocomotionState : ILocomotionState
    {
        public virtual void EnterState(ILocomotionContext context) { }
        public virtual void ExitState(ILocomotionContext context) { }
        public virtual void UpdateState(ILocomotionContext context) { }
        protected ILocomotionState GetState(ELocomotionType type)
        {
            return StateFactory.GetState(type);
        }
    }
    public class IdleLocomotionState : BaseLocomotionState
    {
        public override void EnterState(ILocomotionContext context)
        {
            context.GetComponent<AnimatorComponent>().PlayAnimation(ELocomotionType.Idle);
        }
        public override void UpdateState(ILocomotionContext context)
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal"))>float.Epsilon)
            {
                var nextState = GetState(ELocomotionType.Walk);
                context.SetState(nextState);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var nextState = GetState(ELocomotionType.Jump);
                context.SetState(nextState);
            }
        }
    }

    public class WalkLocomotionState : BaseLocomotionState
    {
        public override void EnterState(ILocomotionContext context)
        {
            context.GetComponent<AnimatorComponent>().PlayAnimation(ELocomotionType.Walk);
        }
        public override void UpdateState(ILocomotionContext context)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var nextState = GetState(ELocomotionType.Jump);
                context.SetState(nextState);
            }

            if(Mathf.Abs(Input.GetAxis("Horizontal"))<float.Epsilon)
            {
                var nextState = GetState(ELocomotionType.Idle);
                context.SetState(nextState);
            }
        }
    }
    public class JumpLocomotionState : BaseLocomotionState
    {
        private float m_Jumping = 0;
        public override void EnterState(ILocomotionContext context)
        {
            m_Jumping = 0;
            context.GetComponent<AnimatorComponent>().PlayAnimation(ELocomotionType.Jump);
        }
        public override void UpdateState(ILocomotionContext context)
        {
            m_Jumping += Time.deltaTime;
            if(m_Jumping>5)
            {
                var nextState = GetState(ELocomotionType.Idle);
                context.SetState(nextState);
            }
        }
    }
}