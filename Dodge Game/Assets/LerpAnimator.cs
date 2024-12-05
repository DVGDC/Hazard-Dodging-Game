using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
