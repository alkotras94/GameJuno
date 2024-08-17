using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesFortrres : MonoBehaviour
{
    public int Resorsec { get; private set; }

    public void AddResources(int value)
    {
        Resorsec += value;
    }

    public void SpendResources(int value)
    {
        if (Resorsec > value)
        {
            Resorsec -= value;
        }
        else{
            
        }
    }
}
