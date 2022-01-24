using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BattleManager : MonoBehaviour
{
    PhaseBase phaseState;
    [SerializeField] BattleContext battleContext;

    void Start()
    {
        phaseState = new StartPhase();
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        while (!(phaseState is EndPhase))
        {
            yield return phaseState.Execute(battleContext);

            phaseState=phaseState.next;

        }
        yield return phaseState.Execute(battleContext);

        yield break;
    }


    [System.Serializable]
    public struct BattleContext
    {
        // 戦闘キャラクターを作りたい
        public Script_Battle player;
        public Script_Battle enemy;

        // Window
        public Script_WindowSelectCommands windowBattleCommand;
        public Script_WindowSelectCommands windowMagicCommand;
        public Script_WindowSelectCommands windowItemCommand;
        public WindowLog windowLog;
        public void SetEnemy()
        {
            player.enemy = enemy;
            enemy.enemy = player;
        }
    }

}
