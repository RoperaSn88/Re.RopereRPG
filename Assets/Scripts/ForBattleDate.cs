using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBattleDate : ScriptableObject
{
    public string name;
    public Sprite Sprite;
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
