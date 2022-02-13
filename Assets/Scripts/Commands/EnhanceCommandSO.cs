using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnhanceCommandSO : Script_commandSO
{
    public override void Execute(ForBattleDate user, ForBattleDate target,WindowLog Log)
    {
        user.StartEnhance();
        user.CountTimer = CoolTime;
    }
}
