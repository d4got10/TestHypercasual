using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private Health _target;
    [SerializeField] private TextMeshProUGUI _view;

    private void Awake()
    {
        _target.Change.AddListener(OnHealthChange);
    }

    private void Start()
    {
        OnHealthChange(_target.Value);
    }

    private void OnHealthChange(int amount)
    {
        if (amount == 0)
        {
            _view.text = "";
        }
        else
        {
            _view.text = amount.ToString();
        }
    }
}
