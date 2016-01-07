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
	private GameStarter _gameStarter;

	[SerializeField]
	private GameLogicManager _gameLogicManager;

	public void OnStartGame()
	{
		_statManager = new StatManager(_gameLogicManager);
		_uiManager.Init(_statManager);
	}
}
