using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public GameObject player;
    public GameObject CreditPanel;
    public Animator PlayerAnimator;
    public AudioSource PressSound;
    public AudioSource BGM;
    public Image Panel;
    public float r, b, g, a;
    public bool PlayerUp;
    public bool FadeOut;
    public IEnumerator StartButton()
    {
        BGM.Stop();
        PressSound.Play();
        PlayerAnimator.SetBool("jumpF",true);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        Panel.gameObject.SetActive(true);
        PlayerUp = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("World");
    }

    public void Start()
    {
        r = Panel.color.r;
        g = Panel.color.g;
        b = Panel.color.b;
        a = Panel.color.a;
    }
    public void StartB()
    {
        StartCoroutine("StartButton");
    }

    void ChangeColor()
    {
        a += 0.02f;
        Panel.color = new Color(r, b, g, a);
        if (a >= 1)
        {
            FadeOut = false;
        }
    }

    public void CreditB()
    {
        PressSound.Play();
        CreditPanel.SetActive(true);
    }

    public void CloseB()
    {
        PressSound.Play();
        CreditPanel.SetActive(false);
    }

    public void Update()
    {
        if (PlayerUp == true)
        {
            player.transform.position += new Vector3(1*Time.deltaTime, 0, 0);
            ChangeColor();
            Debug.Log("AAA");
        }
        if (FadeOut == true)
        {
            ChangeColor();
            Debug.Log("AAA");
        }
    }
}
