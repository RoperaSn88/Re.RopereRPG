using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTargetPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return null;
        battleContext.windowTargetCommand.CreateSelectabletextForEnemy(battleContext.enemys);
        battleContext.windowTargetCommand.Open();
        battleContext.windowTargetCommand.currentID = 0;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentID = battleContext.windowTargetCommand.currentID;
            //選択したコマンドの設定
            ForBattleDate SelectEnemy = battleContext.enemys[currentID].GetComponent<ForBattleDate>();
            battleContext.player.target = SelectEnemy;
            battleContext.windowTargetCommand.gameObject.SetActive(false);

            next = new ExecutePhase();
        }
    }
}
