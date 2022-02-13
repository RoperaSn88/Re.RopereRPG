using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Script_HealcommandSO : Script_commandSO
{
    [SerializeField] new int HealPoint;

    //commandSOのExecute上書き
    public override void Execute(ForBattleDate user, ForBattleDate target,WindowLog Log)
    {
        target.hp += HealPoint;
        user.CountTimer = CoolTime;
        Log.ShowLog($"{user.name}のHPが{HealPoint}回復した");
        user.SetHP();
    }
}
