using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 target;
    public float smoothing;

    private  int X;

    [SerializeField] private Transform player_location = default;

    private void Start()
    {
        X = 0;
        target = transform.position;
    }


    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if ((player_location.position.x - 23 * Mathf.Abs(X)) < 0)
            {
                target.x -= 23f;
                X--;
            }
            else
            {
                target.x += 23f;
                X++;
            }
        }
    }
    
}
