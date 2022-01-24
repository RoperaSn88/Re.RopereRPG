using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Treasure : MonoBehaviour
{
    public int treasureN;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
