/*
* @创建日期: 2022/07 14:20:52
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: Commmand
*/
using System;
using UnityEngine;

namespace Partice
{
    public abstract class Commmand
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}