using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static bool _isScreenTouched = false;

    public static bool GetTouchPress { get { return _isScreenTouched; } }

    private void Update()
    {
        CheckTouchPress();
    }

    private static void CheckTouchPress()
    {
        if (Input.touchCount > 0 || Input.GetKey("a"))
        {
            _isScreenTouched = true;
        }
        else
        {
            _isScreenTouched = false;
        }
    }
}

