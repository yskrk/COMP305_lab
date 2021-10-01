using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private Transform moveThreshould;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x > moveThreshould.position.x) {
			// camera follows the player
			transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
		}
    }

	// show gizmo with line in Scene (can be shown when game is running)
	private void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(
			new Vector2(moveThreshould.position.x, moveThreshould.position.y + 10),
			new Vector2(moveThreshould.position.x, moveThreshould.position.y - 10)
		);
	}
}
