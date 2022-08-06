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
    public class StateFactory
    {
        private static Dictionary<ELocomotionType , ILocomotionState> 
            s_LocomotionStates = new Dictionary<ELocomotionType, ILocomotionState>();

        public static ILocomotionState GetState(ELocomotionType type)
        {
            ILocomotionState p =null;
            if(s_LocomotionStates.ContainsKey(type))
            {
                return s_LocomotionStates[type];
            }
            else
            {
                switch(type)
                {
                    case ELocomotionType.Idle:
                    p = new IdleLocomotionState();
                    s_LocomotionStates.Add(type,p);
                    break;

                    case ELocomotionType.Walk:
                    p = new WalkLocomotionState();
                    s_LocomotionStates.Add(type,p);
                    break;

                    case ELocomotionType.Jump:
                    p = new JumpLocomotionState();
                    s_LocomotionStates.Add(type,p);
                    break;
                    
                }
            }
            return p;
        }
    }
}