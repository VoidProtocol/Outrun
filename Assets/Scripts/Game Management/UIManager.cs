using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _timeInGameUI = null;
    [SerializeField] private GameObject _speedometerUI = null;
    [SerializeField] private GameObject _gameOverWinUI = null;
    [SerializeField] private GameObject _gameOverLossUI = null;
    [SerializeField] private GameObject _timeScoreUI = null;
    [SerializeField] private GameObject _tapToPlayUI = null;

    private void Awake()
    {
        if (GameManager.GetIsGameStartedAtLeastOnce)
        {
            StartGameUIElements();
        }
    }

    public void StartGameUIElements()
    {
        _gameOverWinUI.SetActive(false);
        _gameOverLossUI.SetActive(false);
        _tapToPlayUI.SetActive(false);
        _timeScoreUI.SetActive(false);
        _timeInGameUI.SetActive(true);
        _speedometerUI.SetActive(true);
    }

    public void GameOverUIElements(WinOrLoss winOrLoss)
    {
        _timeInGameUI.SetActive(false);
        _speedometerUI.SetActive(false);
        _tapToPlayUI.SetActive(true);

        _tapToPlayUI.GetComponent<TextManipulation>().GameOverScreenText();

        if (winOrLoss == WinOrLoss.Win)
        {
            _gameOverWinUI.SetActive(true);
            _timeScoreUI.SetActive(true);
        }
        else
        {
            _gameOverLossUI.SetActive(true);
        }
    }
}