using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Action EnteredTrigger;
    public Action OutTrigger;

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
        if (collision.gameObject.TryGetComponent(out Resours resours))
        {
            EnteredTrigger?.Invoke();
        }

        if (collision.gameObject.TryGetComponent(out Forttres fortress))
        {
            OutTrigger?.Invoke();
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
