using UnityEngine;

namespace Projectile
{
	/// <summary>
	/// Objects that can be used as a projectile must implement these members.
	/// </summary>
	public interface IProjectile
	{
		void Shoot(Vector3 startLocation, Vector3 target, float force);
	}
}
