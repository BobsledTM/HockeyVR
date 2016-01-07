using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Quick simple class that tweens out a UI image after a given amount of time.
/// TODO: Make this for all components with a color.
/// </summary>
[RequireComponent(typeof(Image))]
public class UIImageTimedTweenOut : TimedTweenOut
{
	private Image _image;

	private Color _imageColor;

	private void Awake()
	{
		_image = GetComponent<Image>();
		_imageColor = _image.color;
	}

	/// <summary>
	/// Function that is called every frame during the tween and receives a ratio of the tween's progression 
	/// (from 1 at the beginning to 0 at the end).
	/// </summary>
	protected override void TweenOut(float tweenOutRatio)
	{
		_imageColor.a = tweenOutRatio;
		_image.color = _imageColor;
	}
}
