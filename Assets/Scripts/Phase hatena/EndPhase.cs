using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        battleContext.player2.CC.orthographicSize = battleContext.player2.CC.orthographicSize + 2.0f;
        battleContext.enemy.hp = battleContext.enemy.hpmax;
        battleContext.player.XP += battleContext.enemy.XP;
        battleContext.windowLog.ShowLog($"{battleContext.enemy.XP}�̌o���l������");
        battleContext.windowLog.ShowLog("�X�y�[�X�Ŏ���");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        /*
        if (battleContext.player.XP >= battleContext.player.XPForLevel)
        {
            battleContext.windowLog.ShowLog($"���x������������");
            battleContext.windowLog.ShowLog("�X�y�[�X�Ŏ���");
            battleContext.player.LevelUp();
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        */
        battleContext.windowBattleCommand.gameObject.SetActive(false);
        battleContext.windowLog.ClearLog();
        battleContext.player2.BattleCanvas.SetActive(false);
        battleContext.player2.Field_Canvas.SetActive(true);
        battleContext.player2.controlF = true;
        
    }
}
