using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAnimator : MonoBehaviour
{
	[SerializeField] private AnimationData[] animationData;

    // Start is called before the first frame update
    void Start()
    {
		PlayAnimation(animationData[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation(AnimationData animData)
    {
		StartCoroutine(AnimationCoroutine(animData));
	}

	private IEnumerator AnimationCoroutine(AnimationData animData)
	{
		float elapsedTime = 0f;
		transform.localPosition = animData.startPosition;
		transform.eulerAngles = animData.startRotation;
		transform.localScale = animData.startScale;
		while (elapsedTime < animData.animationLength)
		{
			float animationProgress = elapsedTime / animData.animationLength;

			transform.localPosition = Vector2.LerpUnclamped(animData.startPosition, animData.endPosition,
				animData.positionCurve.Evaluate(animData.positionCurve.length * animationProgress));

			transform.eulerAngles = Vector3.LerpUnclamped(animData.startRotation, animData.endRotation,
				animData.rotationCurve.Evaluate(animData.rotationCurve.length * animationProgress));

			transform.localScale = Vector2.LerpUnclamped(animData.startScale, animData.endScale,
				animData.scaleCurve.Evaluate(animData.scaleCurve.length * animationProgress));

			yield return new WaitForEndOfFrame();

			elapsedTime += Time.deltaTime;
		}
		transform.localPosition = animData.endPosition;
		transform.eulerAngles = animData.endRotation;
		transform.localScale = animData.endScale;
	}
}

[Serializable]
public struct AnimationData{

    public float animationLength;

    public Vector2 startPosition;
    public Vector2 endPosition;
    public AnimationCurve positionCurve;

    public Vector3 startRotation;
    public Vector3 endRotation;
	public AnimationCurve rotationCurve;

	public Vector2 startScale;
    public Vector2 endScale;
	public AnimationCurve scaleCurve;

	public AnimationData(float animationLength, Vector2 startPosition, Vector2 endPosition, AnimationCurve positionCurve, Vector3 startRotation, Vector3 endRotation, AnimationCurve rotationCurve, Vector2 startScale, Vector2 endScale, AnimationCurve scaleCurve)
	{
		this.animationLength = animationLength;
		this.startPosition = startPosition;
		this.endPosition = endPosition;
		this.positionCurve = positionCurve;
		this.startRotation = startRotation;
		this.endRotation = endRotation;
		this.rotationCurve = rotationCurve;
		this.startScale = startScale;
		this.endScale = endScale;
		this.scaleCurve = scaleCurve;
	}
}
