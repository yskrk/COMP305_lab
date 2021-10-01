using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerWithBuffer : MonoBehaviour
{
	[SerializeField] private Transform player;
	[Range(1.0f, 10.0f)][SerializeField] private float cameraOffsetX = 5.0f;
	[Range(1.0f, 10.0f)][SerializeField] private float cameraOffsetY = 5.0f;

    // Update is called once per frame
    void Update()
    {
		// check the X threshold
		if (player.position.x < transform.position.x - (0.5f * cameraOffsetX)) { // left
			transform.position = new Vector3(
				player.position.x + (0.5f * cameraOffsetX),
				player.position.y,
				player.position.z - 10.0f
			);
		} else if (player.position.x > transform.position.x + (0.5f * cameraOffsetX)) { // right
			transform.position = new Vector3(
				player.position.x - (0.5f * cameraOffsetX),
				player.position.y,
				player.position.z - 10.0f
			);
		}

		// check the Y threshold
		if (player.position.y < transform.position.y - (0.5f * cameraOffsetY)) { // down
			transform.position = new Vector3(
				player.position.x,
				player.position.y + (0.5f * cameraOffsetY),
				player.position.z - 10.0f
			);
		} 
		else 
		if (player.position.y > transform.position.y + (0.5f * cameraOffsetY)) { // up
			transform.position = new Vector3(
				player.position.x,
				player.position.y - (0.5f * cameraOffsetY),
				player.position.z - 10.0f
			);
		}
    }

	private void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position, new Vector3(cameraOffsetX, cameraOffsetY, 0.0f));
	}
}
