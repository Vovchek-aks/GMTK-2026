using System;

namespace Goals
{
    public interface IGoal
    {
        event Action<IGoal> WasReached;
    }
}