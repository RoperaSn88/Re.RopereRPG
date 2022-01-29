using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        int currentID = battleContext.windowBattleCommand.currentID;  //���̏ꏊ
        if (currentID == 0) //�U��
        {
            
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
            
        }


        //battleContext.windowLog.ShowLog(battleContext.enemy.name + "�������ꂽ!");
        
    }
}
