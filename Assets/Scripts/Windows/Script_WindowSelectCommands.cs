using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Script_WindowSelectCommands : MonoBehaviour
{
    //SelectableText選択後カーソル移動
    [SerializeField] Transform arrow = default;
    [SerializeField] List<SelectableText> selectableTexts = new List<SelectableText>();
    [SerializeField] SelectableText selectableTextPrefab = default;
    public int currentID;

    public void CreateSelectabletext(string[] commands)
    {
        arrow.SetParent(transform);
        foreach(SelectableText selectableText in selectableTexts)
        {
            Destroy(selectableText.gameObject);
        }
        selectableTexts.Clear();
        foreach(string command in commands)
        {
            SelectableText texts= Instantiate(selectableTextPrefab, transform);
            texts.SetText(command);
            selectableTexts.Add(texts);
        }
    }

    public void CreateSelectabletextForEnemy(GameObject[] Enemys)
    {
        arrow.SetParent(transform);
        foreach (SelectableText selectableText in selectableTexts)
        {
            Destroy(selectableText.gameObject);
        }
        selectableTexts.Clear();
        foreach (GameObject enemy in Enemys)
        {
            ForBattleDate NameDate = enemy.GetComponent<ForBattleDate>();
            SelectableText texts = Instantiate(selectableTextPrefab, transform);
            texts.SetText(NameDate.name);
            selectableTexts.Add(texts);
        }
    }


    public void SetMoveArrowFunction()
    {
        foreach(SelectableText selectableText in selectableTexts)
        {
            selectableText.OnSelectAction = Movearrow;
        }
        EventSystem.current.SetSelectedGameObject(selectableTexts[currentID].gameObject);
    }

    public void Movearrow(Transform parent)
    {
        arrow.SetParent(parent);
        currentID = parent.GetSiblingIndex(); //親から見たときに何番目か 
    }

    public void Open()
    {
        currentID = 0;
        gameObject.SetActive(true);
        SetMoveArrowFunction();
    }

    
}
