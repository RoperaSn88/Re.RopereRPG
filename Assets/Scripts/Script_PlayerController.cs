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
    public PlayerAttackPoint Head;
    public PlayerAttackPoint Asi;
    public GameObject BattleCanvas;
    public GameObject Field_Canvas;
    public List<GameObject> Enemys = new List<GameObject>();
    public GameObject Enemy;
    Script_PlayerFieldAction PFA;
    Script_BattleManager BM;
    Rigidbody PR;
    public Transform CT;
    public Camera CC;
    bool canLadder;
    bool Ladding;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        PFA = GetComponent<Script_PlayerFieldAction>();
        BM = BattleM.GetComponent<Script_BattleManager>();
        CT = Cam.GetComponent<Transform>();
        CC=Cam.GetComponent<Camera>();
        PR=GetComponent<Rigidbody>();
        
        FieldIF = true;

        Attack.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public void Awake()
    {
        
    }
    void Update()
    {
        
        //カメラの位置固定
        
        if (controlF == true)
        {
            Cam.transform.position = new Vector3(myTransform.position.x, myTransform.position.y + 1.5f, myTransform.position.z - 3f);
            Attack.transform.rotation = Quaternion.Euler(0, 0, 0);
            minicam.transform.rotation = Quaternion.Euler(90, 0, 0);
            if (Ladding == false)
            {
                PR.useGravity = true;
                if (Up.Hitting != true)//ふぃーるどアクション
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

                if (canLadder == true)
                {
                    Bikkuri.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (Ladding == false)
                        {
                            Ladding = true;
                        }
                        else
                        {
                            Ladding = false;
                        }
                    }
                }
                else
                {
                    Bikkuri.SetActive(false);
                }

                PlayerAnimator.SetBool("LadderF", false);
            }
            else //はしごアクション
            {
                PR.useGravity = false;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (Head.Hitting != true)
                    {
                        transform.position += new Vector3(0, 2 * Time.deltaTime, 0);
                        
                    } 
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (Asi.Hitting != true)
                    {
                        transform.position += new Vector3(0, -2 * Time.deltaTime, 0);
                    }
                }

                PlayerAnimator.SetBool("LadderF", true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Ladding = false;
                }
                Bikkuri.SetActive(false);
            }
        }

        Debug.Log($"encount:{encount}");
    }

    void Encount()
    {
        if (FieldIF == true)
        {
            
            encount += Random.Range(2, 5);
            
            if (encount >= 150)
            {
                Debug.Log("敵と巡り合った");
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
                    Enemy = EnemyEntry.Enemys[Random.Range(0,EnemyEntry.Enemys.Count)];
                    
                    
                    Battle();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            canLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            canLadder = false;
        }
    }

}