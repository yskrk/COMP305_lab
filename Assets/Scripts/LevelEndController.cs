using UnityEngine;

public class LevelEndController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			LevelController.Instance.CheckLevelEnd();
		}
	}
}
