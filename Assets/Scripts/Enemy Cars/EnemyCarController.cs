using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyCarController : MonoBehaviour
{
    [Header("Config:")]
    [SerializeField] float _enemyCarSpeed = 500.0f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (CompareTag(ConstLibrary.EnemyCarLeftLane))
        {
            _enemyCarSpeed *= -2.0f;
            _rigidbody.mass = 1.0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag(ConstLibrary.EnemyCarRightLane) && 
            collision.gameObject.CompareTag(ConstLibrary.EnemyCarRightLane))
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(0.0f, 0.0f, _enemyCarSpeed) * Time.deltaTime;
    }
}
