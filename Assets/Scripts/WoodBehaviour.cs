using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBehaviour : MonoBehaviour
{
	[SerializeField]private Transform player;

	private Rigidbody2D rWood;

	void Start() {
		rWood = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		if (player.transform.position.x > 11.0f) {
			rWood.bodyType = RigidbodyType2D.Dynamic;
		}
	}
}
