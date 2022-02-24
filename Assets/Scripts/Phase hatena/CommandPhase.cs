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
            /*
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
            */
            //battleContext.player.SelectCommand=battleContext.player.
            battleContext.player.RandomAttackPoint = Random.Range(battleContext.player.BaseAttackPoint - 2, battleContext.player.BaseAttackPoint + 3);
            if (battleContext.player.EnhanceF == true)
            {
                battleContext.player.RandomAttackPoint = battleContext.player.RandomAttackPoint * 2;
            }
            battleContext.enemy.hp -= battleContext.player.RandomAttackPoint;
            battleContext.player.PlayAttackAnimator();
            battleContext.player2.CuttingSound.Play();
            if (battleContext.player.SpeedF == true)
            {
                battleContext.player.CountTimer = 1;
            }
            else
            {
                battleContext.player.CountTimer = 3;
            }
            battleContext.windowLog.ShowLog($"{battleContext.enemy.name}に{battleContext.player.RandomAttackPoint}ダメージ");
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
                battleContext.windowLog.ShowLog("アイテムをもってない");
                next = new CommandPhase();
            }
            
        }
    }
}
