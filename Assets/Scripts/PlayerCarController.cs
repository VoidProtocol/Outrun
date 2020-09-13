using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCarController : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private SpawnRoads _spawnRoads;
    [Header("Config:")]
    [SerializeField] private float _carDefaultSpeed = 200.0f;
    [SerializeField] private float _carMaxSpeed = 600.0f;
    [SerializeField] private float _carAccelerationMultiply = 1.02f;
    [SerializeField] private float _carSlowingMultiply = 1.06f;
    [SerializeField] private float _turningMaxSpeed = 400.0f;
    [SerializeField] private float _turningAccelerationMultiply = 1.1f;
    [SerializeField] private float _leftLaneDefaultPosition = -1.0f;
    [SerializeField] private float _rightLaneDefaultPosition = 1.0f;

    private static Vector3 _playersCarPosition;
    private static float _currentCarSpeed;
    private static bool _isScreenTouched = false;
    private Rigidbody _rigidbody;
    private float _currentTurningSpeed = 0.0f;

    public static Vector3 GetPlayersCarPosition { get { return _playersCarPosition; } }
    public static float GetCarSpeed { get { return _currentCarSpeed; } }
    public static bool GetIsScreenTouched { get { return _isScreenTouched; } }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentCarSpeed = _carDefaultSpeed;
    }

    private void Update()
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

    private void FixedUpdate()
    {
        _playersCarPosition = _rigidbody.position;

        if (_isScreenTouched)
        {
            CarTurning(DirectionOfCarTurning.Left);
            CarAccelerating();
        }
        else
        {
            CarTurning(DirectionOfCarTurning.Right);
            CarSlowing();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.parent.name == ConstLibrary.Roads)
        {
            // Move last road foward
            _spawnRoads.SpawnTriggerEntered();
        }
    }

    private void CarTurning(DirectionOfCarTurning directionOfCarTurning)
    {
        if (directionOfCarTurning == DirectionOfCarTurning.Left && _leftLaneDefaultPosition < _playersCarPosition.x)
        {
            if (_currentTurningSpeed < _turningMaxSpeed)
            {
                _currentTurningSpeed = (_currentTurningSpeed + 10.0f) * _turningAccelerationMultiply;
            }

            _rigidbody.velocity = new Vector3(-_currentTurningSpeed, 0.0f, _currentCarSpeed) * Time.deltaTime;
        }
        else if (directionOfCarTurning == DirectionOfCarTurning.Right && _rightLaneDefaultPosition > _playersCarPosition.x)
        {
            if (_currentTurningSpeed < _turningMaxSpeed)
            {
                _currentTurningSpeed = (_currentTurningSpeed + 10.0f) * _turningAccelerationMultiply;
            }

            _rigidbody.velocity = new Vector3(_currentTurningSpeed, 0.0f, _currentCarSpeed) * Time.deltaTime;
        }
        else
        {
            _currentTurningSpeed = 0.0f;
            _rigidbody.velocity = new Vector3(_currentTurningSpeed, 0.0f, _currentCarSpeed) * Time.deltaTime;
        }
    }

    private void CarAccelerating()
    {
        _currentCarSpeed *= _carAccelerationMultiply;

        if (_currentCarSpeed > _carMaxSpeed)
        {
            _currentCarSpeed = _carMaxSpeed;
        }

        _rigidbody.velocity = new Vector3(-_currentTurningSpeed, 0.0f, _currentCarSpeed) * Time.deltaTime;
    }

    private void CarSlowing()
    {
        _currentCarSpeed /= _carSlowingMultiply;

        if (_currentCarSpeed < _carDefaultSpeed)
        {
            _currentCarSpeed = _carDefaultSpeed;
        }

        _rigidbody.velocity = new Vector3(_currentTurningSpeed, 0.0f, _currentCarSpeed) * Time.deltaTime;
    }

    private enum DirectionOfCarTurning
    {
        Left = 0,
        Right = 1
    }
}
