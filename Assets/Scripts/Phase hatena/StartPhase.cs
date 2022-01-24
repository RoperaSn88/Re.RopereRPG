using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return null;
        battleContext.SetEnemy();
        battleContext.windowBattleCommand.Open();
        battleContext.windowLog.ShowLog("test");
        next = new CommandPhase();

    }
}
