/*
* @创建日期: 2022/07 14:41:55
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: TurnRightCommand
*/
using System;
using UnityEngine;

namespace Partice
{
    public class TurnRightCommand : Commmand
    {
        private IMove m_MoveTarget;

        public TurnRightCommand(IMove move)
        {
            m_MoveTarget = move;
        }
        public override void Execute()
        {
            m_MoveTarget.TurnRight();
        }

        public override void Undo()
        {
            m_MoveTarget.TurnLeft();
        }
    }
}