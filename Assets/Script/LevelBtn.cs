using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectBtn : MonoBehaviour
{
    [SerializeField] string prefabName;
    [SerializeField] Button levelBtn;
    // Start is called before the first frame update
    void Start()
    {
        levelBtn.onClick.AddListener(SpawnLevel);
    }

    void SpawnLevel()
    {
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
