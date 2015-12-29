using UnityEngine;
using System.Collections;

public class KeyInsert : MonoBehaviour {
	

	public Transform targetLoc;
	public bool used = false;


	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Ignition" && !used)
		{
			this.transform.parent.parent = null;
			this.transform.parent.GetComponent<Rigidbody>().freezeRotation = false;
			this.transform.parent.position = targetLoc.position;
			this.transform.parent.localRotation = targetLoc.localRotation;
			this.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
			this.transform.parent.GetComponent<Collider>().enabled = false;
			Destroy(this.transform.parent.gameObject.GetComponent<Rigidbody>());
			Debug.Log("got it");
			used = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
