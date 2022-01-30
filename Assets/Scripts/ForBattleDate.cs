using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBattleDate : MonoBehaviour
{
    public string name;
    public enum Which
    {
        enemy,
        player,
    }
    public Which Who;
    public int hp;
    public int hpmax;
    public int mp;
    public int AttackPoint;

    public Script_commandSO SelectCommand;
    public ForBattleDate target;
    public ForBattleDate enemy;

    public List<Script_commandSO> commands;
    public string[] GetStringCommands()
    {
        return GetString(commands);
    }

    public List<string> items;
    public List<Script_commandSO> inventory = new List<Script_commandSO>();
    public string[] GetStringItems()
    {
        return GetString(inventory);
    }

    public string[] GetString(List<Script_commandSO> commands)
    {
        List<string> list = new List<string>();
        foreach (Script_commandSO command in commands)
        {
            list.Add(command.name);
        }
        return list.ToArray();
    }

    public void UseItem(Script_commandSO item)
    {
        inventory.Remove(item);
    }

    public void SetTarget()
    {
        if (SelectCommand.Target == Script_commandSO.Targettype.Self)
        {
            target = this;
        }
        else if (SelectCommand.Target == Script_commandSO.Targettype.Enemy)
        {
            target = enemy;
        }
    }
}
