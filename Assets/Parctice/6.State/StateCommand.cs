/*
* @创建日期: 2022/08 17:12:33
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: StateCommand
*/
using System;
using UnityEngine;

namespace Locomotion
{
    public abstract class StateComponent
    {
        public abstract void CleanUp();
    }

    public class AnimatorComponent : StateComponent
    {
        protected Animator m_Animator;
        public AnimatorComponent(Animator animator)
        {
            m_Animator = animator;
        }

        public override void CleanUp(){}

        public void PlayAnimation(ELocomotionType locomotionType)
        {
            if (m_Animator == null)
            {
                Debug.LogError("该对象没有Animator组件!");
                return;
            }

            if (!m_Animator.enabled)
            {
                Debug.LogError("Animator组件没有启用!");
                return;
            }

            var aniName = AnimationUtil.GetAnimationName(locomotionType);
            if (string.IsNullOrEmpty(aniName))
            {
                Debug.LogError($"该物体没有{locomotionType}类型的动作名字");
                return;
            }

            int stateId = Animator.StringToHash(aniName);
            bool hasAction = m_Animator.HasState(0, stateId);
            if (!hasAction)
            {
                //Debug.LogError($"找不到指定的动画状态{aniName}");
                return;
            }
            m_Animator.Play(aniName, 0);
        }
    }
}