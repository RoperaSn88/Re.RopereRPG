using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        if (battleContext.CountEnemy == 1)
        {
            battleContext.windowLog.ShowLog("���ꂩ�������ꂽ!!");
        }
        battleContext.windowBattleCommand.Open();
        
        yield return new WaitForSeconds(2.5f);
        
        
        next = new CommandPhase();

    }
}
