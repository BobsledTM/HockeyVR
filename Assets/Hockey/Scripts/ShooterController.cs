using UnityEngine;
using System;

namespace Hockey
{
	/// <summary>
	/// Arguments for shooting a puck.
	/// </summary>
	public class ShootPuckArgs : EventArgs
	{
		public Puck Puck { get; private set; }

		public ShootPuckArgs(Puck puck)
		{
			Puck = puck;
		}
	}

	/// <summary>
	/// Controls which shooter shoots and when.
	/// </summary>
	public class ShooterController : MonoBehaviour
	{
		public event EventHandler<ShootPuckArgs> ShootPuckEvent;

		[SerializeField]
		private Shooter[] _shooters;

		[SerializeField]
		private float _shootInterval;

		[SerializeField]
		private Puck[] _pucks;

		private float _timer;

		private int _currentPuck = -1;

		private void Awake()
		{
			_timer = _shootInterval;
		}

		private void Update()
		{
			_timer -= Time.deltaTime;
			if (_timer <= 0)
			{
				Shooter randomShooter = GetRandomShooter();
				Puck nextPuck = GetNextPuck();
				randomShooter.AddToShootQueue(nextPuck);
				randomShooter.Shoot();
				ShootPuckEvent.Raise<ShootPuckArgs>(randomShooter, new ShootPuckArgs(nextPuck));
				_timer = _shootInterval;
			}
		}

		private Shooter GetRandomShooter()
		{
			int random = UnityEngine.Random.Range(0, _shooters.Length);
			return _shooters[random];
		}

		private Puck GetNextPuck()
		{
			_currentPuck++;
			_currentPuck %= _pucks.Length;
			return _pucks[_currentPuck];
		}
	}
}