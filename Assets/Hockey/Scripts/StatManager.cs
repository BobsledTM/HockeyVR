using System;

public class StatManager
{
	public event EventHandler ScorePuckEvent;
	public event EventHandler ShootPuckEvent;
	public event EventHandler SavePuckEvent;

	public int TotalGoals { get; private set; }
	public int TotalShots { get; private set; }
	public int TotalSaves { get; private set; }

	private GameLogicManager _gameLogicManager;

	public StatManager(GameLogicManager gameLogicManager)
	{
		_gameLogicManager = gameLogicManager;
		_gameLogicManager.ScorePuckEvent += OnScorePuckEvent;
		_gameLogicManager.ShootPuckEvent += OnShootPuckEvent;
		_gameLogicManager.SavePuckEvent += OnSavePuckEvent;
	}

	~StatManager()
	{
		_gameLogicManager.ScorePuckEvent -= OnScorePuckEvent;
		_gameLogicManager.ShootPuckEvent -= OnShootPuckEvent;
		_gameLogicManager.SavePuckEvent -= OnSavePuckEvent;
	}

	private void OnScorePuckEvent(System.Object sender, EventArgs args)
	{
		TotalGoals++;
		ScorePuckEvent.Raise(sender, args);
	}

	private void OnShootPuckEvent(System.Object sender, EventArgs args)
	{
		TotalShots++;
		ShootPuckEvent.Raise(sender, args);
	}

	private void OnSavePuckEvent(System.Object sender, EventArgs args)
	{
		TotalSaves++;
		SavePuckEvent.Raise(sender, args);
	}
}
