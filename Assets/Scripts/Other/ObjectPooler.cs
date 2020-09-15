using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public PoolObject poolObject;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<PoolObject, Queue<GameObject>> poolDictionary;

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;

        poolDictionary = new Dictionary<PoolObject, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.poolObject, objectPool);
        }
    }

    public GameObject SpawnFromPool(PoolObject poolObject, Vector3 position, Quaternion rotation, string newTag)
    {
        if (!poolDictionary.ContainsKey(poolObject))
        {
            Debug.LogWarning($"Pool with name {poolObject} doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[poolObject].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.tag = newTag;
        objectToSpawn.SetActive(true);

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        poolDictionary[poolObject].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}

public enum PoolObject
{
    Car1 = 0,
    Car2 = 1,
    Car3 = 2,
    CarTaxi = 3,
    Bus1 = 4,
    Bus2 = 5,
    Building1 = 6,
    Building2 = 7,
    Building3 = 8,
    Building4 = 9,
    Building5 = 10,
}
