using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	}

	// privates
	private int totalItemsQty = 0, itemsCollectedQty = 0;

	// public
	[SerializeField] private Text intemUIText;

    // Start is called before the first frame update
    void Start()
    {
        totalItemsQty = GameObject.FindGameObjectsWithTag("Item").Length;
		// Debug.Log("total items: " + totalItemsQty);
		UpdateItemUI();
    }

	private void UpdateItemUI() {
		intemUIText.text = itemsCollectedQty + " / " + totalItemsQty;
	}

	public void PickedUpItem() {
		itemsCollectedQty++;
		// Debug.Log(itemsCollectedQty + " item is collected");
		UpdateItemUI();
	}

	public void CheckLevelEnd() {
		if (itemsCollectedQty == totalItemsQty) {
			// go to next level
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  + 1);
		}
	}
}
