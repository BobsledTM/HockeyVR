using UnityEngine;

/// <summary>
/// Manages high level managers and their communication.
/// </summary>
public class GameManager : MonoBehaviour
{
	private StatManager _statManager;

	[SerializeField]
	private UIManager _uiManager;

	[SerializeField]
	private GameLogicManager _gameLogicManager;

	private void Awake()
	{
		_statManager = new StatManager(_gameLogicManager);
		_uiManager.Init(_statManager);
	}
}
