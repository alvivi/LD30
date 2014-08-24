using UnityEngine;
using System.Collections;

public class square : MonoBehaviour {

	public Vector2 punto1;
	public Vector2 punto2;
	public Vector2 punto3;
	public Vector2 punto4;
	
	public float Speed;
	public float rotationSpeed;
	
	public int point = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.position;
		if(point == 1){
			position.y -= Speed * Time.deltaTime;
			if(position.y <= punto2.y) {
				position.y = punto2.y;
				point = 2;
			}
		}
		else if(point == 2){
			position.x += Speed * Time.deltaTime;
			if(position.x >= punto3.x) {
				position.x = punto3.x;
				point = 3;
			}
		}
		else if(point == 3){
			position.y += Speed * Time.deltaTime;
			if(position.y >= punto4.y) {
				position.y = punto4.y;
				point = 4;
			}
		}
		else if(point == 4){
			position.x -= Speed * Time.deltaTime;
			if(position.x <= punto1.x) {
				position.x = punto1.x;
				point = 1;
			}
		}
		
		this.transform.position = position;
		
		this.transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
	}

}
