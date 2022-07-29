using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameInfo.Monster
{
    public class MonsterInfo : MonoBehaviour
    {
        // 이름
        public string name = string.Empty;
        // HP
        public int HP = 0;
        // 공격범위
        public int a_range = 0;
        // 사거리
        public int distance = 0;
        // 공격력
        public int power = 0;
        // 공격속도
        public float a_speed = 0.0f;
        // 이동속도
        public float m_speed = 0.0f;

        public string GetName()
        {
            return name;
        }
        public int GetHp()
        {
            return HP;
        }
        public int GetRange()
        {
            return a_range;
        }
        public int GetDistance()
        {
            return distance;
        }
        public int GetPower()
        {
            return power;
        }
        public float GetAspeed()
        {
            return a_speed;
        }
        public float GetMspeed()
        {
            return m_speed;
        }

        public void SetName(string param_name)
        {
            name = param_name;
        }
        public void SetHp(int param_Hp)
        {
            HP = param_Hp;
        }
        public void SetRange(int param_range)
        {
            a_range = param_range;
        }
        public void SetDistance(int param_distance)
        {
            distance = param_distance;
        }
        public void SetPower(int param_power)
        {
            power = param_power;
        }
        public void SetAspeed(float param_aspeed)
        {
            a_speed = param_aspeed;
        }
        public void SetMspeed(float param_mspeed)
        {
            m_speed = param_mspeed;
        }
    }
}


