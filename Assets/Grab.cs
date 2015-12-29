using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {


	private SixenseInput.Controller controller;
	private SixenseHands sixenseHand;
	public GameObject curObject;

	// Use this for initialization
	void Start () {

		controller = this.gameObject.GetComponent<SixenseHand>().m_controller;
	}
	

	// Update is called once per frame
	void Update () {

		if (controller == null)
			controller = this.gameObject.GetComponent<SixenseHand>().m_controller;
		
		if (controller != null &&
				curObject != null &&
				curObject.GetComponent<Rigidbody>() != null &&
				(controller.GetButtonDown(SixenseButtons.TRIGGER)))
		{
			Debug.Log("trying");
			curObject.transform.parent = this.transform;
			curObject.GetComponent<Rigidbody>().useGravity = false;
			curObject.GetComponent<Rigidbody>().freezeRotation = true;
		}

		if (controller != null &&
				curObject != null &&
				curObject.GetComponent<Rigidbody>() != null &&
				(controller.GetButtonUp(SixenseButtons.TRIGGER)))
		{
			curObject.transform.parent = null;
			curObject.GetComponent<Rigidbody>().useGravity = true;
			curObject.GetComponent<Rigidbody>().freezeRotation = false;
			curObject = null;
		}


		if (curObject != null &&
				curObject.GetComponent<Rigidbody>() != null)
			curObject.GetComponent<Rigidbody>().useGravity = false;

	}
}
