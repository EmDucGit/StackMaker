using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] public Button[] levelBtn;

    private void Start()
    {
        // Ban đầu set tất cả các button là inactive
        for (int i = 1; i < levelBtn.Length; i++)
        {
            levelBtn[i].interactable = false;
        }
        ActionManager.OnWinPos += UpdateUI;

        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 1; i < levelBtn.Length; i++)
        {
            if (i <= GameManager.Instance.GetLevelLength())
            {
                levelBtn[i].interactable = true;
            } else
            {
                levelBtn[i].interactable = false;
            }
        }
    }
}
