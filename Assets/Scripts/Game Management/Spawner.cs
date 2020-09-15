using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Config:")]
    [SerializeField] private float _chanceforObjectToSpawn = 40.0f;
    [SerializeField] private float _leftLaneCarMinSpawnRate = 1.0f;
    [SerializeField] private float _leftLaneCarMaxSpawnRate = 5.0f;
    [SerializeField] private PoolObject _firstPoolObject = PoolObject.Car1;
    [SerializeField] private PoolObject _lastPoolObject = PoolObject.Bus2;
    [SerializeField] private bool _isThisLeftLaneCarSpawner = false;

    private ObjectPooler _objectPooler;

    private void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        _objectPooler = ObjectPooler.Instance;

        ChanceToSpawn();

        transform.hasChanged = false;

        if (_isThisLeftLaneCarSpawner)
        {
            InvokeRepeating(ConstLibrary.ChanceToSpawn, 1.0f,
                Random.Range(_leftLaneCarMinSpawnRate, _leftLaneCarMaxSpawnRate));
        }
    }

    private void Update()
    {
        if (transform.hasChanged && !_isThisLeftLaneCarSpawner)
        {
            ChanceToSpawn();
            transform.hasChanged = false;
        }
    }

    private void ChanceToSpawn()
    {
        string newTag = ConstLibrary.EnemyCarRightLane;

        if (_isThisLeftLaneCarSpawner)
        {
            newTag = ConstLibrary.EnemyCarLeftLane;
        }

        PoolObject nextpoolObject = (PoolObject)Random.Range((int)_firstPoolObject, (int)_lastPoolObject);

        if (_chanceforObjectToSpawn >= Random.Range(0.0f, 100.0f))
        {
            _objectPooler.SpawnFromPool(nextpoolObject, transform.position, transform.rotation, newTag);
        }
    }
}
