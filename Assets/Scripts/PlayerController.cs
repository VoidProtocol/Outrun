using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Config:")]
    [SerializeField] private float _carSpeed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(0.0f, 0.0f, _carSpeed) * Time.deltaTime);
    }
}
