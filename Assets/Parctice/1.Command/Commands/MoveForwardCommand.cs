/*
* @创建日期: 2022/07 14:36:00
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: MoveForwardCommand
*/
using System;
using UnityEngine;

namespace Partice
{
    public class MoveForwardCommand : Commmand
    {
        private IMove m_MoveTarget;

        public MoveForwardCommand(IMove move)
        {
            m_MoveTarget = move;
        }
        public override void Execute()
        {
            m_MoveTarget.MoveForward();
        }

        public override void Undo()
        {
            m_MoveTarget.MoveBack();
        }
    }
}