/*
* @创建日期: 2022/08 20:07:16
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: Observer
*/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Partice
{
    public interface IObserver
    {
         void OnNotify();
    }

    public class Box : IObserver
    {
        private Transform m_BoxTrans;

        private float m_JumpHight;

        public Box(Transform boxTrans, float height)
        {
            m_BoxTrans = boxTrans;
            m_JumpHight = height;
        }

        public void OnNotify()
        {
            Jump(m_JumpHight);
        }

        void Jump(float jumpForce)
        {
            if(m_BoxTrans==null)
            {
                return;
            }
            if (m_BoxTrans.position.y < 0.55f)
            {
                m_BoxTrans.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            }
        }
    }

    public class Subject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Notify()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i]?.OnNotify();
            }
        }

        public void AddObserver(IObserver observer)
        {
            if(!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if(observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }

}