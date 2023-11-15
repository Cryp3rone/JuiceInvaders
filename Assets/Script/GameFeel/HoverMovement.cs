using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMovement : MonoBehaviour
{
    [Header ("Rotation")]
    public float duration;
    [Range (0,1)]
    public float maxAngle;
    public AnimationCurve curve;


    [Header ("Scale")]
    public bool useScale;
    public AnimationCurve scaleCurve;

    public float scaleCorrection = 1;


    [Header ("Movement")]
    public int mvtDuration;
    public bool useMvt;
    public AnimationCurve mvtCurve;

    public float maxMvt = 1;

    void Awake()
    {
        StartCoroutine(Animate());
        StartCoroutine(AnimateMvt());
        
    }

    IEnumerator Animate()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            this.gameObject.transform.rotation = new Quaternion(0f,0f, strength * maxAngle, 1f); 
            // this.gameObject.transform.Rotate(0f, 0f, strength * maxAngle, Space.World);
            if(useScale)
            {
                float scaleStrength = scaleCurve.Evaluate(elapsedTime/duration);
                float corr = Mathf.Abs(scaleStrength) * scaleCorrection; // Correction to apply to the scale
                this.gameObject.transform.localScale = new Vector3(corr, corr, corr);
            }
            yield return null;
        }
        StartCoroutine(Animate());
    }

    IEnumerator AnimateMvt()
    {

        float elapsedTime = 0f;
        // mvtDuration = Random.Range(1, mvtDuration);
        
        while (elapsedTime < mvtDuration)
        {
            elapsedTime += Time.deltaTime;

            if(useMvt)
            {

                float mvtStrength = mvtCurve.Evaluate(elapsedTime/mvtDuration);
                float clampedMvt = Mathf.Clamp(mvtStrength * maxMvt, -maxMvt, maxMvt);  // Clamp the movement
                this.gameObject.transform.localPosition = new Vector3(0, clampedMvt, 0);
     
            }

            yield return null;
        }
        StartCoroutine(AnimateMvt());
    }
}