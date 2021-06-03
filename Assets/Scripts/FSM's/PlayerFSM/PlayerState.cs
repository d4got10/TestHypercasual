using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class PlayerState : State
    {
        protected PlayerFiniteStateMachine StateMachine;

        public PlayerState(PlayerFiniteStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual IEnumerator OnTap(Vector2 screenPosition)
        {
            yield return null;
        }

        public virtual IEnumerator OnComplete()
        {
            yield return null;
        }
    }
}
