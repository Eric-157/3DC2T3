using UnityEngine;

public class TrackMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 moveDirection = Vector3.back;
    public float destroyZ = -20f;

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
