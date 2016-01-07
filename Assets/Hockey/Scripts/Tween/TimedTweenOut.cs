using UnityEngine;

/// <summary>
/// Quick simple abstract class that defines how a tween out occurs.
/// TODO: Abstract more.
/// </summary>
public abstract class TimedTweenOut : MonoBehaviour
{
	[SerializeField]
	private float _tweenOutTime;

	[SerializeField]
	private float _onScreenTime;

	private float _timeOnScreen = 0;

	private float _currentTweenOutTime = 0;

	private float _currentTweenRatio;

	private void Update()
	{
		_timeOnScreen += Time.deltaTime;
		if (_timeOnScreen > _onScreenTime)
		{
			_currentTweenOutTime += Time.deltaTime;

			_currentTweenRatio = _tweenOutTime - _currentTweenOutTime / _tweenOutTime;

			if (_currentTweenRatio <= 0)
			{
				TweenOut(0);
				gameObject.SetActive(false);
			}
			else
			{
				TweenOut(_currentTweenRatio);
			}
		}
	}

	/// <summary>
	/// Function that is called every frame during the tween out and defines how the tween happens.
	/// </summary>
	protected abstract void TweenOut(float tweenRatio);
}
