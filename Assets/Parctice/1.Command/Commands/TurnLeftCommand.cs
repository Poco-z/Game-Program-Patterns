/*
* @创建日期: 2022/07 14:37:16
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: TurnLeftCommand
*/
using System;
using UnityEngine;

namespace Partice
{
    public class TurnLeftCommand : Commmand
    {
        private IMove m_MoveTarget;

        public TurnLeftCommand(IMove move)
        {
            m_MoveTarget = move;
        }
        public override void Execute()
        {
            m_MoveTarget.TurnLeft();
        }

        public override void Undo()
        {
            m_MoveTarget.TurnRight();
        }
    }
}