using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
        }

        if (this != null)
        {
            ActionManager.OnAddBrick?.Invoke();
        }
    }

    private void Start()
    {
        ActionManager.OnRestartLevel += OnInit;
    }

    void OnInit()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        ActionManager.OnRestartLevel -= OnInit;
    }
}
