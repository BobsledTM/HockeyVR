﻿using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
	private StatManager _statManager;

	[SerializeField]
	private UISaves _uiSaves;

	public void Init(StatManager statManager)
	{
		_statManager = statManager;
		_statManager.ScorePuckEvent += OnScorePuckEvent;
		_statManager.SavePuckEvent += OnSavePuckEvent;
	}

	private void OnDisable()
	{
		_statManager.ScorePuckEvent -= OnScorePuckEvent;
		_statManager.SavePuckEvent -= OnSavePuckEvent;
	}

	private void OnScorePuckEvent(System.Object sender, EventArgs args)
	{
		_uiSaves.UpdateText(_statManager.TotalSaves, _statManager.TotalShots);
	}

	private void OnSavePuckEvent(System.Object sender, EventArgs args)
	{
		_uiSaves.UpdateText(_statManager.TotalSaves, _statManager.TotalShots);
	}
}
