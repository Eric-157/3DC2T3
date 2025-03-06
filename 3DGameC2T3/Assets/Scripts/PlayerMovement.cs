using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalSpeed = 4f;
    public float leftBoundry = -3;
    public float rightBoundry = 3;
    private Vector3 targetPosition;
    float duration = 1f;
    float lerpTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lerpTime += Time.deltaTime;
        float t = Mathf.Clamp(lerpTime / duration, 0f, 1f);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x >= (leftBoundry + 0.5))
            {
                //transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
                //transform.position += new Vector3(-3, 0, 0);
                //transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-3, 0, 0), horizontalSpeed * Time.deltaTime);
                Vector3 startingPos = transform.position;
                targetPosition = transform.position + new Vector3(-3, 0, 0);
                transform.position = Vector3.Lerp(startingPos, targetPosition, t);
                // StartCoroutine(MoveToTarget());
            }

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x <= (rightBoundry - 0.5))
            {
                //transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
                //transform.position += new Vector3(3, 0, 0);
                //transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(3, 0, 0), horizontalSpeed * Time.deltaTime);
                // StartCoroutine(MoveToTarget());
                Vector3 startingPos = transform.position;
                targetPosition = transform.position + new Vector3(3, 0, 0);
                transform.position = Vector3.Lerp(startingPos, targetPosition, t);
            }

        }
    }
    // IEnumerator MoveToTarget()
    // {

    //     Vector3 startingPos = transform.position;
    //     while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
    //     {
    //         transform.position = Vector3.Lerp(startingPos, targetPosition, t);
    //         yield return null;
    //     }
    // }
}
