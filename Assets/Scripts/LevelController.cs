using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class LevelController : MonoBehaviour
{
	// Singleton pattern
	private static LevelController _instance;
	public static LevelController Instance {
		get {
			return _instance;
			}
	}

	private void Awake() {
		if (_instance != null && _instance != this) {
			Destroy(this.gameObject);
		}
		else {
			_instance = this;
		}

		pDir.enabled = false;
	}

	// privates
	private int totalItemsQty = 0, itemsCollectedQty = 0;

	// public
	[SerializeField] private Text itemUIText;
	[SerializeField] private PlayableDirector pDir;

    // Start is called before the first frame update
    void Start()
    {
        totalItemsQty = GameObject.FindGameObjectsWithTag("Item").Length;
		// Debug.Log("total items: " + totalItemsQty);
		UpdateItemUI();
    }

	private void UpdateItemUI() {
		itemUIText.text = itemsCollectedQty + " / " + totalItemsQty;
	}

	public void PickedUpItem() {
		itemsCollectedQty++;
		// Debug.Log(itemsCollectedQty + " item is collected");
		UpdateItemUI();
	}

	public void CheckLevelEnd() {
		if (checkItemCount()) {
			// play ana animation of the character jumping up and down

			// play level end audio
			Camera.main.gameObject.GetComponent<AudioSource>().Stop();

			// show level end UI
			pDir.enabled = true;
		}
	}

	public bool checkItemCount() {
		bool isCorrected = false;
		if (itemsCollectedQty == totalItemsQty) {
			isCorrected = true;
		}

		return isCorrected;
	}
}
