/*
* @创建日期: 2022/08 11:20:24
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: Player
*/
using System;
using UnityEngine;
using System.Collections.Generic;

namespace Partice
{
    public abstract class Player
    {
        public abstract void Mission();

        public abstract void AssignWeapon(string weapon);
    }

    public class Terrorist : Player
    {
        //内在属性，每个恐怖份子任务都一样(放炸弹)
        public const string TASK = "Put Boom";

        //外在属性，每个恐怖分子武器不一样
        private string m_Weapon;

        public override void AssignWeapon(string weapon)
        {
            m_Weapon = weapon;
        }

        public override void Mission()
        {
            Debug.Log($"Terrorist with weapon:{m_Weapon}|TASK:{TASK}");
        }
    }
    
    public class CounterTerrorist  : Player
    {
        //内在属性，每个反恐精英任务都一样(拆炸弹)
        public const string TASK = "Diffuse Boom";

        //外在属性，每个反恐精英武器不一样
        private string m_Weapon;

        public override void AssignWeapon(string weapon)
        {
            m_Weapon = weapon;
        }

        public override void Mission()
        {
            Debug.Log($"CounterTerrorist with weapon:{m_Weapon}|TASK:{TASK}");
        }
    }


    public class PlayerFactory
    {
        private static Dictionary<string , Player> s_Players = new Dictionary<string, Player>();

        public static Player GetPlayer(string type)
        {
            Player p =null;
            if(s_Players.ContainsKey(type))
            {
                return s_Players[type];
            }
            else
            {
                switch(type)
                {
                    case "Terrorist":
                    p = new Terrorist();
                    s_Players.Add("Terrorist",p);
                    break;
                    case "CounterTerrorist":
                    p = new CounterTerrorist();
                    s_Players.Add("CounterTerrorist",p);
                    break;
                }
            }
            return p;
        }
    }
}