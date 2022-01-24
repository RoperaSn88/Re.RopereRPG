using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMagicPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return null;
        battleContext.windowMagicCommand.CreateSelectabletext(battleContext.player.GetStringCommands());
        battleContext.windowMagicCommand.Open();
        battleContext.windowMagicCommand.currentID = 0;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentID = battleContext.windowMagicCommand.currentID;
            //選択したコマンドの設定
            battleContext.player.SelectCommand = battleContext.player.commands[currentID];
            //Targetの設定
            battleContext.player.SetTarget();
            battleContext.enemy.SelectCommand = battleContext.enemy.commands[0];
            battleContext.enemy.SetTarget();
            next = new ExecutePhase();
            battleContext.windowMagicCommand.gameObject.SetActive(false);
        }
    }
}
