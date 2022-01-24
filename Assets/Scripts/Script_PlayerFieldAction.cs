using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_PlayerFieldAction : MonoBehaviour
{

    public GameObject Bikkuri;
    public GameObject Hukidasi;
    public Text name;
    public Text serihu;
    public int kawasu;

    Script_PlayerController Sc_PC;
    // Start is called before the first frame update
    void Start()
    {
        Sc_PC = gameObject.GetComponent<Script_PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("treasure"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Script_Treasure test = other.GetComponent<Script_Treasure>();
                if (test.treasureN == 1)
                {
                    Debug.Log("You got a YAKUSOOOOO");
                    Bikkuri.SetActive(false);
                    Destroy(other.gameObject);
                }
            }
        }

        if (other.CompareTag("npc"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Script_NPC test = other.GetComponent<Script_NPC>();
                if (test.npcN == 1)
                {
                    if (test.kaiwaSu == 2)
                    {
                        Hukidasi.SetActive(true);
                        Sc_PC.controlF = false;
                        name.text = (test.name);
                        serihu.text = ("–l‚ë‚Ø‚ç");
                    }
                    if (test.kaiwaSu == 1)
                    {
                        serihu.text=("‚ ‚ ‚ ‚ ");
                    }
                    if (test.kaiwaSu == 0)
                    {
                        Hukidasi.SetActive(false);
                        Sc_PC.controlF = true;
                        test.kaiwaSu = 3;
                    }
                    test.kaiwaSu = test.kaiwaSu-1;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("treasure")| other.CompareTag("npc"))
        {
            Debug.Log("a");
            Bikkuri.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("treasure") | other.CompareTag("npc"))
        {
            Bikkuri.SetActive(false);
        }
    }
}
