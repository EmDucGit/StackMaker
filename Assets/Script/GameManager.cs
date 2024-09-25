using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    List<string> completeLevel;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        //reset data
        //PlayerPrefs.DeleteAll();
        if (Instance == null)
        {
            Instance = this;
            completeLevel = new List<string>(); // Khởi tạo List
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //// Kiểm tra xem PlayerPrefs đã có key "highestLevel" chưa
        //if (!PlayerPrefs.HasKey("highestLevel"))
        //{
        //    // Nếu chưa có key "highestLevel", tạo key "highestLevel" với giá trị default
        //    PlayerPrefs.SetInt("highestLevel", 0);
        //    // Lưu lại thay đổi
        //    PlayerPrefs.Save();
        //}
        //else
        //{
        //    return;
        //}
    }

    public void AddLevel(string levelname)
    {
        completeLevel.Add(levelname);
    }

    public int GetLevelLength()
    {
        return completeLevel.Count;
    }

    public bool IsLevelComplete(string levelname)
    {
        return completeLevel.Contains(levelname);
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("highestLevel") > 0)
        {
            for (int i = 1; i <= PlayerPrefs.GetInt("highestLevel"); i++)
            {
                AddLevel("Level " + i);
            }
        } else
        {
            return;
        }
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("highestLevel"));
    }
}
