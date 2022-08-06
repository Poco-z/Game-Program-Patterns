/*
* @创建日期: 2022/08 11:49:16
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: _Monster
*/
using System;
using UnityEngine;

namespace Partice
{
    public abstract class _Monster
    {
        public abstract _Monster Clone();

        public virtual void Talk(){}
    }

    public class Demon : _Monster
    {
        public float health;

        public float speed;
        public static int demonCounter = 0;
        public Demon(float health,float speed)
        {
            this.health = health;
            this.speed = speed;
            demonCounter++;
        }
        public override _Monster Clone()
        {
            return new Demon(health,speed);
        }

        public override void Talk()
        {
            Debug.Log($"Demon health is:{health}:speed:{speed} counts:{demonCounter}");
        }
    }

    public class Ghost : _Monster
    {
        public int health;
        public int speed;

        public static int ghostCounter = 0;
    
        public Ghost(int health, int speed)
        {
            this.health = health;
            this.speed = speed;

            ghostCounter += 1;
        }

        public override _Monster Clone()
        {
            return new Ghost(health, speed);
        }

        public override void Talk()
        {
            Debug.Log($"Ghost health is:{health}:speed:{speed},total counts:{ghostCounter}");
        }
    }

    public class Spawner
    {
        private _Monster prototype;
        public Spawner(_Monster prototype)
        {
            this.prototype = prototype;
        }

        public _Monster Spawn()
        {
            return prototype.Clone();
        }
    }
}