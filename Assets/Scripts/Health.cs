using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxValue = 1;

    public UnityEvent<int> Change;
    public UnityEvent Death;

    private int _value;
    public int Value
    {
        get => _value;
        private set
        {
            if(_value != value)
            {
                if (value > 0)
                {
                    _value = value;
                    Change.Invoke(_value);
                }
                else if(_value > 0)
                {
                    _value = 0;
                    Change.Invoke(_value);
                    Death.Invoke();
                }
            }
        }
    }

    private void Awake()
    {
        Value = _maxValue;
    }

    public void TakeDamage(int amount)
    {
        Value -= amount;
    }
}
