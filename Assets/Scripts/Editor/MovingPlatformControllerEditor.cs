using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovePlatform))]
public class MovingPlatformControllerEditor : Editor
{
	public override void OnInspectorGUI() {
		MovePlatform controller = (MovePlatform)target;

		controller.waypointObj = (GameObject)EditorGUILayout.ObjectField(
			"Waypoint Object", 
			controller.waypointObj, 
			typeof(GameObject), 
			false);

		controller.movingSpeed = EditorGUILayout.FloatField("Speed: ", controller.movingSpeed);

		EditorGUILayout.LabelField("Waypoints", EditorStyles.boldLabel);

		if (controller.waypoints != null && controller.waypoints.Count != 0) {
			for (int i = 0; i < controller.waypoints.Count; i++) {
				EditorGUILayout.BeginHorizontal();
				controller.waypoints[i].gameObject.name = 
				EditorGUILayout.TextField(controller.waypoints[i].gameObject.name);
				controller.waypoints[i].position = 
				EditorGUILayout.Vector2Field("", controller.waypoints[i].position);
				if (GUILayout.Button("Delete")) {
					// remove specific waypoint
					controller.RemoveWaypoint(i);
				}
				EditorGUILayout.EndHorizontal();
			}

		}

		if (GUILayout.Button("Add Waypoint")) {
			// add new waypoint to the list
			controller.AddNewWaypoint();
		}

		if (GUILayout.Button("Clear Waypoint")) {
			controller.ClearWaypoints();
		}

		// base.OnInspectorGUI();
	}
}
