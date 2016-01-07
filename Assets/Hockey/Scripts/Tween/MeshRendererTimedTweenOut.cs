using UnityEngine;

/// <summary>
/// Simple tween out that fades away a text mesh after a certain amount of time.
/// TODO: Make this for all components with a color.
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class MeshRendererTimedTweenOut : TimedTweenOut
{
	private MeshRenderer _meshRenderer;

	private Color _textMeshColor;

	private void Awake()
	{
		_meshRenderer = GetComponent<MeshRenderer>();
		_textMeshColor = _meshRenderer.material.color;
	}

	protected override void TweenOut(float tweenRatio)
	{
		_textMeshColor.a = tweenRatio;
		_meshRenderer.material.color = _textMeshColor;
	}
}
