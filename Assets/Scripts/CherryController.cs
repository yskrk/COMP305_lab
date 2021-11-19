using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
	[SerializeField] private GameObject itemFeedBack;

	private LevelController levelController;

	public void Start() {
		levelController = LevelController.Instance;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			// play item pickup animation
			GameObject.Instantiate(itemFeedBack, this.transform.position, Quaternion.identity);

			// increase player item pickup counter
			levelController.PickedUpItem();

			Destroy(this.gameObject);
		}
	}
}
