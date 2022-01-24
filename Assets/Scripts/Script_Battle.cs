using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Battle : MonoBehaviour
{
    //ScrptableObject‚ÅŠÇ—
    //í—Ş‚ÍŒp³?

    public int hp;
    public int hpSet;
    public int hpmax;
    public new string name;

    public Script_commandSO SelectCommand;
    public Script_Battle target;
    public Script_Battle enemy;
    
    //window‚É“n‚·Magic
    public List<Script_commandSO> commands;
    public string[] GetStringCommands()
    {
        return GetString(commands);
    }

    //window‚É“n‚·Item
    public List<string> items;
    public List<Script_commandSO> inventory = new List<Script_commandSO>();
    public string[] GetStringItems()
    {
        return GetString(inventory);
    }
    public string[] GetString(List<Script_commandSO>commands)
    {
        List<string> list = new List<string>();
        foreach(Script_commandSO command in commands)
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
        if(SelectCommand.Target == Script_commandSO.Targettype.Self)
        {
            target = this;
        }
        else if (SelectCommand.Target == Script_commandSO.Targettype.Enemy)
        {
            target = enemy;
        }
        
    }

    //ƒRƒ}ƒ“ƒh‚Ì‘ÎÛ‘I‘ğ
}
