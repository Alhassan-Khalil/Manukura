using UnityEngine;

public class CameraConttol2 : MonoBehaviour
{
    [SerializeField] private Transform target = default;
    [SerializeField] private Vector3 offset = default;
    [SerializeField] [Range(0.01f, 1f)]
    private float smooth = 0.125f;
   
    private Vector3 velocty = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 cameraPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocty, smooth);
    }
}

