using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {



	public float moveForce;
	public float horizontalSpeed;
	public float jumpForce;
	public float jumpContinueForce;
	public float jumpMinusContinueForce;
	float jumpActualForce;
	public float jumpTime;

	bool jumping = false;
	bool canJump = false;
	float jumpingTime = 0f;

	public float canJumpTimer;
	float actualCanJump;

	bool alive = true;

	public int collisions = 0;
	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(alive){
			checkControls();
		}
	}

	void checkControls () {
		if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){
			this.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * moveForce * Time.fixedDeltaTime);
			Camera.main.GetComponent<CameraScript>().lookRight = true;
		}
		else if(Input.GetKey(KeyCode.A)){
			this.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right*(-1f) * moveForce * Time.fixedDeltaTime);
			Camera.main.GetComponent<CameraScript>().lookRight = false;
		}

		Vector2 velocity = this.transform.GetComponent<Rigidbody2D>().velocity;
		if(velocity.x >= horizontalSpeed)
			velocity.x = horizontalSpeed;
		if(velocity.x <= -horizontalSpeed)
			velocity.x = -horizontalSpeed;

		this.transform.GetComponent<Rigidbody2D>().velocity = velocity;

		if(Input.GetKeyDown(KeyCode.W) && (canJump || actualCanJump >= 0f)){
			velocity = this.transform.GetComponent<Rigidbody2D>().velocity;
			velocity.y = 0f;
			this.transform.GetComponent<Rigidbody2D>().velocity = velocity;
			this.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
			jumping = true;
			jumpActualForce = jumpContinueForce;
		}

		if(Input.GetKey(KeyCode.W) && jumping){
			this.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpActualForce * Time.fixedDeltaTime);
			jumpActualForce -= jumpMinusContinueForce * Time.fixedDeltaTime;
			if(jumpActualForce <= 0f)
				jumpActualForce= 0f;
		}

		if(jumping){
			jumpingTime += Time.deltaTime;
			if(jumpingTime >= jumpTime){
				jumpingTime = 0f;
				jumping = false;
			}
		}

		actualCanJump -= Time.fixedDeltaTime;

	}

	void OnCollisionExit2D () {
		collisions--;
		if(collisions <= 0){
			canJump = false;
			actualCanJump = canJumpTimer;
		}
	}

	void OnCollisionEnter2D () {
		canJump = true;
		collisions++;
	}

	public void setAlive(bool a) {
		alive = a;
	}

	public void setMinusCollisions() {
		collisions--;
	}
}
