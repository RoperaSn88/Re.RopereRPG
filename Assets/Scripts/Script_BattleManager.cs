using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_BattleManager : MonoBehaviour
{
    PhaseBase phaseState;
    [SerializeField] BattleContext battleContext;
    public List<GameObject> enemys = new List<GameObject>();

    void Start()
    {
        phaseState = new StartPhase();
    }

    public IEnumerator Battle()
    {
        while (!(phaseState is EndPhase))
        {
            if(phaseState is StartPhase)
            {
                while (battleContext.player2.Enemys.Count != 0)
                {
                    GameObject enemy = battleContext.player2.Enemys[0];
                    Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
                    battleContext.player2.Enemys.RemoveAt(0);
                    battleContext.CountEnemy++;
                }
            }
            
            yield return phaseState.Execute(battleContext);

            phaseState=phaseState.next;
            Debug.Log(phaseState);

        }
        yield return phaseState.Execute(battleContext);

        yield break;
    }


    [System.Serializable]
    public struct BattleContext
    {
        // �퓬�L�����N�^�[����肽��
        public Script_Battle player;
        public Script_PlayerController player2;
        public Script_Battle enemy;
        public int CountEnemy;

        // Window
        public Script_WindowSelectCommands windowBattleCommand;
        public Script_WindowSelectCommands windowMagicCommand;
        public Script_WindowSelectCommands windowItemCommand;
        public WindowLog windowLog;
        
    }

}
