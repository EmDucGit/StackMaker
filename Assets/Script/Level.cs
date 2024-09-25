using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("currLevel", gameObject.name);
        Debug.Log("Curr Lv: " + PlayerPrefs.GetString("currLevel"));
        ActionManager.OnRestartLevel += DeleteLevel;
        ActionManager.OnNextLevel += DeleteLevel;
        ActionManager.OnStartLevel?.Invoke();
    }

    void DeleteLevel()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        ActionManager.OnRestartLevel -= DeleteLevel;
        ActionManager.OnNextLevel -= DeleteLevel;
    }
}
