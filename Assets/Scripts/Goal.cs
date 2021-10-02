using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        goal.SetActive(false);
    }

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.name == player.name) {
			goal.GetComponent<Text>();
			goal.SetActive(true);
			player.SetActive(false);
		}
	}
}
