using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Script_commandSO : ScriptableObject
{
    public new string name;
    public int UseMP;
    public enum Targettype
    {
        Self,
        Enemy,
    }
    public Targettype Target;
    public int CoolTime;

    public virtual void Execute(ForBattleDate user,ForBattleDate target,WindowLog Log)
    {
        Debug.Log("command!?!?!?");
    }
}
