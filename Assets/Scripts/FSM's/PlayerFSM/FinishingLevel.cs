using System.Collections;

namespace FSM.Player
{
    public class FinishingLevel : PlayerState
    {
        public FinishingLevel(PlayerFiniteStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override IEnumerator Start()
        {
            StateMachine.FinishedLevel.Invoke();
            yield return null;
        }
    }
}
