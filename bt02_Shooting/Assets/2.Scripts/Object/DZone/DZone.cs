using UnityEngine;

public class DZone : MonoBehaviour
{
    public LayerMask mask;

    private void Awake()
    {
        mask = 1 << 7 | 1 << 8 | 1 << 9;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((1 << other.gameObject.layer & mask) != 0)
        {
            Destroy(other.gameObject);
        }
    }
}
