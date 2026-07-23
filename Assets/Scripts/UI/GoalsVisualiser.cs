using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GoalsVisualiser : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject background;

        private Goals.Goals _goals;

        public void Init(Goals.Goals goals)
        {
            _goals = goals;
            enabled = true;
        }

        private void OnGoalWasCompleted()
        {
            slider.value = _goals.Completed / (float)_goals.Total;
            background.SetActive(true);
        }

        private void OnEnable()
        {
            _goals.GoalWasCompleted += OnGoalWasCompleted;
        }

        private void OnDisable()
        {
            _goals.GoalWasCompleted -= OnGoalWasCompleted;
        }
    }
}