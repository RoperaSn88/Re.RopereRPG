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
            //battleContext.player.SelectCommand.FightingSound.
            //Targetの設定
            battleContext.player.SetTarget();
            battleContext.player.SelectCommand.Execute(battleContext.player, battleContext.player.target,battleContext.windowLog);
            battleContext.player2.MagicSound.clip = battleContext.player.SelectCommand.FightSound;
            battleContext.player2.MagicSound.Play();
            next = new ExecutePhase();
            battleContext.windowMagicCommand.gameObject.SetActive(false);
        }
    }
}
