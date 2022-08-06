/*
* @创建日期: 2022/07 14:20:52
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: MoveObject
*/
using System;
using UnityEngine;

namespace Partice
{
    public interface IMove
    {
        void MoveForward();

        void MoveBack();

        void TurnLeft();

        void TurnRight();
    }
    public class MoveObject : MonoBehaviour,IMove
    {
        private const float MOVE_STEP_DISTANCE = 1.0f;

        public void MoveForward()
        {
            Move(Vector3.forward);
        }

        public void MoveBack()
        {
            Move(Vector3.back);
        }

        public void TurnLeft()
        {
            Move(Vector3.left);
        }

        public void TurnRight()
        {
            Move(Vector3.right);
        }

        private void Move(Vector3 dir)
        {
            transform.position += dir * MOVE_STEP_DISTANCE;
        }
    }
}