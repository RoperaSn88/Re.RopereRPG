using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class WindowLog : MonoBehaviour
{
    Text LogText;
    public int LineCount;
    bool Writing = false;

    private void Awake()
    {
        LogText = GetComponentInChildren<Text>();   
    }
    public void ShowLog(string message)
    {
        StartCoroutine(ShowChara(message));
    }
    public void ClearLog()
    {
        LogText.text = "";
    }
    IEnumerator ShowChara(string message)
    {
        Writing = true;
        string SendMessage = '\n' + message;
        /*
        foreach(char c in SendMessage)
        {
            yield return new WaitForSeconds(0.02f);
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
        */
        LogText.text += SendMessage;
        LineCount++;
        if (LineCount >= 5)
        {
            yield return MoveLine();
        }
        Writing = false;
        yield return null;
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
