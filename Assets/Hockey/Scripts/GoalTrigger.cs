using UnityEngine;
using System;

/// <summary>
/// Handles detection for pucks going through the net.
/// </summary>
public class GoalTrigger : MonoBehaviour
{
	public event EventHandler ScorePuckEvent;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.GetComponent<Puck>() != null)
		{
			ScorePuckEvent.Raise(this, EventArgs.Empty);
		}
	}
}
