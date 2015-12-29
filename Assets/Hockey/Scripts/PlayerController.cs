using UnityEngine;
using Projectile;
using System;

[RequireComponent(typeof(PlayerSteerer))]
public class PlayerController : MonoBehaviour 
{
	public event EventHandler SavePuckEvent;

	private PlayerSteerer _playerSteerer;

	private void Awake()
	{
		_playerSteerer = GetComponent<PlayerSteerer>();
	}

	private void FixedUpdate()
	{
		HandlePlayerInput();
	}

	private void OnCollisionEvent(System.Object sender, EventArgs args)
	{
		ColliderArgs colliderArgs = args as ColliderArgs;
		if(colliderArgs != null)
		{
			if(colliderArgs.Collision.gameObject.GetComponent<Puck>() != null)
			{
				SavePuckEvent.Raise(sender, args);
			}
		}
	}

	private void HandlePlayerInput()
	{
		bool leftRightInput = false;
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			_playerSteerer.MoveLeft();
			leftRightInput = true;
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			_playerSteerer.MoveRight();
			leftRightInput = true;
		}

		if (!leftRightInput)
		{
			_playerSteerer.MoveHorizontalToOrigin();
		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			_playerSteerer.MoveDown();
		}
		else
		{
			_playerSteerer.MoveVerticalToOrigin();
		}

	}
}
