using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace FSM.Player
{
    public class PlayerFiniteStateMachine : FiniteStateMachine<PlayerState>
    {
        [SerializeField] private PlayerNavigation _navigation;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private Gun _gun;

        public UnityEvent FinishedLevel; 

        public IPlayerNavigation Navigation => _navigation;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public Animator Animator => _animator;
        public Gun Gun => _gun;

        private void Start()
        {
            SetState(new Idle(this));
        }

        public void OnTap(Vector2 screenPosition)
        {
            CurrentStateCoroutine = StartCoroutine(State.OnTap(screenPosition));
        }

        public void OnComplete()
        {
            CurrentStateCoroutine = StartCoroutine(State.OnComplete());
        }
    }
}
