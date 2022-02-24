using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        /*
        if (battleContext.CountEnemy == 1)
        {
            foreach(GameObject enemy in battleContext.enemys)
            {
                ForBattleDate name = enemy.GetComponent<ForBattleDate>();
                battleContext.windowLog.ShowLog($"{name.name}�������ꂽ!!");
                Debug.Log("aaaaaa");
            }
        }
        else
        {
            battleContext.windowLog.ShowLog($"�G�̌Q�ꂪ�����ꂽ!!");
        } */
        battleContext.enemy = battleContext.enemyObject.GetComponent<ForBattleDate>();
        battleContext.enemy.target = battleContext.player;
        battleContext.enemy.CountTimer = battleContext.enemy.BaseCountTimer;
        battleContext.enemy.Count.text = $"{battleContext.enemy.CountTimer}";
        battleContext.enemy.Gage.fillAmount = 1;
        battleContext.enemy.SetHP();

        battleContext.windowLog.ClearLog();
        battleContext.windowLog.LineCount = 0;

        battleContext.player.SetHP();
        battleContext.player.PlayerHPText.text = $"{battleContext.player.hp}/{battleContext.player.hpmax}";
        battleContext.windowLog.ShowLog($"{battleContext.enemy.name}�������ꂽ!!");

        yield return new WaitForSeconds(3.0f);

        battleContext.windowFirstCommand.Open();
        next = new FirstSelectPhase();

    }
}
