using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        int currentID = battleContext.windowBattleCommand.currentID;  //矢印の場所
        if (currentID == 0) //攻撃
        {
            battleContext.player.SelectCommand = battleContext.player.commands[0];
            next = new ExecutePhase();
        }
        else if (currentID == 1)
        {
            next = new CommandMagicPhase();//増やすときはこれが原型
        }
        else if (currentID == 2)
        {
            // アイテム使用
            if (battleContext.player.inventory.Count >= 1)
            {
                next = new CommandItemPhase();
            }
            else
            {

            }
            
        }
        else
        {
            
        }


        //battleContext.windowLog.ShowLog(battleContext.enemy.name + "があらわれた!");
        
    }
}
