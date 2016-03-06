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
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 30, 0);
		Invoke ("deleteSelf", 1);
	}
	public void deleteSelf(){
		this.gameObject.SetActive (false);
	}
}

