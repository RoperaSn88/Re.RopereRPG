using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SpeedCommandSO : Script_commandSO
{
    public override void Execute(ForBattleDate user, ForBattleDate target, WindowLog Log)
    {
        user.StartSpeed();
        user.CountTimer = CoolTime;
    }
}
