/*
* @创建日期: 2022/08 10:32:02
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: C#单例
*/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Partice
{
    public class SingletonCSharp<T> where T : SingletonCSharp<T>
    {
        private static T s_Instance = null;

        public static T Instance
        {
            get
            {
                if(null == s_Instance)
                {
                    //true 表示私有的无参构造函数才能匹配
                    s_Instance = Activator.CreateInstance(typeof(T),true) as T;
                    s_Instance.OnInitSingleton();
                    SingletonCleanUp.cleanUpActions.Add(()=>
                    {
                        s_Instance?.OnDisposeSingleton();
                        s_Instance = null;
                    });
                }
                return s_Instance;
            }
        }

        protected virtual void OnInitSingleton()
        {

        }

        protected virtual void OnDisposeSingleton()
        {

        }

    }

    public static class SingletonCleanUp
    {
        public static List<Action> cleanUpActions = new List<Action>();
        
        public static void CleanUp()
        {
            foreach (var action in cleanUpActions)
            {
                action?.Invoke();
            }
            cleanUpActions.Clear();
        }
    }
}