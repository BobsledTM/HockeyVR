using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Quick simple class that tweens out a UI image after a given amount of time.
/// </summary>
[RequireComponent(typeof(Image))]
public class UIImageTimedTweenOut : MonoBehaviour
{
	[SerializeField]
	private float _onScreenTime;

	[SerializeField]
	private float _tweenOutTime;

	private float _timeOnScreen = 0;

	private float _currentTweenOutTime = 0;

	private Image _imageToTweenOut;

	private void Awake()
	{
		_imageToTweenOut = GetComponent<Image>();
	}

	private void Update()
	{
		_timeOnScreen += Time.deltaTime;
		if(_timeOnScreen > _onScreenTime)
		{
			_currentTweenOutTime += Time.deltaTime;
			TweenOut();
		}
	}

	/// <summary>
	/// Tween out the image to tween out.
	/// </summary>
	private void TweenOut()
	{
		float newAlpha = _tweenOutTime - _currentTweenOutTime / _tweenOutTime;
		Color tempColor = _imageToTweenOut.color;
		tempColor.a = newAlpha;
		_imageToTweenOut.color = tempColor;
		if(_imageToTweenOut.color.a == 0)
		{
			gameObject.SetActive(false);
		}
	}
}
