using UnityEngine;

public class TrackMovement : MonoBehaviour
{
    private float moveSpeed = 4f;
    public Vector3 moveDirection = Vector3.back;
    private float destroyZ = -20f;

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
