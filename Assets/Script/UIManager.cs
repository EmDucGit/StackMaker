using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrickUI : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LevelSelectPanel;
    [SerializeField] TextMeshProUGUI textBrick;
    [SerializeField] TextMeshProUGUI textLevel;
    int currBrickInGame;
    private void Start()
    {
        ActionManager.OnStartLevel += SetUI;
        ActionManager.OnAddBrick += AddBrickUI;
        ActionManager.OnRemoveBrick += RemoveBrickUI;
        ActionManager.OnWinPos += ClearBrickUI;
        ActionManager.OnWinPos += SetUIOnWWin;
        currBrickInGame = 0;
        if (PlayerPrefs.HasKey("currBrickInGame"))
        {
            return;
        }
        else
        {
            PlayerPrefs.SetInt("currBrickInGame", currBrickInGame);
        }
    }

    void SetUI()
    {
        textLevel.text = PlayerPrefs.GetString("currLevel");
        textBrick.gameObject.SetActive(true);
    }

    void AddBrickUI()
    {
        currBrickInGame++;
        textBrick.text = currBrickInGame.ToString();
    }

    void RemoveBrickUI()
    {
        currBrickInGame--;
        textBrick.text = currBrickInGame.ToString();
    }

    void ClearBrickUI()
    {
        currBrickInGame = 0;
        textBrick.text = currBrickInGame.ToString();
    }
    void SetUIOnWWin()
    {
        WinPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        ActionManager.OnStartLevel -= SetUI;
        ActionManager.OnAddBrick -= AddBrickUI;
        ActionManager.OnRemoveBrick -= RemoveBrickUI;
        ActionManager.OnWinPos -= ClearBrickUI;
        ActionManager.OnWinPos -= SetUIOnWWin;
    }
}
