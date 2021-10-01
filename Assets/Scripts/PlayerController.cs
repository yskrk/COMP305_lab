using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	// "public" vals
	[SerializeField] private float speed = 10.0f;
	[SerializeField] private float jumpForce = 500.0f;
	[SerializeField] private float groundCheckRadius = 0.1f;
	[SerializeField] private Transform groundCheckPos;
	[SerializeField] private LayerMask whatIsGround;

	// private vals
	private Rigidbody2D rBody;
	private bool isGrounded = false;
	private float isDieByFall = -8.0f;
	

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

	// physics
	private void FixedUpdate() {
		float horiz = Input.GetAxis("Horizontal");
		isGrounded = GroundCheck();

		// jump code here
		if (isGrounded && Input.GetAxis("Jump") > 0) {
			rBody.AddForce(new Vector2(0.0f, jumpForce));
			isGrounded = false;
		}

		rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

		// die by fall
		if (transform.position.y < isDieByFall) {
			// reset scene
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	private bool GroundCheck() {
		return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.tag == "Hazard") {
			// reset scene
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
