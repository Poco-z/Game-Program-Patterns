/*
* @创建日期: 2022/08 15:03:44
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: 享元模式,避免一直new state
*/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Locomotion
{
    public class AnimationUtil
    {
        public static Dictionary<ELocomotionType, string> 
            s_AnimationNames = new Dictionary<ELocomotionType, string>()
            {
                {ELocomotionType.Idle,"idle"},
                {ELocomotionType.Walk,"walk"},
                {ELocomotionType.Jump,"jump"},
            };

        public static string GetAnimationName(ELocomotionType type)
        {
            if(s_AnimationNames.ContainsKey(type))
            {
                return s_AnimationNames[type];
            }
            return string.Empty;
        }
    }
}