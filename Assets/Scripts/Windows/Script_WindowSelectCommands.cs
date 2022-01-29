using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Script_WindowSelectCommands : MonoBehaviour
{
    //SelectableText�I����J�[�\���ړ�
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
            Debug.Log(command);
            SelectableText texts= Instantiate(selectableTextPrefab, transform);
            texts.SetText(command);
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
        currentID = parent.GetSiblingIndex(); //�e���猩���Ƃ��ɉ��Ԗڂ� 
    }

    public void Open()
    {
        currentID = 0;
        gameObject.SetActive(true);
        SetMoveArrowFunction();
    }
}
