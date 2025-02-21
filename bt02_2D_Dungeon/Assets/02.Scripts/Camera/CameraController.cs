using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    private Transform target;

    private float offsetZ = -10f;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if(target == null)
        {
            target = Object.FindAnyObjectByType<PlayerController>().transform;
        }

        Vector3 destination = new Vector3(target.position.x, target.position.y, offsetZ);
        cam.transform.position = Vector3.Lerp(transform.position, destination, 0.5f);
    }
}
