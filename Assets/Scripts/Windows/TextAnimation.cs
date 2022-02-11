using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    public Animator TextAnim;
    public bool Moving;

    public void Start()
    {
        TextAnim = gameObject.GetComponent<Animator>();
    }
    public void PlayAnimation()
    {
        gameObject.SetActive(true);
        TextAnim.SetTrigger("Set");
        Moving = true;
    }

    public void EndAnim()
    {
        gameObject.SetActive(false);
        Moving = false;
        Debug.Log("‚¨‚í‚Á‚½");
    }

}
