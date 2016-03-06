using UnityEngine;
using System.Collections;

public class CharMove : MonoBehaviour {
	Vector3 movetoposition;
	public float speed = 5;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (1)) {
			Vector3 mouseposition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			print (mouseposition);
			moveChar(mouseposition);
		}
		if ((movetoposition - GetComponent<Transform>().position).magnitude < 1){
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

		}
		
	}

	void moveChar(Vector3 mouseposition){
		//movetoposition = mouseposition;
		RaycastHit hitinfo;
		Ray cameraray = Camera.main.ScreenPointToRay(Input.mousePosition);  
		Physics.Raycast (cameraray.origin, cameraray.direction, out hitinfo);
		//print (hitinfo.point);
		GetComponent<Rigidbody> ().velocity = (hitinfo.point-GetComponent<Transform>().position).normalized * speed;
		movetoposition = hitinfo.point;
	}

	
}
