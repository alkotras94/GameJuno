using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesFortrres : MonoBehaviour
{
    public int Resorsec { get; private set; }

    public Action CountChanged;
    public void AddResources(int value)
    {
        Resorsec += value;
        CountChanged?.Invoke();
    }

    public void SpendResources(int value)
    {
        if (Resorsec > value)
        {
            Resorsec -= value;
            CountChanged?.Invoke();
        }
        else{
            
        }
    }
}
