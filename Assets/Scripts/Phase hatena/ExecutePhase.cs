using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (battleContext.enemy.hp <= 0)
        {
            battleContext.enemy.gameObject.SetActive(false);
            battleContext.enemy.StopTimer();
            battleContext.windowLog.ShowLog($"{battleContext.enemy.name}��|����");
            yield return new WaitForSeconds(2);
            next = new EndPhase();
        }
        else
        {
            battleContext.enemy.HPbar.value = battleContext.enemy.hp;
            battleContext.player.Gage.fillAmount = 1;
            battleContext.player.Count.text = $"{battleContext.player.CountTimer}";
            battleContext.player.playerF = true;
            yield return new WaitUntil(() => battleContext.player.CountTimer == 0);
            next = new CommandPhase();
            battleContext.windowBattleCommand.SetMoveArrowFunction();
        }

    }
}
