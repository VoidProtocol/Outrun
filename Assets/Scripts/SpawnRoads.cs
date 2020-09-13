using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRoads : MonoBehaviour
{
    [SerializeField] private List<GameObject> _roads;
    [SerializeField] private float _offset = 30.0f;

    private void Awake()
    {
        if (_roads != null && _roads.Count > 0)
        {
            _roads = _roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    private void MoveRoad()
    {
        GameObject movedRoad = _roads[0];
        _roads.Remove(movedRoad);

        float roadZPosition = _roads[_roads.Count - 1].transform.position.z + _offset;
        movedRoad.transform.position = new Vector3(0.0f, 0.0f, roadZPosition);
        _roads.Add(movedRoad);
    }

    public void SpawnTriggerEntered()
    {
        MoveRoad();
    }
}
