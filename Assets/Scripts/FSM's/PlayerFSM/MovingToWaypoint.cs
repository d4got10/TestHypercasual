using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class MovingToWaypoint : PlayerState
    {
        public MovingToWaypoint(PlayerFiniteStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override IEnumerator Start()
        {
            if (StateMachine.Navigation.TryMoveToNextWaypoint() == false)
            {
                StateMachine.SetState(new FinishingLevel(StateMachine));
            }
            else
            {
                var waypointPosition = StateMachine.Navigation.GetCurrentWaypoint();
                if(StateMachine.NavMeshAgent.SetDestination(waypointPosition) == false)
                {
                    Debug.LogError("Path is too narrow. Main Character can't reach next waypoint.", StateMachine);
                }
                yield return new WaitUntil(() => StateMachine.NavMeshAgent.hasPath);

                StateMachine.Animator.SetBool(AnimatorKeywords.Moving, true);

                while (StateMachine.NavMeshAgent.remainingDistance > StateMachine.NavMeshAgent.stoppingDistance)
                {
                    yield return null;
                }

                StateMachine.Animator.SetBool(AnimatorKeywords.Moving, false);
                StateMachine.SetState(new Shooting(StateMachine));
            }
        }

        public override IEnumerator OnComplete()
        {
            StateMachine.FinishedLevel.Invoke();
            yield return null;
        }
    }
}
