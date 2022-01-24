using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerController : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Bikkuri;
    int encount = 0;


    Animator PlayerAnimator;
    Transform myTransform;
    public GameObject Attack;
    public GameObject minicam;
    public bool controlF = true;
    bool FieldIF = false;
    public PlayerAttackPoint Right;
    public PlayerAttackPoint Left;
    public PlayerAttackPoint Up;
    public PlayerAttackPoint Down;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        FieldIF = true;
    }

    // Update is called once per frame
    void Update()
    {
        Attack.transform.rotation = Quaternion.Euler(0, 0, 0);
        minicam.transform.rotation = Quaternion.Euler(90, 0, 0);
        //ÉJÉÅÉâÇÃà íuå≈íË
        Camera.transform.position = new Vector3(myTransform.position.x, myTransform.position.y + 1.5f, myTransform.position.z - 3f);
        if (controlF == true)
        {
            if (Up.Hitting != true)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += new Vector3(0, 0, 3 * Time.deltaTime);
                    Encount();
                }
            }
            if (Down.Hitting != true)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    transform.position += new Vector3(0, 0, -3 * Time.deltaTime);
                    Encount();
                }
            }

            if (Right.Hitting != true)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
                    myTransform.rotation = new Quaternion(0, 0, 0, 0);
                    Encount();
                }
            }

            if (Left.Hitting != true)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += new Vector3(-3 * Time.deltaTime, 0, 0);
                    myTransform.rotation = new Quaternion(0, 180, 0, 0);
                    Encount();
                }
            }
            

            if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.W))
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
            
            encount += Random.Range(1, 6);
            if (encount >= 100)
            {
                Debug.Log("ìGÇ∆èÑÇËçáÇ¡ÇΩ");
                controlF = false;
            }
        }
    }
    
}
