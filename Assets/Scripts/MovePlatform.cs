using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
	// [SerializeField] private float movingLength = 5.0f;
	[SerializeField] public float movingSpeed = 5.0f;
	// [SerializeField] private bool isHorizontal = true;

	// private Rigidbody2D rbPlatform;
	// private Vector2 defaultPosition;

	/*---COMP305 week 9 start---*/
	public GameObject waypointObj;
	public List<Transform> waypoints;
	private int currentTargetIndex = 0;
	/*---COMP305 week 9 end---*/

	// void Start()
	// {
	// 	rbPlatform = GetComponent<Rigidbody2D>();
	// 	defaultPosition = transform.position;
	// }

	/*---COMP305 week 9 start---*/
	private void Awake() {
		waypoints = new List<Transform>();
		foreach (Transform t in transform.parent.GetChild(1)) {
			waypoints.Add(t);
		}

		if (waypoints.Count > 0) {
			transform.position = waypoints[0].position;
		}
	}

	void Update() {
		if (waypoints.Count > 1) {
			transform.position = Vector2.MoveTowards(transform.position, waypoints[currentTargetIndex].position, Time.deltaTime * movingSpeed);

			if (Vector2.Distance(transform.position, waypoints[currentTargetIndex].position) < 0.01f) {
				// change target
				currentTargetIndex = (currentTargetIndex + 1) % waypoints.Count;
			}
		}
	}

	// for editor
	public void AddNewWaypoint() {
		GameObject gObj = Instantiate(waypointObj, Vector2.zero, Quaternion.identity);
		gObj.transform.SetParent(transform.parent.GetChild(1));
		gObj.name = "Waypoint " + waypoints.Count;
		waypoints.Add(gObj.transform);
	}

	public void RemoveWaypoint(int index) {
		waypoints.RemoveAt(index);
		// waypoints.TrimExcess();
		DestroyImmediate(transform.parent.GetChild(1).GetChild(index).gameObject);
	}

	public void ClearWaypoints() {
		for (int i = 0; i < waypoints.Count; i++) {
			DestroyImmediate(waypoints[i].gameObject);
		}

		waypoints.Clear();
	}
	/*---COMP305 week 9 end---*/

	// void FixedUpdate()
	// {
	// 	if (isHorizontal) {
	// 		transform.position = new Vector2(defaultPosition.x + Mathf.PingPong(Time.time * movingSpeed, movingLength), defaultPosition.y);
	// 	} else {
	// 		transform.position = new Vector2(defaultPosition.x, defaultPosition.y + Mathf.PingPong(Time.time * movingSpeed, movingLength));
	// 	}
	// }
}
