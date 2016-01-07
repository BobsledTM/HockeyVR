using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Temporary class used to wait until a player his start, then init all objects/scripts that need to wait to start.
/// </summary>
public class GameStarter : MonoBehaviour
{
	[SerializeField]
	private MonoBehaviour[] _defferredEnableScripts;

	private void Awake()
	{
		SetDefferedEnableScripts(false);
	}

	public void OnStart()
	{
		SetDefferedEnableScripts(true);
	}

	private void SetDefferedEnableScripts(bool enabled)
	{
		for (int i = 0; i < _defferredEnableScripts.Length; ++i)
		{
			_defferredEnableScripts[i].enabled = enabled;
		}
	}
}
