using UnityEngine;
using System;

namespace Projectile
{
	public class ColliderArgs : EventArgs
	{
		public Collision Collision { get; private set; }

		public ColliderArgs(Collision collision)
		{
			Collision = collision;
		}
	}

	/// <summary>
	/// Wraps box collider messenging so a listener to the collider can receive collision events.
	/// </summary>
	[RequireComponent(typeof(BoxCollider))]
	public class ColliderMessenger : MonoBehaviour
	{
		public event EventHandler CollisionEvent;

		private void OnCollisionEnter(Collision collision)
		{
			CollisionEvent.Raise(this, new ColliderArgs(collision));
		}
	}
}