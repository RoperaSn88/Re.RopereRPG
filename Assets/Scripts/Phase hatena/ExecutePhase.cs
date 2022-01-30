using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (battleContext.player.hp < 0 || battleContext.enemy.hp < 0)
        {
            next = new EndPhase();
        }
        else
        {
            next = new CommandPhase();
            battleContext.windowBattleCommand.SetMoveArrowFunction();
        }

    }
}
