using UnityEngine;

public class Timer : MonoBehaviour
{
    private static float _timeCount = 0.0f;
    private static bool _isTimerWorking = false;

    public static float GetTimeCount { get { return _timeCount; } }

    private void Update()
    {
        if (_isTimerWorking)
        {
            _timeCount += Time.deltaTime;
        }
    }

    public static void TimerClock(TimerFuctions timerFuction)
    {
        switch (timerFuction)
        {
            case TimerFuctions.Start:
                _isTimerWorking = true;
                break;
            case TimerFuctions.Stop:
                _isTimerWorking = false;
                break;
            case TimerFuctions.Reset:
                _timeCount = 0.0f;
                break;
            default:
                Debug.Log("Error: Timer function does not exist");
                break;
        }
    }
}

public enum TimerFuctions
{
    Start = 0,
    Stop = 1,
    Reset = 2
}