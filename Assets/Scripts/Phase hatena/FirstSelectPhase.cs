using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSelectPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        int currentID = battleContext.windowFirstCommand.currentID;
        if (currentID == 0)
        {
            next = new CommandPhase();
            battleContext.windowFirstCommand.gameObject.SetActive(false);
            battleContext.windowBattleCommand.Open();
        }
        if (currentID == 1)
        {

        }
        if (currentID == 2)
        {
            int random = Random.Range(0, 101);
            if (random >= 120 && battleContext.canRun==false)
            {
                next = new EndPhase();
            }
            else
            {
                battleContext.windowLog.ShowLog("“¦‚°‚é‚ÌŽ¸”s‚µ‚¿‚á‚Ÿ");
                yield return new WaitForSeconds(0.1f);
                battleContext.canRun = true;
                next = new FirstSelectPhase();
            }
        }
    }

}

