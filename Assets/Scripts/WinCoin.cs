using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FSM.Player;

public class WinCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerFiniteStateMachine>(out var component))
        {
            component.OnComplete();
        }
    }
}
