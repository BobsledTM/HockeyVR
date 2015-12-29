using UnityEngine;
using System.Collections;

public class KeyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Hand")
			c.GetComponent<Grab>().curObject = this.gameObject;
	}

	void OnTriggerExit(Collider c)
	{
		if (c.tag == "Hand")
		{
			this.transform.parent = null;
			c.GetComponent<Grab>().curObject = null;
			this.GetComponent<Rigidbody>().useGravity = true;
			this.GetComponent<Rigidbody>().freezeRotation = false;
		}
	}
	

	// Update is called once per frame
	void Update () {
	
	}
}
