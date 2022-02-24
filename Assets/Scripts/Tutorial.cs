using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> Images;
    int number = 0;
    bool End;
    void Start()
    {
        number = 0;
        StartCoroutine("StartTutorial");
    }

    IEnumerator StartTutorial()
    {
        while (End!=true)
        {
            Images[number].SetActive(true);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X));
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (number == 0)
                {
                    End = true;
                }
                else
                {
                    Images[number].SetActive(false);
                    number--;
                }

            }
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (number == Images.Count-1)
                {
                    End = true;
                }
                else
                {
                    Images[number].SetActive(false);
                    number++;
                }

            }
        }
        Images[number].SetActive(false);

        //Debug.Log("asasa");
        yield break;
    }
}
