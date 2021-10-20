using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
	public float scrollSpeed = 0.05f;

	private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
		InvokeRepeating("MoveBG", scrollSpeed, scrollSpeed);	// 指定したメソッド(1)を指定時間毎(2)に繰り返しレート(3)に従って叩く
    }

	private void MoveBG() {
        renderer.material.mainTextureOffset = new Vector2(renderer.material.mainTextureOffset.x + 0.05f, 0);
	}

    // Update is called once per frame
    void Update()
    {
        // renderer.material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0);
    }
}
