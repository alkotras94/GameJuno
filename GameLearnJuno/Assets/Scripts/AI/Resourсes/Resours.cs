using UnityEngine;

public abstract class Resours : MonoBehaviour, IHitble
{
    [field: SerializeField] public ResourcesData _resourcesData { get; private set; }
}
