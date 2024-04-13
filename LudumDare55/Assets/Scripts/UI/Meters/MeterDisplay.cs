using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterDisplay : MonoBehaviour
{
    public static Action<MeterType> BarHitBelowZero;
    public static Action<MeterType> BarHitAboveMax;
    [SerializeField]MeterType _currentMeterType;
    [SerializeField]float _maxPoints;
    [SerializeField]float _currentPoints;
    Image _barImage;

    private void Start()
    {
        _barImage = GetComponent<Image>();  
    }

    void UpdateDisplay()
    {
        float fillamount = _currentPoints / _maxPoints;
        _barImage.fillAmount = fillamount;
    }

    public void AddPoints(float pointsToAdd)
    {
        if (_currentPoints + pointsToAdd > _maxPoints)
            BarHitAboveMax?.Invoke(_currentMeterType);

        _currentPoints += pointsToAdd;
        _currentPoints = Mathf.Clamp(_currentPoints,0,_maxPoints);
        UpdateDisplay();
    }

    public void RemovePoints(float pointsToRemove)
    {
        if (pointsToRemove > _currentPoints)
            BarHitBelowZero?.Invoke(_currentMeterType);

        AddPoints(-pointsToRemove);
    }
}
