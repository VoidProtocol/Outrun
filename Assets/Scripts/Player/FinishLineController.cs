using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    [SerializeField] private float _distanceFromPlayer = 30.0f;

    private void Update()
    {
        if (!GameManager.GetIsGameStartedAtLeastOnce)
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
