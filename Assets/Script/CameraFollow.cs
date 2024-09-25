using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    Vector3 offset = new Vector3(0f, 15f, -10f);

    void Start()
    {
        ActionManager.OnStartLevel += OnInit;
    }

    void Update()
    {
        if (target == null)
        {
            OnInit();
        } else
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, 0.1f);
            transform.position = smoothedPosition;
        }
    }

    void OnInit()
    {
        GameObject targetObject = GameObject.FindWithTag("Player");
        if (targetObject != null)
        {
            target = targetObject.transform;
            transform.position = target.position + offset;
            Debug.Log("Found player");
            ActionManager.OnStartLevel -= OnInit;
        }
        else
        {
            Debug.Log("No player found in the scene");
        }
    }

    private void OnDestroy()
    {
        ActionManager.OnStartLevel -= OnInit;
    }
}
