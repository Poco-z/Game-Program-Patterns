/*
* @创建日期: 2022/08 10:40:19
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: Unity单例模式模板类
*/
using System;
using UnityEngine;

namespace Partice
{
    public class SingletonMono<T> :MonoBehaviour where T : SingletonMono<T>
    {
        private static T s_Instance;

        public static T Instacne
        {
            get
            {
                if(null == s_Instance)
                {
                    s_Instance = GameObject.FindObjectOfType<T>();
                    if(null == s_Instance)
                    {
                        GameObject obj = new GameObject(typeof(T).Name+"Singleton");
                        s_Instance = obj.AddComponent<T>();
                        s_Instance.OnInitSingleton();
                        DontDestroyOnLoad(obj);
                        SingletonCleanUp.cleanUpActions.Add(() =>
                        {
                            s_Instance.OnDisposeSingleton();
                            Destroy(s_Instance);
                            s_Instance = null;
                        });
                    }
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
}