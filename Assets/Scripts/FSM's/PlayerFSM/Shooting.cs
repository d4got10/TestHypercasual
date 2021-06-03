using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Shooting : PlayerState
    {
        public Shooting(PlayerFiniteStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override IEnumerator Start()
        {
            StateMachine.Animator.SetBool(AnimatorKeywords.Shooting, true);
            yield return null;
        }

        public override IEnumerator OnTap(Vector2 screenPosition)
        {
            var offset = screenPosition.x - Camera.main.pixelWidth / 2;
            var angle = 75 * offset / Camera.main.pixelWidth;

            var direction = new Vector2(StateMachine.transform.forward.x, StateMachine.transform.forward.z);
            var newDirection = direction.Rotate(-angle);

            StateMachine.Gun.Shoot(newDirection);
            StateMachine.Animator.SetTrigger(AnimatorKeywords.Shoot);

            yield return null;
        }

        public override IEnumerator OnComplete()
        {
            StateMachine.Animator.SetBool(AnimatorKeywords.Shooting, false);
            StateMachine.SetState(new MovingToWaypoint(StateMachine));
            yield return null;
        }
    }
}
