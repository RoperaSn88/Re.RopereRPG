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
        battleContext.windowLog.ShowLog($"{battleContext.enemy.name}�������ꂽ!!");

        yield return new WaitForSeconds(3.0f);

        battleContext.windowFirstCommand.Open();
        next = new FirstSelectPhase();

    }
}
