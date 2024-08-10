using UnityEngine;

public abstract class Resours : MonoBehaviour, IHitble
{
    [SerializeField] public ResourcesData _resourcesData { get; private set; }
}
