using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlatformController : MonoBehaviour
{
	[SerializeField] private float rotationDuration = 5.0f;
	[SerializeField] private float rotationSpeedFactor = 1.5f;
	[SerializeField] private float FlippedPosZ1 = 0.0f;
	[SerializeField] private float FlippedPosZ2 = 180.0f;

	private bool isRotated = false;
	private bool isPlayerOn = false;
	private float rotationTimer;

    // Start is called before the first frame update
    void Start()
    {
        rotationTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
		// stop rotation during player on the platform
		// if (!isPlayerOn) {
		if (true) {
			// increase timer
			rotationTimer = rotationTimer + Time.deltaTime;

			if (rotationTimer >= rotationDuration) {
				// flip
				transform.Rotate(
					new Vector3(
						transform.rotation.x,
						transform.rotation.y,
						FlippedPosZ2) * (Time.deltaTime * rotationSpeedFactor));

				if (isRotated && transform.rotation.z > 0.1f) {
					// Debug.Log("platrorm is flipped again");
					StopRotation(FlippedPosZ1);
				}

				if (!isRotated && transform.rotation.z < 0.0f) {
					// Debug.Log("platrorm is flipped");
					StopRotation(FlippedPosZ2);
				}
			}
		}
    }

	private void StopRotation(float finalRot) {
		// ajust z rotation
		transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, finalRot);
		isRotated = !isRotated;
		rotationTimer = 0.0f;
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			isPlayerOn = true;
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			isPlayerOn = false;
		}
	}
}
