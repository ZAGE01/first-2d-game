using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainCode : MonoBehaviour
{
    private float speed = 3f;
    private bool facingRight = true;
    private float jumpForce = 4.5f;
    private bool onGround = true;
    private Animator animator;
    private GameObject koodit = null;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.koodit = GameObject.Find("codestorage");
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the character on x-axis
        if (Input.GetKey(KeyCode.A))
        {
            // Run animation
            if (onGround)
            {
                animator.SetInteger("state", 1);
            }
            if (facingRight)
            {
                this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
                facingRight = false;
            }
            transform.Translate(Vector3.left * -speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            // Back to idle animation
            animator.SetInteger("state", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Run animation
            if(onGround)
            {
                animator.SetInteger("state", 1);
            }
            if (!facingRight)
            {
                this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
                facingRight = true;
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            // Back to idle animation
            animator.SetInteger("state", 0);
        }
        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            animator.SetInteger("state", 4);
            GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
            onGround = false; // Set grounded to false when jumping
        }

        // Pys‰yt‰ pelaaja reunalla
        float clampedX = Mathf.Clamp(transform.position.x, -8.3f, 8.3f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }

        onGround = true;

        if (collision.gameObject.CompareTag("Mouse"))
        {
            Debug.Log("Collected!");
            this.koodit.GetComponent<points>().collectibles += 1;
            // Soitetaan ‰‰niefekti
            GameObject.Find("sounds").GetComponents<AudioSource>()[1].Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Finished!");
            SceneManager.LoadScene("gameover");
        }
    }
}
