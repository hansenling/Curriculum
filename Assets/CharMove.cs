using UnityEngine;
using System.Collections;

public class CharMove : MonoBehaviour {
	Vector3 movetoposition;
	public float speed = 5;
	private bool skill1 = false;
	private bool skill2 = false;
	public GameObject weapon;
	private float weaponspeed = 20;
	// Use this for initialization
	void Start () {
		print ("stupid change");
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
		if (Input.GetMouseButtonUp (0) && skill1) {
			Vector3 mouseposition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			useSkill1(mouseposition);
		}
		if (Input.GetMouseButtonUp (0) && skill2) {
			Vector3 mouseposition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			useSkill2(mouseposition);
		}
		if (Input.GetKeyDown(KeyCode.Q)){
			skill1 = true;
		}
		if (Input.GetKeyDown(KeyCode.R)){
			skill2 = true;
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

	void useSkill1(Vector3 mouseposition){
		RaycastHit hitinfo;
		Ray cameraray = Camera.main.ScreenPointToRay(Input.mousePosition);  
		Physics.Raycast (cameraray.origin, cameraray.direction, out hitinfo);
		//print (hitinfo.point);
		GetComponent<Rigidbody> ().velocity = (hitinfo.point-GetComponent<Transform>().position).normalized * speed;
		Instantiate (weapon, hitinfo.point + new Vector3(0, 1, 0), Quaternion.identity);
		skill1 = false;
	}

	void useSkill2(Vector3 mouseposition){
		RaycastHit hitinfo;
		Ray cameraray = Camera.main.ScreenPointToRay(Input.mousePosition);  
		Physics.Raycast (cameraray.origin, cameraray.direction, out hitinfo);

		GameObject[] weapons = GameObject.FindGameObjectsWithTag ("weapon");
		foreach (GameObject weapon in weapons){
			weapon.GetComponent<Rigidbody>().velocity = (hitinfo.point-weapon.GetComponent<Transform>().position).normalized * weaponspeed;
		}
		skill2 = false;
	}

}
