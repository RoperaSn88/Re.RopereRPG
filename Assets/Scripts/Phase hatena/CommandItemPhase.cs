using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandItemPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return null;
        battleContext.windowItemCommand.CreateSelectabletext(battleContext.player.GetStringItems());
        battleContext.windowItemCommand.Open();
        battleContext.windowItemCommand.currentID = 0;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentID = battleContext.windowItemCommand.currentID;
            battleContext.player.SelectCommand = battleContext.player.inventory[currentID];
            battleContext.player.SetTarget();
            battleContext.enemy.SelectCommand = battleContext.enemy.commands[0];
            battleContext.enemy.SetTarget();
            next = new ExecutePhase();
            battleContext.windowItemCommand.gameObject.SetActive(false);
        }
        else
        {
            
        }
    }
}
