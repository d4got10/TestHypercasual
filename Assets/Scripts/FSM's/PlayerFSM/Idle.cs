using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Idle : PlayerState
    {
        public Idle(PlayerFiniteStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override IEnumerator Start()
        {
            yield return null;
        }

        public override IEnumerator OnTap(Vector2 screenPosition)
        {
            StateMachine.SetState(new MovingToWaypoint(StateMachine));
            yield return null;
        }
    }
}
