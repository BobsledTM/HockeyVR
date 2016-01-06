using UnityEngine;
using Projectile;
using System;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
	public event EventHandler SavePuckEvent;

	private Puck _puckToSave = null;

	[SerializeField]
	private ColliderMessenger[] _colliders;

	private void Awake()
	{
		for(int i = 0; i < _colliders.Length; ++i)
		{
			_colliders[i].CollisionEvent += OnCollisionEvent;
		}
	}

	private void OnCollisionEvent(System.Object sender, EventArgs args)
	{
		ColliderArgs colliderArgs = args as ColliderArgs;
		if (colliderArgs != null)
		{
			Puck tempPuck = colliderArgs.Collision.gameObject.GetComponent<Puck>();
			if (tempPuck != null && _puckToSave != null && _puckToSave.Equals(tempPuck))
			{
				SavePuckEvent.Raise(sender, args);
			}
		}
	}

	public void ListenToShot(System.Object puck)
	{
		_puckToSave = puck as Puck;
	}

	public void StopListeningToShot()
	{
		_puckToSave = null;
	}
}
