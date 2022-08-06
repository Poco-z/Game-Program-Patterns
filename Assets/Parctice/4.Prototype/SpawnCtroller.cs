/*
* @创建日期: 2022/08 13:41:56
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: SpawnCtroller
*/
using System;
using UnityEngine;

namespace Partice
{
    public class SpawnCtroller:MonoBehaviour
    {
        public Spawner ghostSpawner;
        public Spawner demonSpawner;

        void Start()
        {
            Ghost ghostPrototype = new Ghost(100,5);
            Demon demonPrototype = new Demon(500,3);
            ghostSpawner = new Spawner(ghostPrototype);
            demonSpawner = new Spawner(demonPrototype);
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                Ghost newGhost = ghostSpawner.Spawn() as Ghost;
                newGhost.Talk();
            }
            if(Input.GetKeyDown(KeyCode.J))
            {
                Demon newDemon = demonSpawner.Spawn() as Demon;
                newDemon.Talk();
            }

        }
    }
}