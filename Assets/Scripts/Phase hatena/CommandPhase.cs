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
            next = new CommandMagicPhase();//���₷�Ƃ��͂��ꂪ���^
        }
        else if (currentID == 2)
        {
            // �A�C�e���g�p
            if (battleContext.player.inventory.Count >= 1)
            {
                next = new CommandItemPhase();
            }
            
        }


        //battleContext.windowLog.ShowLog(battleContext.enemy.name + "�������ꂽ!");
        
    }
}
