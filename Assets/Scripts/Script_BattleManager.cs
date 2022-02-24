using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_BattleManager : MonoBehaviour
{
    PhaseBase phaseState;
    [SerializeField] BattleContext battleContext;
    public List<GameObject> enemys = new List<GameObject>();
    public GameObject BattleFieldCanvas;
    public RectTransform EnemySpawnPoint;
    bool FadeIn;
    float r, b, g, a;

    public void Start()
    {
        battleContext.Panel.gameObject.SetActive(true);
        r = battleContext.Panel.color.r;
        g = battleContext.Panel.color.g;
        b = battleContext.Panel.color.b;
        a = battleContext.Panel.color.a;
        FadeIn = true;
    }


    public IEnumerator Battle()
    {
        phaseState = new StartPhase();
        while (!(phaseState is EndPhase))
        {
            if(phaseState is StartPhase)
            {
                while (battleContext.player2.Enemys.Count != 0)
                {
                    GameObject enemy = battleContext.player2.Enemys[0];
                    /*GameObject Prefab= Instantiate(enemy, EnemySpawnPoint.position, Quaternion.identity);
                    Prefab.transform.SetParent(BattleFieldCanvas.transform, false);*/
                    battleContext.player2.Enemys.RemoveAt(0);
                    battleContext.CountEnemy++;
                }
                //battleContext.enemys = GameObject.FindGameObjectsWithTag("Enemy");
                battleContext.enemyObject = battleContext.player2.Enemy;
                battleContext.enemyObject.SetActive(true);
                battleContext.enemy = battleContext.enemyObject.GetComponent<ForBattleDate>();
            }

            
            yield return phaseState.Execute(battleContext);

            phaseState=phaseState.next;
            //Debug.Log(phaseState);

        }
        yield return phaseState.Execute(battleContext);
        //Debug.Log("owata");
        yield break;
        
    }

    public void Update()
    {
        if (FadeIn == true)
        {
            a -= 0.05f;
            battleContext.Panel.color = new Color(r, b, g, a);
            if (a <= 0)
            {
                FadeIn = false;
                battleContext.Panel.gameObject.SetActive(false);
            }
        }
        if (battleContext.Fade == true)
        {
            a += 0.02f;
            battleContext.Panel.color = new Color(r, b, g, a);
        }
    }

    public IEnumerator Gameover()
    {
        battleContext.Fade = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Title");
    }



    [System.Serializable]
    public struct BattleContext
    {
        // 戦闘キャラクターを作りたい
        public ForBattleDate player;
        public Script_PlayerController player2;
        public ForBattleDate enemy;
        public GameObject[] enemys;
        public GameObject enemyObject;
        public int CountEnemy;
        public bool canRun;
        public bool Ran;
        public Image Panel;
        public bool Fade;
        


        // Window
        public Script_WindowSelectCommands windowFirstCommand;
        public Script_WindowSelectCommands windowBattleCommand;
        public Script_WindowSelectCommands windowMagicCommand;
        public Script_WindowSelectCommands windowItemCommand;
        public Script_WindowSelectCommands windowTargetCommand;
        public WindowLog windowLog;

        public TextAnimation Battle;
        
    }

}
