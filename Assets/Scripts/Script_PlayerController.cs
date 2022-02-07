using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerController : MonoBehaviour
{
    public GameObject Cam;
    public GameObject Bikkuri;
    int encount = 0;


    Animator PlayerAnimator;
    Transform myTransform;
    public GameObject Attack;
    public GameObject minicam;
    public GameObject BattleM;
    public bool controlF = true;
    bool FieldIF = false;
    public PlayerAttackPoint Right;
    public PlayerAttackPoint Left;
    public PlayerAttackPoint Up;
    public PlayerAttackPoint Down;
    public GameObject BattleCanvas;
    public GameObject Field_Canvas;
    public List<GameObject> Enemys = new List<GameObject>();
    public GameObject Enemy;
    Script_PlayerFieldAction PFA;
    Script_BattleManager BM;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        PFA = GetComponent<Script_PlayerFieldAction>();
        BM = BattleM.GetComponent<Script_BattleManager>();
        
        FieldIF = true;
    }

    // Update is called once per frame
    void Update()
    {
        Attack.transform.rotation = Quaternion.Euler(0, 0, 0);
        minicam.transform.rotation = Quaternion.Euler(90, 0, 0);
        //�J�����̈ʒu�Œ�
        
        if (controlF == true)
        {
            Cam.transform.position = new Vector3(myTransform.position.x, myTransform.position.y + 1.5f, myTransform.position.z - 3f);
            if (Up.Hitting != true)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position += new Vector3(0, 0, 3 * Time.deltaTime);
                    Encount();
                }
            }
            if (Down.Hitting != true)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position += new Vector3(0, 0, -3 * Time.deltaTime);
                    Encount();
                }
            }

            if (Right.Hitting != true)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
                    myTransform.rotation = new Quaternion(0, 0, 0, 0);
                    Encount();
                }
            }

            if (Left.Hitting != true)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(-3 * Time.deltaTime, 0, 0);
                    myTransform.rotation = new Quaternion(0, 180, 0, 0);
                    Encount();
                }
            }

            

            if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.LeftArrow))
            {
                PlayerAnimator.SetBool("runF", true);
            }
            else
            {
                PlayerAnimator.SetBool("runF", false);
            }
        }

        Debug.Log($"encount:{encount}");
    }

    void Encount()
    {
        if (FieldIF == true)
        {
            
            //encount += Random.Range(1, 6);
            encount += 10;
            if (encount >= 100)
            {
                Debug.Log("�G�Ə��荇����");
                controlF = false;
            }
        }
    }

    void Battle()
    {
        controlF = false;
        PlayerAnimator.SetBool("runF", false);
        BattleCanvas.SetActive(true);
        Field_Canvas.SetActive(false);
        Transform CT = Cam.GetComponent<Transform>();
        Camera CC = Cam.GetComponent<Camera>();
        myTransform.rotation = new Quaternion(0, 180, 0, 0);
        Cam.transform.position = new Vector3(myTransform.position.x, myTransform.position.y + 1.5f, myTransform.position.z - 3f);
        CC.orthographicSize = CC.orthographicSize - 2.0f;
        CT.position += new Vector3(-0.5f, 0, 0);
        BM.StartCoroutine("Battle");
    }


    private void OnTriggerStay(Collider other)
    {
        {
            if (other.gameObject.CompareTag("DangerArea"))
            {
                if (encount >= 100)
                {
                    /*
                    Enemys.Clear();
                    encount = 0;
                    DangerAreaScript Entry = other.gameObject.GetComponent<DangerAreaScript>();
                    int EntryEnemy = 1;
                    while (EntryEnemy != 0)
                    {
                        GameObject Enemy = Entry.Enemys[Random.Range(0, Entry.Enemys.Count)];
                        Enemys.Add(Enemy);
                        EntryEnemy--;
                    }
                    Battle();
                    */
                    controlF = false;
                    encount = 0;
                    DangerAreaScript EnemyEntry = other.GetComponent<DangerAreaScript>();
                    Enemy = EnemyEntry.Enemys[0];
                    
                    
                    Battle();
                }
            }
        }
    }

}