using UnityEngine;

public class TestCamera : MonoBehaviour
{
	SteamVR_Camera _vrcam;

	void Start ()
	{
		_vrcam = GetComponent<SteamVR_Camera>();
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			_vrcam.overlaySettings.scale -= .01f;
		}
		if(Input.GetKeyDown(KeyCode.W))
		{
			_vrcam.overlaySettings.scale += .01f;
		}
	}
}
