using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        if (battleContext.CountEnemy == 1)
        {
            foreach(GameObject enemy in battleContext.enemys)
            {
                ForBattleDate name = enemy.GetComponent<ForBattleDate>();
                battleContext.windowLog.ShowLog($"{name.name}‚ª‚ ‚ç‚í‚ê‚½!!");
                Debug.Log("aaaaaa");
            }
        }
        else
        {
            battleContext.windowLog.ShowLog($"“G‚ÌŒQ‚ê‚ª‚ ‚ç‚í‚ê‚½!!");
        }

        yield return new WaitForSeconds(2.5f);

        battleContext.windowFirstCommand.Open();
        next = new FirstSelectPhase();

    }
}
