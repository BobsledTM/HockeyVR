using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the saves ui.
/// </summary>
[RequireComponent(typeof(Text))]
public class UISaves : MonoBehaviour
{
	private const string SAVES = "Saves";
	private const string OUT_OF = "/";

	public string SavesString { get; private set; }

	private Text _uiText;
	
	private void Awake()
	{
		_uiText = GetComponent<Text>();
	}

	public void UpdateText(int saves, int shots)
	{
		SavesString = SAVES + "\n" + saves + OUT_OF + shots;
		_uiText.text = SavesString;
	}
}
