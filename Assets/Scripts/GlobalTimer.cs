using System;
using UnityEngine;

public class GlobalTimer: MonoBehaviour
{
    [field: SerializeField] public float TotalTime { private set; get; }

    public float PassedTime { private set; get; } = 0;

    public float RemainingTime => TotalTime - PassedTime;

    public event Action<int, int> SecondsHadChanged; 
    public event Action TimeHadPassed; 

    private int _lastSeconds = 0;

    public void AddTime(float time)
    {
        PassedTime += time;
    }
    
    private void Update()
    {
        if (RemainingTime <= 0)
            return;
        
        PassedTime += Time.deltaTime;
        
        if (RemainingTime <= 0)
            TimeHadPassed?.Invoke();
        
        var seconds = (int)(RemainingTime % 60);
        if (seconds != _lastSeconds)
            SecondsHadChanged?.Invoke(seconds, (int)(RemainingTime / 60));

        _lastSeconds = seconds;
    }
}