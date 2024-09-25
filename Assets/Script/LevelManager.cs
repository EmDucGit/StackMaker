using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    Transform startPoint;
    [SerializeField] GameObject player;

    public List<String> completeLv;

    private void Start()
    {
        ActionManager.OnStartLevel += OnInit;
    }

    void OnInit()
    {
        GameObject targetObject = GameObject.FindWithTag("startPoint");
        if (targetObject != null)
        {
            startPoint = targetObject.transform;
        }
        Instantiate(player, new Vector3(startPoint.position.x, 0.15f, startPoint.position.z), startPoint.rotation);
    }

    private void OnDestroy()
    {
        ActionManager.OnStartLevel -= OnInit;
    }
}
