using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private UIManager _uIManager = null;
    [SerializeField] private PlayerCarController _playerCarController = null;

    private static bool _isGameStartedAtLeastOnce = false;
    private static bool _isGameOver = false;

    public static bool GetIsGameStartedAtLeastOnce { get { return _isGameStartedAtLeastOnce; } }

    private void Update()
    {
        if (InputManager.GetTouchTap && !_isGameStartedAtLeastOnce)
        {
            StartGame();
        }
        if (InputManager.GetTouchTap && _isGameOver)
        {
            Restart();
        }
    }

    private void StartGame()
    {
        Timer.TimerClock(TimerFuctions.Start);
        _isGameStartedAtLeastOnce = true;
        _uIManager.StartGameUIElements();
    }

    public void GameOver(WinOrLoss winOrLoss)
    {
        Timer.TimerClock(TimerFuctions.Stop);
        _isGameOver = true;
        _playerCarController.enabled = false;
        _uIManager.GameOverUIElements(winOrLoss);
    }

    private void Restart()
    {
        _isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Timer.TimerClock(TimerFuctions.Reset);
        Timer.TimerClock(TimerFuctions.Start);
    }
}

public enum WinOrLoss
{
    Win = 0,
    Loss = 1
}

