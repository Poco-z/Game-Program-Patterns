/*
* @创建日期: 2022/08 10:57:45
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: SingletonTest
*/
using System;
using UnityEngine;

namespace Partice
{
    public class SingletonTest:MonoBehaviour
    {
        void Start()
        {
            var manger = GameManger.Instacne;
            var logic = BattleLogic.Instance;
        }
    }
}