using UnityEngine;

public class PlayerSteerer : MonoBehaviour
{
	[SerializeField]
	private float _speed;

	[SerializeField]
	private float _maxLeft;

	[SerializeField]
	private float _maxRight;

	[SerializeField]
	private float _maxDown;

	private Vector3 _origin;

	private Vector3 _currentTarget;

	private void Awake()
	{
		_origin = transform.position;
	}

	private void FixedUpdate()
	{
		Move(_currentTarget);
	}

	public void MoveLeft()
	{
		_currentTarget.x = _maxLeft + _origin.x;
	}

	public void MoveRight()
	{
		_currentTarget.x = _maxRight + _origin.x;
	}

	public void MoveDown()
	{
		_currentTarget.y = _maxDown + _origin.y;
	}

	public void MoveHorizontalToOrigin()
	{
		_currentTarget.x = _origin.x;
	}

	public void MoveVerticalToOrigin()
	{
		_currentTarget.y = _origin.y;
	}

	private void Move(Vector3 destination)
	{
		transform.position = Vector3.Lerp(transform.position, destination, _speed * Time.deltaTime);
	}
}
