/*
* @创建日期: 2022/08 20:17:52
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: ObserverGameController
*/
using System;
using UnityEngine;

namespace Partice
{
    public class ObserverGameController:MonoBehaviour
    {
        public Transform sphereTrans;

        public Transform box1Trans;
        public Transform box2Trans;
        public Transform box3Trans;

        private Subject m_Subject = new Subject();

        void Start()
        {
            Box b1 = new Box(box1Trans,20);
            Box b2 = new Box(box2Trans,30);
            Box b3 = new Box(box3Trans,50);

            m_Subject.AddObserver(b1);
            m_Subject.AddObserver(b2);
            m_Subject.AddObserver(b3);
        }

        void Update()
        {
            if ((sphereTrans.transform.position).magnitude < 2f)
            {
                m_Subject.Notify();
            }
        }
    }
}