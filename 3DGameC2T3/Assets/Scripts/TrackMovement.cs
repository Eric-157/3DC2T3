using UnityEngine;

public class TrackMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Editable speed value
    public Vector3 moveDirection = Vector3.back; // Editable movement direction
    public float destroyZ = -20f; // Editable destroy threshold

    void Update()
    {
        // Move the track in the given direction at the given speed
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Destroy the track when it moves past the specified Z value
        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
