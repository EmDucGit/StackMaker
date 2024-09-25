using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevelBtn : MonoBehaviour
{
    [SerializeField] Button restartBtn;
    string prefabName;

    private void Start()
    {
        restartBtn.onClick.AddListener(RestartLevel);
    }

    void RestartLevel()
    {
        prefabName = PlayerPrefs.GetString("currLevel");
        GameObject prefabLevel = Resources.Load<GameObject>(prefabName);

        // Kiểm tra nếu prefab tồn tại
        if (prefabLevel != null)
        {
            GameObject level = Instantiate(prefabLevel, Vector3.zero, Quaternion.identity);
            level.name = prefabLevel.name;
        }
        else
        {
            Debug.LogError("Prefab with name " + prefabName + " not found in Resources folder.");
        }
        ActionManager.OnRestartLevel?.Invoke();
    }
}
