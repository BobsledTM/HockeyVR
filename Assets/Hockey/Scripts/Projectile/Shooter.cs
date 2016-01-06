using UnityEngine;
using System;
using System.Collections.Generic;

namespace Projectile
{
	/// <summary>
	/// Object that shoots pucks to a random position on a 2D plane.
	/// </summary>
	public abstract class Shooter : MonoBehaviour
	{
		public event EventHandler ShootEvent;

		/// <summary>
		/// Event that happens when you cant shoot due to the projectile queue being empty.
		/// </summary>
		public event EventHandler CantShootEvent;

		/// <summary>
		/// Event that happens when the projectile queue becomes emptied.
		/// </summary>
		public event EventHandler QueueEmptiedEvent;

		private Queue<IProjectile> _projectileQueue = new Queue<IProjectile>();

		public void Shoot(Vector3 startLocation, Vector3 target, float force)
		{
			if (_projectileQueue.Count == 0)
			{
				CantShootEvent.Raise(this, EventArgs.Empty);
			}
			else
			{
				IProjectile projectile = _projectileQueue.Dequeue();
				projectile.Shoot(startLocation, target, force);
				ShootEvent.Raise(this, EventArgs.Empty);
				if (_projectileQueue.Count == 0)
				{
					QueueEmptiedEvent.Raise(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// Gets the next projectile in the queue.
		/// </summary>
		public IProjectile Peek()
		{
			return _projectileQueue.Peek();
		}

		public void AddToShootQueue(IProjectile[] projectiles)
		{
			for(int i = 0; i < projectiles.Length; ++i)
			{
				_projectileQueue.Enqueue(projectiles[i]);
			}
		}

		public void AddToShootQueue(IProjectile projectile)
		{
			_projectileQueue.Enqueue(projectile);
		}
	}
}