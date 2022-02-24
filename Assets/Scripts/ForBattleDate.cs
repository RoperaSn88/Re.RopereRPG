using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ForBattleDate : MonoBehaviour
{
    public new string name;
    public enum Which
    {
        enemy,
        player,
    }
    public Which Who;
    public int hp;
    public int hpmax;
    public int mp;
    public int XP;
    public int XPForLevel;
    public int Level;
    public int BaseAttackPoint;
    public int RandomAttackPoint;
    public int BaseCountTimer;
    public int CountTimer;
    public bool boss;
    public AudioSource FightingSound;

    public bool playerF = false;
    public Text PlayerHPText;
    public bool EnhanceF = false;
    public Image EnhanceImage;
    public Text EnhanceText;
    int EnhanceTime;
    public bool SpeedF = false;
    public Image SpeedImage;
    public Text SpeedText;
    int SpeedTime;

    public Script_BattleManager BM;
    public Script_commandSO SelectCommand;
    public ForBattleDate target;
    public ForBattleDate enemy;

    public List<Script_commandSO> commands;
    public string[] GetStringCommands()
    {
        return GetString(commands);
    }


    public List<Script_commandSO> inventory = new List<Script_commandSO>();
    public string[] GetStringItems()
    {
        return GetString(inventory);
    }

    /*
    public GameObject[] enemys;
    public List<string> list = new List<string>();
    public string[] GetStringEnemys()
    {
        //List<string> list = new List<string>();
        foreach (GameObject enemy in enemys)
        {
            ForBattleDate test = enemy.GetComponent<ForBattleDate>();
            list.Add(test.name);
        }
        return list.ToArray();
    }
    */

    public string[] GetString(List<Script_commandSO> commands)
    {
        List<string> list = new List<string>();
        foreach (Script_commandSO command in commands)
        {
            list.Add(command.name);
        }
        return list.ToArray();
    }

    public void UseItem(Script_commandSO item)
    {
        inventory.Remove(item);
    }

    public void SetTarget()
    {
        if (SelectCommand.Target == Script_commandSO.Targettype.Self)
        {
            target = this;
        }
        else if (SelectCommand.Target == Script_commandSO.Targettype.Enemy)
        {
            target = enemy;
        }
    }

    public Animator PlayerAnimator;
    public void PlayAttackAnimator()
    {
        PlayerAnimator.SetTrigger("AttackT");
    }

    public Slider HPbar;
    public void SetHP()
    {
        HPbar.maxValue = hpmax;
        HPbar.value = hp;
    }

    public Image Gage;
    public Text Count;
    bool StartF = false;
   
    public void StartTimer()
    {
        CountTimer = BaseCountTimer;
        StartF = true;
    }
    public void StopTimer()
    {
        StartF=false;
    }

    public void LevelUp()
    {
        BaseAttackPoint += 2;
        hpmax = hpmax +10;
        hp = hpmax;
        SetHP();
        mp += 3;
        Level += 1;
        XP = XP - XPForLevel;
        XPForLevel = Level * 2 + 16;
    }
    public WindowLog Log;
    
    public void StartEnhance()
    {
        EnhanceImage.gameObject.SetActive(true);
        EnhanceF = true;
        EnhanceTime = 18;
        EnhanceText.text = "18";
        EnhanceImage.fillAmount = 1;
        Log.ShowLog($"力がみなぎる...!!");
    }

    public void StartSpeed()
    {
        SpeedImage.gameObject.SetActive(true);
        SpeedF = true;
        SpeedTime = 28;
        SpeedText.text = "28";
        SpeedImage.fillAmount = 1;
        Log.ShowLog($"体が軽く感じる...!!");
    }

    public void Update()
    {
        if (StartF == true)
        {
            if (hp > 0)
            {
                if (Gage.fillAmount > 0)
                {
                    Gage.fillAmount -= 1 * Time.deltaTime;
                }
                if (Gage.fillAmount == 0)
                {
                    CountTimer--;
                    if (CountTimer == 0)
                    {
                        RandomAttackPoint = Random.Range(BaseAttackPoint - 1, BaseAttackPoint + 2);
                        if (RandomAttackPoint <= 0)
                        {
                            RandomAttackPoint = 0;
                        }
                        target.hp -= RandomAttackPoint;
                        CountTimer = BaseCountTimer;
                        target.SetHP();
                        target.PlayerHPText.text=$"{target.hp}/{target.hpmax}";
                        FightingSound.Play();
                        Log.ShowLog($"{name}の攻撃！！{RandomAttackPoint}ダメージくらった");
                        if (target.hp <= 0)
                        {
                            Animator PlayerDeath = target.GetComponent<Animator>();
                            PlayerDeath.SetTrigger("Death");
                            target.playerF = false;
                            BM.StartCoroutine("Gameover");
                        }
                    }
                    Count.text = $"{CountTimer}";
                    Gage.fillAmount = 1;
                }
            }
        }

        if (playerF == true)
        {
            if (Gage.fillAmount > 0)
            {
                Gage.fillAmount -= 1 * Time.deltaTime;
            }
            if (Gage.fillAmount == 0)
            {
                CountTimer--;
                Count.text = $"{CountTimer}";
                if (CountTimer == 0)
                {
                    playerF = false;
                }
                else
                {
                    Gage.fillAmount = 1;
                }
            }
        }

        if (EnhanceF == true)
        {
            if (EnhanceImage.fillAmount > 0)
            {
                EnhanceImage.fillAmount -= 1 * Time.deltaTime;
            }
            if (EnhanceImage.fillAmount == 0)
            {
                EnhanceTime--;
                EnhanceText.text = $"{EnhanceTime}";
                if (EnhanceTime == 0)
                {
                    EnhanceF = false;
                    EnhanceImage.gameObject.SetActive(false);
                }
                else
                {
                    EnhanceImage.fillAmount = 1;
                }

            }

        }

        if (SpeedF == true)
        {
            if (SpeedImage.fillAmount > 0)
            {
                SpeedImage.fillAmount -= 1 * Time.deltaTime;
            }
            if (SpeedImage.fillAmount == 0)
            {
                SpeedTime--;
                SpeedText.text = $"{SpeedTime}";
                if (SpeedTime == 0)
                {
                    SpeedF = false;
                    SpeedImage.gameObject.SetActive(false);
                }
                else
                {
                    SpeedImage.fillAmount = 1;
                }

            }

        }
    }


}
