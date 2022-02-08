using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class WindowLog : MonoBehaviour
{
    Text LogText;
    int LineCount;
    bool Writing = false;

    private void Awake()
    {
        LogText = GetComponentInChildren<Text>();   
    }
    public void ShowLog(string message)
    {
        StartCoroutine(ShowChara(message));
    }
    IEnumerator ShowChara(string message)
    {
        Writing = true;
        string SendMessage = '\n' + message;
        foreach(char c in SendMessage)
        {
            yield return new WaitForSeconds(0.005f);
            if (c == '\n')
            {
                LineCount++;
                if (LineCount >= 7)
                {
                    yield return MoveLine();
                }
            }
            LogText.text += c;
        }
        Writing = false;
    }

    IEnumerator MoveLine()
    {
        yield return new WaitForSeconds(0.2f);
        int removePoint = LogText.text.IndexOf('\n') + 1;
        LogText.text = LogText.text.Substring(removePoint);
        LineCount--;
        yield return new WaitForSeconds(0.2f);
    }
    public IEnumerator WaitWriting()
    {
        // WaitUntil() true‚É‚È‚Á‚½‚ç”²‚¯‚é
        yield return new WaitUntil(() => Writing == false);
    }


}
