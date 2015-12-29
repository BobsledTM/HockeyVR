using UnityEngine;
using Projectile;

namespace Hockey
{
	/// <summary>
	/// Shoots a puck at a random target on the net.
	/// </summary>
	[RequireComponent(typeof(Renderer))]
	public class Shooter : Projectile.Shooter
	{
		private const float SHOOT_START_Y = .35f;

		private Renderer _renderer;

		[SerializeField]
		private float _shootingForce;

		[SerializeField]
		private float _randXTargetMax;

		[SerializeField]
		private float _randXTargetMin;

		[SerializeField]
		private float _randYTargetMax;

		[SerializeField]
		private float _randYTargetMin;

		[SerializeField]
		private float _zTarget;

		private void Awake()
		{
			_renderer = GetComponent<Renderer>();
		}

		public void Shoot()
		{
			Shoot(GetPuckSpawnPosition(), GetRandomNetTarget(), _shootingForce);
		}

		/// <summary>
		/// Gets a random point on the x, y plane on the target z axis.
		/// Used to get a random point on the net to aim to.
		/// </summary>
		private Vector3 GetRandomNetTarget()
		{
			Vector3 randomNetTarget;
			randomNetTarget.x = Random.Range(_randXTargetMin, _randXTargetMax);
			randomNetTarget.y = Random.Range(_randYTargetMin, _randYTargetMax);
			randomNetTarget.z = _zTarget;
			return randomNetTarget;
		}

		/// <summary>
		/// Get the spawn position for the puck being shot.
		/// </summary>
		private Vector3 GetPuckSpawnPosition()
		{
			Vector3 spawnPos;
			spawnPos.x = transform.position.x;
			spawnPos.y = SHOOT_START_Y;
			spawnPos.z = transform.position.z - _renderer.bounds.size.z / 2;
			return spawnPos;
		}
	}
}
