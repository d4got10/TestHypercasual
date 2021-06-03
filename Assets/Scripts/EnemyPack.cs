using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPack : MonoBehaviour
{
    [SerializeField] private Health[] _healthes;

    public UnityEvent EnemyPackComplete;

    private int _deadCount = 0;

    private void Awake()
    {
        _deadCount = 0;
        foreach(var health in _healthes)
        {
            health.Death.AddListener(IncreaseDeadCount);
        }
    }

    private void IncreaseDeadCount()
    {
        _deadCount++;
        if(_deadCount == _healthes.Length)
        {
            EnemyPackComplete.Invoke();
        }
    }
}
