using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelBtn : MonoBehaviour
{
    [SerializeField] Button nextLevelBtn;
    string prefabName;

    private void Start()
    {
        nextLevelBtn.onClick.AddListener(NextLevel);
    }

    void NextLevel()
    {
        // Lấy level hiện tại từ PlayerPrefs
        string currentLevel = PlayerPrefs.GetString("currLevel");

        // Tách chuỗi để lấy số level
        string[] levelParts = currentLevel.Split(' ');
        int levelNumber = int.Parse(levelParts[1]);

        // Tăng số level lên 1
        levelNumber++;

        // Tạo chuỗi level mới
        string prefabName = "Level " + levelNumber;
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
        ActionManager.OnNextLevel?.Invoke();
    }
}
