using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        if (battleContext.Ran == false)
        {
            if (battleContext.enemy.boss == true)
            {
                battleContext.windowLog.ShowLog("ゲームクリア！");
                battleContext.player2.OTOKO.Play();
                battleContext.player2.OTOKO.loop = true;
                battleContext.Fade = true;
                yield return new WaitForSeconds(4);
                SceneManager.LoadScene("Title");
            }
            else
            {
                battleContext.player2.CC.orthographicSize = battleContext.player2.CC.orthographicSize + 2.0f;
                battleContext.enemy.hp = battleContext.enemy.hpmax;
                battleContext.player.XP += battleContext.enemy.XP;
                battleContext.windowLog.ShowLog($"{battleContext.enemy.XP}の経験値入った");
                battleContext.windowLog.ShowLog("スペースで次へ");
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                if (battleContext.player.XP >= battleContext.player.XPForLevel)
                {
                    battleContext.windowLog.ShowLog($"レベル挙がったよ。回復したよ。");
                    battleContext.player2.OTOKO.Play();
                    battleContext.player.LevelUp();
                    battleContext.player.PlayerHPText.text = $"{battleContext.player.hp}/{battleContext.player.hpmax}";
                    yield return new WaitForSeconds(0.5f);
                    battleContext.windowLog.ShowLog("スペースで次へ");
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                }
            }
            
        }
        battleContext.player2.FightingMusic.Stop();
        battleContext.player2.ForBattleMusic.Stop();
        battleContext.player2.FieldMusic.mute = false;
        
        battleContext.windowBattleCommand.gameObject.SetActive(false);
        battleContext.windowLog.ClearLog();
        battleContext.player2.BattleCanvas.SetActive(false);
        battleContext.player2.Field_Canvas.SetActive(true);
        battleContext.player2.controlF = true;
        battleContext.Ran = false;
        
    }
}
