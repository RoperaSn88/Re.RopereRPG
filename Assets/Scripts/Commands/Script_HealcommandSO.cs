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
        if (target.hp >= target.hpmax)
        {
            target.hp = target.hpmax;
        }
        user.CountTimer = CoolTime;
        Log.ShowLog($"{user.name}��HP��{HealPoint}�񕜂���");
        user.SetHP();
        user.PlayerHPText.text = $"{user.hp}/{user.hpmax}";
    }
}
