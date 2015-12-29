using UnityEngine;
using Projectile;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ColliderMessenger))]
public class Puck : MonoBehaviour, IProjectile
{
	private Rigidbody _rigidbody;

	public ColliderMessenger ColliderMessenger { get; private set; }

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		ColliderMessenger = GetComponent<ColliderMessenger>();
	}

	public void Shoot(Vector3 startLocation, Vector3 targetPosition, float shootingForce)
	{
		this.gameObject.transform.position = startLocation;
		_rigidbody.AddForce((targetPosition - transform.position) * shootingForce, ForceMode.Impulse);
	}
}
