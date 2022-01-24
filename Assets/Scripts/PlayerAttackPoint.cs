using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackPoint : MonoBehaviour
{
    public bool Hitting = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("block"))
        {
            Hitting = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("block"))
        {
            Hitting = false;
        }

    }

}
