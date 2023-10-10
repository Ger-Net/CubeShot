using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CubeFallDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Cube cube))
            Destroy(other.gameObject);
    }
}
