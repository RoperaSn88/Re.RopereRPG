using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        int currentID = battleContext.windowBattleCommand.currentID;  //���̏ꏊ
        if (currentID == 0) //�U��
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
            if (battleContext.player.SpeedF == true)
            {
                battleContext.player.CountTimer = 1;
            }
            else
            {
                battleContext.player.CountTimer = 3;
            }
            battleContext.windowLog.ShowLog($"{battleContext.enemy.name}��{battleContext.player.RandomAttackPoint}�_���[�W");
            next = new ExecutePhase();
        }
        else if (currentID == 1)
        {
            next = new CommandMagicPhase();//���₷�Ƃ��͂��ꂪ���^
        }
        else if (currentID == 2)
        {
            // �A�C�e���g�p
            if (battleContext.player.inventory.Count >= 1)
            {
                next = new CommandItemPhase();
            }
            else
            {
                battleContext.windowLog.ShowLog("�A�C�e���������ĂȂ�");
                next = new CommandPhase();
            }
            
        }
    }
}
