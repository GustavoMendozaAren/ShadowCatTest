using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BrightnessSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Volume globalVolume;
    private ColorAdjustments colorAdjustments;
    //[SerializeField] private Light2D globalLight;

    //private string intensityKey = "Light2DIntensity";
    //private float brightness;

    //private void Start()
    //{
    //    brightness = PlayerPrefs.GetFloat(intensityKey, 0.55f);
    //    UnityEngine.Device.Screen.brightness = brightness;
    //    slider.value = brightness;
    //    //UnityEngine.Device.Screen.brightness

    //    slider.onValueChanged.AddListener(OnSliderChange);
    //}

    //public void OnSliderChange(float value)
    //{
    //    UnityEngine.Device.Screen.brightness = value;
    //    PlayerPrefs.SetFloat(intensityKey, value);
    //}

    void Start()
    {
        if (globalVolume.profile.TryGet(out colorAdjustments))
        {
            slider.value = colorAdjustments.postExposure.value;

            slider.onValueChanged.AddListener(UpdateExposure);
        }
        else
        {
            Debug.LogError("No se encontró ColorAdjustments en el Volume.");
        }
    }

    void UpdateExposure(float value)
    {
        colorAdjustments.postExposure.value = value;
    }
}
