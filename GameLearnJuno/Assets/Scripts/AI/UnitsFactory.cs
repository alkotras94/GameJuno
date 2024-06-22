using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitsFactory : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    private ISpawnShape _spawnShape;

    public void Initialize(ISpawnShape spawnShape)
    {
        _spawnShape = spawnShape;
    }

    public void Create(int count)
    {
        List<Vector2> positions = _spawnShape.GetPositions(count);

        for (int i = 0; i < count; i++)
            Instantiate(_gameObject, positions[i], Quaternion.identity);
    }
}

public interface ISpawnShape
{
    public List<Vector2> GetPositions(int count);
}

