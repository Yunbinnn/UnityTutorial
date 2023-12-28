using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
    [SerializeField] GameObject[] selectedChar;
    private int selectedNum = 0;
    private int currentSeleted;

    void Start()
    {
        for (int i = 0; i < selectedChar.Length; i++)
        {
            selectedChar[i].SetActive(false);
        }

        currentSeleted = selectedNum;

        selectedChar[currentSeleted].SetActive(true);
    }

    public void LeftButton()
    {
        selectedChar[currentSeleted].SetActive(false);

        selectedNum--;

        if(selectedNum < 0)
        {
            selectedNum = selectedChar.Length - 1;
        }

        currentSeleted = selectedNum;

        selectedChar[currentSeleted].SetActive(true);
    }

    public void RightButton()
    {
        selectedChar[currentSeleted].SetActive(false);

        selectedNum++;

        if (selectedNum > selectedChar.Length - 1)
        {
            selectedNum = 0;
        }

        currentSeleted = selectedNum;

        selectedChar[currentSeleted].SetActive(true);
    }

}
