using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public string _volumeParameter = "MasterVolume";
    public AudioMixer _mixer;
    public Slider _slider;
    public float _multipler = 30f;
    public Toggle _toggle;
    private bool _disableToggleEvent;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SliderValueChanged); 
        _toggle.onValueChanged.AddListener(ToggleValueChanged);
    }


    private void ToggleValueChanged(bool enableSound)
    { 
        if (_disableToggleEvent)
            return;
        
        if (enableSound)
            _slider.value = _slider.maxValue;
        else 
            _slider.value = _slider.minValue;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }

    private void SliderValueChanged(float value)
    {
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multipler);
        _disableToggleEvent = true;
        _toggle.isOn = _slider.value > _slider.minValue; 
        _disableToggleEvent = false;
    }

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
