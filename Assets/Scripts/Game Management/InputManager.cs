using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static bool _isScreenTapped = false;
    private static bool _isScreenTouched = false;

    public static bool GetTouchTap { get { return _isScreenTapped; } }
    public static bool GetTouchPress { get { return _isScreenTouched; } }

    private void Update()
    {
        CheckTouchTap();
        CheckTouchPress();
    }
    private static void CheckTouchTap()
    {
        if ((Input.touchCount > 0) || Input.GetKeyDown("s"))
        {
            _isScreenTapped = true;
        }
        else
        {
            _isScreenTapped = false;
        }
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

