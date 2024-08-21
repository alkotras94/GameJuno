using System;
using UnityEngine;

public class DetectionCastle : MonoBehaviour
{
    public Action ExitTrigger;

    private void Start()
    {
        enabled = false;
    }
    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Forttres resours))
        {
            Debug.Log("Зашел в замок");
            ExitTrigger?.Invoke();
        }
    }
}
