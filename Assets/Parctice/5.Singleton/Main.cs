/*
* @创建日期: 2022/08 11:27:08
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: Main
*/
using System;
using UnityEngine;

namespace Partice
{
    public class Main:MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this);
        }
        
        void OnApplicationQuit()
        {
            SingletonCleanUp.CleanUp();
        }
    }
}