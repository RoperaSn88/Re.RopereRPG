using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        
        battleContext.player.enemys = battleContext.enemys;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        int currentID = battleContext.windowBattleCommand.currentID;  //矢印の場所
        if (currentID == 0) //攻撃
        {
            if (battleContext.CountEnemy >= 2)
            {
                yield return new WaitForSeconds(0.1f);
                battleContext.windowTargetCommand.Open();
                new SelectTargetPhase();
            }
            else
            {
                ForBattleDate InfoEnemy = battleContext.enemys[0].GetComponent<ForBattleDate>();
                battleContext.player.target = InfoEnemy;
            }
            
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
            
        }
    }
}
