using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionMove : MonoBehaviour
{
    public Action<ResoursView> EnteredTrigger;

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
        if (collision.gameObject.TryGetComponent(out ResoursView resours))
        {
            EnteredTrigger?.Invoke(resours);
        }
    }
}
