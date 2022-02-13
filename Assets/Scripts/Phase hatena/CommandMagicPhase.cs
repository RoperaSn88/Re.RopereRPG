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
            //�I�������R�}���h�̐ݒ�
            battleContext.player.SelectCommand = battleContext.player.commands[currentID];
            //Target�̐ݒ�
            battleContext.player.SetTarget();
            battleContext.player.SelectCommand.Execute(battleContext.player, battleContext.player.target,battleContext.windowLog);
            next = new ExecutePhase();
            battleContext.windowMagicCommand.gameObject.SetActive(false);
        }
    }
}
