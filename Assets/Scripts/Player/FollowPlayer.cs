using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private bool _FollowPlayerByXAxis = false;
    [SerializeField] private bool _FollowPlayerByZAxis = false;
    [SerializeField] private Vector3 _offset = Vector3.zero;

    private void Update()
    {
        if (_FollowPlayerByXAxis && !_FollowPlayerByZAxis)
        {
            transform.position = new Vector3(PlayerCarController.GetPlayersCarPosition.x + _offset.x,
                transform.position.y, transform.position.z);
        }

        if (!_FollowPlayerByXAxis && _FollowPlayerByZAxis)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                PlayerCarController.GetPlayersCarPosition.z + _offset.z);
        }

        if (_FollowPlayerByXAxis && _FollowPlayerByZAxis)
        {
            transform.position = new Vector3(PlayerCarController.GetPlayersCarPosition.x + _offset.x,
                transform.position.y, PlayerCarController.GetPlayersCarPosition.z + _offset.z);
        }
    }
}
