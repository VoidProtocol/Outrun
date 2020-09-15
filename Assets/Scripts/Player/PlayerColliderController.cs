using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerColliderController : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameManager _gameManager = null;
    [SerializeField] private SpawnRoads _spawnRoads = null;
    [SerializeField] private EnableRoadColliders _enableRoadColliders = null;

    private Rigidbody _rigidbody;
    private Rigidbody _collidedRigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.parent != null)
        {
            if (collider.transform.parent.name == ConstLibrary.Roads)
            {
                // Move last road foward
                _spawnRoads.SpawnTriggerEntered();
            }
        }
        if (collider.transform.name == ConstLibrary.FinishLine)
        {
            _gameManager.GameOver(WinOrLoss.Win);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out _collidedRigidbody) && 
            collision.gameObject.CompareTag(ConstLibrary.EnemyCarLeftLane))
        {
            _enableRoadColliders.EnableAllRoadColliders();

            _rigidbody.useGravity = true;
            _rigidbody.constraints = RigidbodyConstraints.None;

            _collidedRigidbody.useGravity = true;
            _collidedRigidbody.constraints = RigidbodyConstraints.None;

            _gameManager.GameOver(WinOrLoss.Loss);
        }
    }
}