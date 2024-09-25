using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : MonoBehaviour
{
    [SerializeField] GameObject chestOpen;
    [SerializeField] GameObject chestClose;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            chestOpen.SetActive(true);
            chestClose.SetActive(false);
            ActionManager.OnWinPos?.Invoke();
            if (!GameManager.Instance.IsLevelComplete(PlayerPrefs.GetString("currLevel")))
            {
                GameManager.Instance.AddLevel(PlayerPrefs.GetString("currLevel"));
                PlayerPrefs.SetInt("highestLevel", GameManager.Instance.GetLevelLength());
                PlayerPrefs.Save();
            } else
            {
                return;
            }
        }
    }
}
