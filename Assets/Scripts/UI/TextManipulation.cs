using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextManipulation : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProComponent;

    private void Awake()
    {
        _textMeshProComponent = GetComponent<TextMeshProUGUI>();
    }

    public void GameOverScreenText()
    {
        _textMeshProComponent.text = "Tap to Play Again";
        _textMeshProComponent.rectTransform.anchoredPosition = new Vector3(0.0f, -400.0f, 0.0f);
    }
}

