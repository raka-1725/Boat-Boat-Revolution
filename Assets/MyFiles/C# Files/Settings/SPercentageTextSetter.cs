using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SPercentageTextSetter : MonoBehaviour
{
    private Slider mSlider;
    [SerializeField] private TextMeshProUGUI mText;

    private void Start()
    {
        mSlider = GetComponent<Slider>();
        
        mSlider.onValueChanged.AddListener(OnSliderValueChanged);
        
        OnSliderValueChanged(mSlider.value);
    }

    private void OnSliderValueChanged(float val)
    {
        float percentage = val * 100;
        mText.text = Mathf.RoundToInt(percentage).ToString();
    }
}
