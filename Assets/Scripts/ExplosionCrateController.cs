using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCrateController : MonoBehaviour
{
	[SerializeField] private GameObject explosionAnim;
	[SerializeField] private float timeLimit = 3.0f;

	private bool isTouched = false;
	private float currentTime = 0.0f;
	private Animator anim;

	private void Start() {
		anim = GetComponent<Animator>();
	}

	void Update() {
		// count timer then explode
		if (isTouched) {
			anim.SetBool("isTouched", isTouched);
			currentTime = currentTime + Time.deltaTime;

			if (currentTime >= timeLimit) {
				GameObject.Instantiate(explosionAnim, this.transform.position, Quaternion.identity);
				Destroy(this.gameObject);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		// Debug.Log("player touch crate");
		if (other.gameObject.tag == "Player") {
			isTouched = true;
		}
	}
}
