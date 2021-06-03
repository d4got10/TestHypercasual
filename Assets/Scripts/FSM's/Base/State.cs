using System.Collections;

namespace FSM
{
    public abstract class State
    {
        public virtual IEnumerator Start()
        {
            yield return null;
        }
    }
}