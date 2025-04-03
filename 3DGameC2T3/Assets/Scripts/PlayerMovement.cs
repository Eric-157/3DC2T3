using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required for UI elements

public class PlayerMovement : MonoBehaviour
{
    public GameObject startButton; // Assign the UI button in the Inspector
    public float horizontalSpeed = 4f;
    public float leftBoundry = -3;
    public float rightBoundry = 3;
    private Vector3 targetPosition;
    float duration = 0.2f;
    float lerpTime = 0f;
    private Animator mAnimator;
    public bool alive = true;
    public bool startGame = false;
    private bool isSliding = false;
    private Rigidbody rb;
    public float jumpForce = 5f;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (startGame == true)
        {
            if (!alive)
            {
                mAnimator.SetBool("Run", false);
                return;
            }
            else
            {
                mAnimator.SetBool("Run", true);
                lerpTime += Time.deltaTime;
                float t = Mathf.Clamp(lerpTime / duration, 0f, 1f);

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (transform.position.x >= (leftBoundry + 0.5))
                    {
                        MovePlayer(-3);
                        mAnimator.SetTrigger("MoveLeft");
                    }
                }
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (transform.position.x <= (rightBoundry - 0.5))
                    {
                        MovePlayer(3);
                        mAnimator.SetTrigger("MoveRight");
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (!isSliding)
                    {
                        StartCoroutine(Slide());
                    }
                }
            }
        }
    }

    public void StartGame()
    {
        if (startButton != null)
        {
            startButton.SetActive(false);
        }
        startGame = true;
    }

    void MovePlayer(float direction)
    {
        Vector3 startingPos = transform.position;
        targetPosition = transform.position + new Vector3(direction, 0, 0);
        transform.position = Vector3.Lerp(startingPos, targetPosition, 1);
    }

    void Jump()
    {
        if (Mathf.Approximately(rb.velocity.y, 0))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            mAnimator.SetTrigger("Jump");
        }
    }

    IEnumerator Slide()
    {
        isSliding = true;
        mAnimator.SetTrigger("SlideStart");
        yield return new WaitForSeconds(0.5f);
        mAnimator.SetTrigger("SlideEnd");
        yield return new WaitForSeconds(0.5f);
        isSliding = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }

    void Die()
    {
        alive = false;
        mAnimator.SetTrigger("Die");
    }
}
