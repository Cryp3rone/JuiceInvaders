using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PostProcessManager : MonoBehaviour
{
    [Header("Ref")]
    [SerializeField] private Camera _camera;
    [SerializeField] private Volume _volume;
    [SerializeField] private ChromaticAberration _chromaticAberration;
    [SerializeField] private ColorAdjustments _colorAdjustement;

    [Header("Variables")]
    [SerializeField] private float _chromaAberationSpeed;
    [SerializeField] private float _colorAdjustementSpeed;

    private bool isActive;
    private bool isChangingChroma;
    private bool isChangingColor;
    private void Awake()
    {
        _volume.profile.TryGet(out _chromaticAberration);
        _volume.profile.TryGet(out _colorAdjustement);

        _camera.GetUniversalAdditionalCameraData().renderPostProcessing = false;
        Debug.Log(_camera.GetUniversalAdditionalCameraData());
    }

    private void Start()
    {
        GameFeelManager.instance.OnTogglePostProcess.AddListener(TogglePostProcess); 
    }

    private void OnDestroy()
    {
        GameFeelManager.instance.OnTogglePostProcess.RemoveListener(TogglePostProcess);
    }

    private void Update()
    {
        
            var actualChroma = _chromaticAberration.intensity.value;
            if (!isChangingChroma)
            {
                float random = Random.Range(.7f, 1f);
                StartCoroutine(ChangeChromaValue(_chromaticAberration, actualChroma, random, _chromaAberationSpeed));
            }
        
            var actualColorCurve = _colorAdjustement.hueShift.value;
            if (!isChangingColor)
            {
                float random = Random.Range(-180f, 180f);
                StartCoroutine(ChangeColorHueValue(_colorAdjustement, actualColorCurve, random, _colorAdjustementSpeed));
            }
        
    }

    private void TogglePostProcess(bool value)
    {
        _camera.GetUniversalAdditionalCameraData().renderPostProcessing = value; 
    }
    
    IEnumerator ChangeChromaValue(ChromaticAberration target ,float v_start, float v_end, float duration )
    {
        isChangingChroma = true;
        float elapsed = 0.0f;
        while (elapsed < duration )
        {
            target.intensity.value = Mathf.Lerp( v_start, v_end, elapsed / duration );
            elapsed += Time.deltaTime;
            yield return null;
        }
        target.intensity.value = v_end;
        isChangingChroma = false;
    }
    
    IEnumerator ChangeColorHueValue(ColorAdjustments target ,float v_start, float v_end, float duration )
    {
        isChangingColor = true;
        float elapsed = 0.0f;
        while (elapsed < duration )
        {
            target.hueShift.value = Mathf.Lerp( v_start, v_end, elapsed / duration );
            elapsed += Time.deltaTime;
            yield return null;
        }
        target.hueShift.value = v_end;
        isChangingColor = false;
    }
}
