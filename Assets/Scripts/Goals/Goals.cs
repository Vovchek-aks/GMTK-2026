using System;

namespace Goals
{
    public class Goals
    {
        public int Total { private set; get; } = 0;
        public int Completed { private set; get; } = 0;

        public event Action GoalWasCompleted;
        public event Action AllGoalsWasCompleted;

        public void Register(IGoal goal)
        {
            goal.WasReached += OnGoalWasReached;
            Total += 1;
        }

        private void OnGoalWasReached(IGoal goal)
        {
            goal.WasReached -= OnGoalWasReached;
            Completed++;
            
            GoalWasCompleted?.Invoke();
            if (Completed == Total)
                AllGoalsWasCompleted?.Invoke();
        }
        
    }
}