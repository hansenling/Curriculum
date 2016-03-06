using UnityEngine;
using System.Collections;

public class weaponScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Eliminate(){
		print ("HERE@");
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 30, 0);
		Destroy (this, 1);
	}
}
