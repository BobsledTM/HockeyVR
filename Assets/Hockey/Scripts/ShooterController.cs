using UnityEngine;
using System;

namespace Hockey
{
	/// <summary>
	/// Controls which shooter shoots and when.
	/// </summary>
	public class ShooterController : MonoBehaviour
	{
		public event EventHandler ShootPuckEvent;

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
				randomShooter.AddToShootQueue(GetNextPuck());
				randomShooter.Shoot();
				ShootPuckEvent.Raise(randomShooter, EventArgs.Empty);
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