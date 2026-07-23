using Goals;
using UI;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [Header("Initers")]
    [SerializeField] private BarrelIniter barrelIniter;
    [SerializeField] private RemainingTimeVisualiser remainingTimeVisualiser;
    [SerializeField] private GoalsVisualiser goalsVisualiser;
    
    [Header("Stuff")]
    [SerializeField] private Transform barrelConnecterTarget;
    [SerializeField] private GlobalTimer globalTimer;
    
    [Header("Goals")]
    [SerializeField] private FuelFillingGoal fuelFillingGoal;

    private Goals.Goals _goals = new Goals.Goals();

    private void Start()
    {
        barrelIniter.Init(barrelConnecterTarget);
        fuelFillingGoal.Init(barrelIniter.Connector);
        
        remainingTimeVisualiser.Init(globalTimer);
        goalsVisualiser.Init(_goals);
        
        _goals.Register(fuelFillingGoal);
    }

    private void OnTimeHadPassed()
    {
        if (_goals.Completed == _goals.Total)
        {
            SceneSwitcher.GoToWinScene();
            return;
        }

        SceneSwitcher.GoToNotWinScene();
    }

    private void OnAllGoalsWasCompleted()
    {
        if (globalTimer.RemainingTime <= 10)
            return;
        
        globalTimer.AddTime(globalTimer.RemainingTime - 10);
    }

    private void OnEnable()
    {
        globalTimer.TimeHadPassed += OnTimeHadPassed;
        _goals.AllGoalsWasCompleted += OnAllGoalsWasCompleted;
    }
    
    private void OnDisable()
    {
        globalTimer.TimeHadPassed -= OnTimeHadPassed;
        _goals.AllGoalsWasCompleted -= OnAllGoalsWasCompleted;
    }
}