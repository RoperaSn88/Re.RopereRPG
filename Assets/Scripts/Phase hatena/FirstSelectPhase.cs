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
            battleContext.player2.ForBattleMusic.Stop();
            battleContext.player2.FightingMusic.Play();
            battleContext.Battle.PlayAnimation();
            next = new CommandPhase();
            yield return new WaitForSeconds(1.5f);
            battleContext.enemy.StartTimer();
            battleContext.windowFirstCommand.gameObject.SetActive(false);
            battleContext.windowBattleCommand.Open();
        }
        if (currentID == 1)
        {
            int random = Random.Range(0, 101);
            if (random >= 50 && battleContext.canRun==false)
            {
                battleContext.enemy.gameObject.SetActive(false);
                battleContext.windowLog.ShowLog("������̂ɐ�������");
                battleContext.Ran = true;
                yield return new WaitForSeconds(2);
               
                next = new EndPhase();
            }
            else
            {
                battleContext.windowLog.ShowLog("������̎��s�����႟");
                yield return new WaitForSeconds(0.1f);
                battleContext.canRun = true;
                next = new FirstSelectPhase();
            }
        }
    }

}

