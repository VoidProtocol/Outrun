using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowTime : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProComponent;

    private void Awake()
    {
        _textMeshProComponent = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _textMeshProComponent.text = Timer.GetTimeCount.ToString();
    }
}
