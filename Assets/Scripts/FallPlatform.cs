using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
	// valiables on inspector
	[SerializeField] private GameObject sprite;
	[SerializeField] private GameObject player;
	[SerializeField] private float vibrationWidth = 0.05f;
	[SerializeField] private float vibrationSpeed = 30.0f;
	[SerializeField] private float fallTime = 1.0f;
	[SerializeField] private float fallSpeed = 10.0f;

	// private valiables
	private bool isOnPlayer;
	private bool isFall;
	private Vector2 spriteDefaultPos;		// position for Sprite
	private Vector2 platformDefaultPos;		// position for GameObject
	private Vector2 fallVelociity;
	private BoxCollider2D col;
	private Rigidbody2D rbPlatform;
	private SpriteRenderer srPlatfrom;
	private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
		rbPlatform = GetComponent<Rigidbody2D>();

		if (sprite != null && col !=null && rbPlatform != null) {
			spriteDefaultPos = sprite.transform.position;
			fallVelociity = new Vector2(0, -fallSpeed);
			platformDefaultPos = gameObject.transform.position;
			srPlatfrom = sprite.GetComponent<SpriteRenderer>();

			if (srPlatfrom == null) {
				Destroy(this);
			}
		} else {
				Destroy(this);
		}
    }

    // Update is called once per frame
    void Update()
    {
        // check player on the floor
		if (isOnPlayer && !isFall) {
			// action falling floor
			sprite.transform.position = spriteDefaultPos + new Vector2(Mathf.Sin(timer * vibrationSpeed) * vibrationWidth, 0.0f);

			if (timer > fallTime) {
				isFall = true;
			}

			timer += Time.deltaTime;
		}
    }

	private void FixedUpdate() {
		// process during falling
		if (isFall) {
			rbPlatform.velocity = fallVelociity;
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.position.y >= transform.position.y && other.gameObject.tag == "Player") {
			// Debug.Log("player on the platform");
			isOnPlayer = true;
		}
	}
}
