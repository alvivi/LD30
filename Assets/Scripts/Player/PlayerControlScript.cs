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

	public float deathForce;
	Animator animator;

	bool jumping = false;
	bool canJump = false;
	float jumpingTime = 0f;

	public float canJumpTimer;
	float actualCanJump;

	public bool alive = true;
	bool deathFlag = false;

	int collisions = 0;
	Vector2 velocity;
	// Use this for initialization
	void Start () {
	
		animator = GetComponentsInChildren<Animator> ()[0];
			
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(alive){
			checkControls();
		}
		else if(!deathFlag){
			deathFlag = true;
			velocity = Vector2.zero;
			this.transform.GetComponent<Rigidbody2D>().velocity = velocity;
			this.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * deathForce);
			this.transform.GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	void checkControls () {
		if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){
			animator.SetInteger("animNumber", 1);
			var s = transform.localScale;
			s.x = 1;
			transform.localScale = s;
			this.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * moveForce * Time.fixedDeltaTime);
			Camera.main.GetComponent<CameraScript>().lookRight = true;
		}
		else if(Input.GetKey(KeyCode.A)){
			animator.SetInteger("animNumber", 1);
			var s = transform.localScale;
			s.x = -1;
			transform.localScale = s;
			this.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right*(-1f) * moveForce * Time.fixedDeltaTime);
			Camera.main.GetComponent<CameraScript>().lookRight = false;
		}

		velocity = this.transform.GetComponent<Rigidbody2D>().velocity;
		if (Mathf.Approximately (velocity.x, 0)) {
			animator.SetInteger("animNumber", 0);
		}
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
		if(collisions <= 0f)
			canJump = false;

		if(Input.GetKey(KeyCode.S))
			alive = false;

	}

	void OnCollisionExit2D (Collision2D coll) {
		collisions--;
		if(collisions <= 0f){
			canJump = false;
			if(coll.gameObject.transform.position.y < transform.position.y){
				actualCanJump = canJumpTimer;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if(coll.gameObject.transform.position.y < transform.position.y){
			canJump = true;
		}
		collisions++;
	}

	public void setAlive(bool a) {
		alive = a;
	}

	public void setMinusCollisions() {
		collisions--;
	}
}
