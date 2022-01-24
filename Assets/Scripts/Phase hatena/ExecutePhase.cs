using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        battleContext.player.SelectCommand.Execute(battleContext.player, battleContext.player.target);
        battleContext.enemy.SelectCommand.Execute(battleContext.enemy, battleContext.enemy.target);
        battleContext.windowLog.ShowLog($"{battleContext.enemy.name}‚Í{battleContext.enemy.hpSet - battleContext.enemy.hp}ƒ_ƒ[ƒW");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (battleContext.player.hp < 0 || battleContext.enemy.hp < 0)
        {
            next = new EndPhase();
            battleContext.enemy.hpSet = battleContext.enemy.hp;
        }
        else
        {
            next = new CommandPhase();
            battleContext.windowBattleCommand.SetMoveArrowFunction();
        }

    }
}
