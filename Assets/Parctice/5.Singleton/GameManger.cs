/*
* @创建日期: 2022/08 10:56:24
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: GameManger
*/
using System;
using UnityEngine;

namespace Partice
{
    public class GameManger:SingletonMono<GameManger>
    {
        protected override void OnInitSingleton()
        {
            Debug.Log("初始化游戏管理器");
        }
        protected override void OnDisposeSingleton()
        {
            Debug.Log("销毁游戏游戏管理器");
        }
    }

    public class BattleLogic:SingletonCSharp<BattleLogic>
    {
        protected override void OnInitSingleton()
        {
            Debug.Log("初始化游戏罗技模块数据");
        }

        protected override void OnDisposeSingleton()
        {
            Debug.Log("销毁游戏罗技模块数据");
        }
    }
}