using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float Speed;
	public float jumpSpeed;
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
		

    void FixedUpdate()
    {
		float jump = 0.0f;
		float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
		bool isJumping = CrossPlatformInputManager.GetButtonDown ("Jump");
		bool isOnGround = rigidBody.velocity.y == 0;

		Vector3 movement = new Vector3 (moveHorizontal, isJumping && isOnGround ? jumpSpeed : 0.0f, moveVertical);
		rigidBody.AddForce (movement * Speed);
    }
		
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Trigger Collision with = " + other.gameObject.name);
		if (other.gameObject.CompareTag("Pickup")) {
			other.gameObject.SetActive (false);
			count++;
			updateCountText ();
		}
	}


	private void updateCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count == 12) {
			winText.text = "You win!";
		}
	}

}