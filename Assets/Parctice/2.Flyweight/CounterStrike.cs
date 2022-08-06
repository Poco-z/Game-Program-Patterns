/*
* @创建日期: 2022/08 11:36:02
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: CounterStrike
*/
using System;
using UnityEngine;

namespace Partice
{
    public class CounterStrike : MonoBehaviour
    {
        private static String[] s_PlayerType =
                {"Terrorist", "CounterTerrorist"};
        private static String[] s_Weapons =
          {"AK-47", "Maverick", "Gut Knife", "Desert Eagle"};

        void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                Player p = PlayerFactory.GetPlayer(GetRandomPlayerType());
                p.AssignWeapon(GetRandomWeapon());

                p.Mission();
            }

            Debug.Log("------");

            PlayerFactory.GetPlayer(GetRandomPlayerType());
        }
        

        private string GetRandomPlayerType()
        {
            int radInt = UnityEngine.Random.Range(0,s_PlayerType.Length);
            return s_PlayerType[radInt];
        }
        private string GetRandomWeapon()
        {
            int radInt = UnityEngine.Random.Range(0,s_Weapons.Length);
            return s_Weapons[radInt];
        }
    }
}