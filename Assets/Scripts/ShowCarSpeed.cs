using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowCarSpeed : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProComponent;

    private void Awake()
    {
        _textMeshProComponent = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _textMeshProComponent.text = PlayerCarController.GetCarSpeed.ToString();
    }
}
