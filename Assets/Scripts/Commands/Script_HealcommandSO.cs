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
        if (target.hp >= target.hpmax)
        {
            target.hp = target.hpmax;
        }
        user.CountTimer = CoolTime;
        Log.ShowLog($"{user.name}のHPが{HealPoint}回復した");
        user.SetHP();
        user.PlayerHPText.text = $"{user.hp}/{user.hpmax}";
    }
}
