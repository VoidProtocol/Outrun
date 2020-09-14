using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = Vector3.zero;

    private void Update()
    {
        transform.position = PlayerCarController.GetPlayersCarPosition + _offset;
    }
}
