using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public abstract class FiniteStateMachine<T> : MonoBehaviour where T : State
    {
        public T State { get; private set; }

        protected Coroutine CurrentStateCoroutine;

        public void SetState(T state)
        {
            State = state;
            if (CurrentStateCoroutine != null)
                StopCoroutine(CurrentStateCoroutine);
            CurrentStateCoroutine = StartCoroutine(State.Start());
        }
    }
}