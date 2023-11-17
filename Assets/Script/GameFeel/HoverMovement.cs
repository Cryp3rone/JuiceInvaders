using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMovement : MonoBehaviour
{
    [Header ("Param")]
    private float offset;
    public float offsetMax;

    private float offsetMvt;
    public float offsetMaxMvt;

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

    public Coroutine coroutineA, coroutineMvt;

    void Awake()
    {
        GameFeelManager.instance.OnToggleAnim.AddListener(ToggleAnim);
    }

    public void ToggleAnim(bool b)
    {
        if(!b)
        {
            StopCoroutine(coroutineMvt);
            StopCoroutine(coroutineA);
            return;
        }
        offset = Random.Range(-offsetMax, offsetMax);
        offsetMvt = Random.Range(-offsetMaxMvt, offsetMaxMvt);
        coroutineA = StartCoroutine(Animate());
        coroutineMvt = StartCoroutine(AnimateMvt());
    }


    IEnumerator Animate()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(Mathf.Repeat(elapsedTime/duration + offset, 1 ) );
            this.gameObject.transform.rotation = new Quaternion(0f,0f, strength * maxAngle, 1f); 
            // this.gameObject.transform.Rotate(0f, 0f, strength * maxAngle, Space.World);
            if(useScale)
            {
                float scaleStrength = scaleCurve.Evaluate(Mathf.Repeat(elapsedTime/duration + offset, 1) );
                float corr = Mathf.Abs(scaleStrength) * scaleCorrection; // Correction to apply to the scale
                this.gameObject.transform.localScale = new Vector3(corr, corr, corr);
            }
            yield return null;
        }
        coroutineA = StartCoroutine(Animate());
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

                float mvtStrength = mvtCurve.Evaluate(Mathf.Repeat(elapsedTime/mvtDuration + offsetMvt, 1) );
                float clampedMvt = Mathf.Clamp(mvtStrength * maxMvt, -maxMvt, maxMvt);  // Clamp the movement
                this.gameObject.transform.localPosition = new Vector3(0, clampedMvt, 0);
     
            }

            yield return null;
        }
        coroutineMvt = StartCoroutine(AnimateMvt());
    }
}