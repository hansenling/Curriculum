using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {
	GameObject tracked;
	// Use this for initialization
	void Start () {
		tracked = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myposition = tracked.GetComponent<Transform> ().position + new Vector3 (0, 15, -8);
		GetComponent<Transform> ().position = myposition;
	}
}
