using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Script_HealcommandSO : Script_commandSO
{
    [SerializeField] new int HealPoint;

    //commandSO��Execute�㏑��
    public override void Execute(ForBattleDate user, ForBattleDate target,WindowLog Log)
    {
        target.hp += HealPoint;
        user.CountTimer = CoolTime;
        Log.ShowLog($"{user.name}��HP��{HealPoint}�񕜂���");
        user.SetHP();
    }
}
