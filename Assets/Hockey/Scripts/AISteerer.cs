using UnityEngine;

/// <summary>
/// Steers shooter and blocker AI to go back and forth.
/// </summary>
public class AISteerer : MonoBehaviour
{
	[SerializeField]
	private float _sideXLimit;

	[SerializeField]
	private float _speed;
	
	bool _moveLeft = false;
	
	private Vector3 _leftMoveVector;
	private Vector3 _rightMoveVector;

	// Use this for initialization
	void Awake()
	{
		_leftMoveVector = new Vector3(_speed, 0, 0);
		_rightMoveVector = new Vector3(-_speed, 0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(Mathf.Abs(this.transform.position.x) > _sideXLimit)
		{
			if(transform.position.x < 0)
			{
				transform.position = new Vector3(-_sideXLimit, transform.position.y, transform.position.z);
			}
			else
			{
				transform.position = new Vector3(_sideXLimit, transform.position.y, transform.position.z);
			}
			_moveLeft = !_moveLeft;
		}
		
		if(_moveLeft)
		{
			Move (_leftMoveVector);
		}
		else
		{
			Move (_rightMoveVector);
		}
	}

	void Move(Vector3 moveVector)
	{
		transform.position += moveVector;
	}
}
