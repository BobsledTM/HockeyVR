using UnityEngine;
using System;
using Hockey;

/// <summary>
/// High level logic manager for the game.
/// </summary>
public class GameLogicManager : MonoBehaviour
{
	public event EventHandler ShootPuckEvent;
	public event EventHandler ScorePuckEvent;
	public event EventHandler SavePuckEvent;

	[SerializeField]
	private ShooterController _shooterController;

	[SerializeField]
	private Player _player;

	[SerializeField]
	private GoalTrigger _goalTrigger;

	[SerializeField]
	private AudioSource[] _puckSlapSounds;

	[SerializeField]
	private AudioSource[] _hitPadsSounds;

	private void OnEnable()
	{
		_shooterController.ShootPuckEvent += OnShootPuckEvent;
		_player.SavePuckEvent += OnSavePuckEvent;
		_goalTrigger.ScorePuckEvent += OnScorePuckEvent;
	}

	private void OnDisable()
	{
		_shooterController.ShootPuckEvent -= OnShootPuckEvent;
		_player.SavePuckEvent -= OnSavePuckEvent;
		_goalTrigger.ScorePuckEvent -= OnScorePuckEvent;
	}

	private void OnShootPuckEvent(System.Object sender, ShootPuckArgs args)
	{
		PlayRandomSound(sender, _puckSlapSounds);

		ShootPuckEvent.Raise(sender, args);

		_player.ListenToShot(args.Puck);
	}

	private void OnSavePuckEvent(System.Object sender, EventArgs args)
	{
		PlayRandomSound(sender, _hitPadsSounds);

		_player.StopListeningToShot();

		SavePuckEvent.Raise(sender, args);
	}

	private void OnScorePuckEvent(System.Object sender, EventArgs args)
	{
		ScorePuckEvent.Raise(sender, args);

		_player.StopListeningToShot();
	}

	private void PlayRandomSound(System.Object sender, AudioSource[] audioSources)
	{
		if (audioSources.Length > 0)
		{
			int randomSoundIndex = UnityEngine.Random.Range(0, audioSources.Length);
			AudioSource randomAudioSource = audioSources[randomSoundIndex];
			GameObject senderGameObject = sender as GameObject;
			if (senderGameObject != null)
			{
				randomAudioSource.gameObject.transform.position = senderGameObject.transform.position;
			}
			randomAudioSource.Play();
		}
	}
}