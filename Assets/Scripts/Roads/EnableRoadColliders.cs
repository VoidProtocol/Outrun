using UnityEngine;

public class EnableRoadColliders : MonoBehaviour
{
    public void EnableAllRoadColliders()
    {
        foreach (BoxCollider boxCollider in GetComponentsInChildren<BoxCollider>())
        {
            boxCollider.enabled = true;
        }
    }
}
