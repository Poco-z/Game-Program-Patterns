/*
* @创建日期: 2022/07 14:18:27
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: MoveBackCommand
*/
using System;
using UnityEngine;

namespace Partice
{
    public class MoveBackCommand : Commmand
    {
        private IMove m_MoveTarget;

        public MoveBackCommand(IMove move)
        {
            m_MoveTarget = move;
        }
        public override void Execute()
        {
            m_MoveTarget.MoveBack();
        }

        public override void Undo()
        {
            m_MoveTarget.MoveForward();
        }
    }
}