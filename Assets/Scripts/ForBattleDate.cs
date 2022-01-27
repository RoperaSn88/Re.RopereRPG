using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBattleDate : MonoBehaviour
{
    public string name;
    public enum Which
    {
        player,
        enemy,
    }
    public Which Who;
    public int hp;
    public int mp;
    public int AttackPoint;
}
