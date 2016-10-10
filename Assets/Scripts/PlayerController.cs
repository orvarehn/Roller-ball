using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rigidBody;
	private int count = 0;
	public Text countText;
	public Text winText;

	//public VirtualJoystick joystick;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
		updateCountText ();
		winText.text = "";
	}

	// Update is called once per frame
	void Update () {
	
	}

    // Use this for initialization
    void FixedUpdate()
    {
		float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");;
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidBody.AddForce (movement * speed);
    }
		
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Trigger Collision with = " + other.gameObject.name);
		if (other.gameObject.CompareTag("Pickup")) {
			other.gameObject.SetActive (false);
		}
	}


	private void updateCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count == 12) {
			winText.text = "You win!";
		}
	}

}