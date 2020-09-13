using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    [SerializeField] private float _distanceFromPlayer;
    [SerializeField] private bool _isGameStarted = false;

    private void Update()
    {
        if (!_isGameStarted)
        {
            MoveFinishLine();
        }
    }

    // Moves finish line away from player
    private void MoveFinishLine()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _distanceFromPlayer + PlayerCarController.GetPlayersCarPosition.z);
    }

}
