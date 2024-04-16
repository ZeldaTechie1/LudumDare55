using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeterType
{
    JusticeMeter,
    CrazinessMeter
}

public class MeterManager : MonoBehaviour
{
    [SerializeField]List<MeterDisplay> _meters;

    private void Start()
    {
        QualificationQuestions.QuestionAnsweredEvent += OnQuestionAnswered;
    }

    private void OnQuestionAnswered(int justiceValue, int insanityValue)
    {
        UpdateMeter(MeterType.JusticeMeter, justiceValue);
        UpdateMeter(MeterType.CrazinessMeter, insanityValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            UpdateMeter(MeterType.JusticeMeter, 1f);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            UpdateMeter(MeterType.JusticeMeter, -1f);
        if (Input.GetKeyDown(KeyCode.PageUp))
            UpdateMeter(MeterType.CrazinessMeter, 1f);
        if (Input.GetKeyDown(KeyCode.PageDown))
            UpdateMeter(MeterType.CrazinessMeter, -1f);
    }

    void UpdateMeter(MeterType meterType, float amountToAdjust)
    {
        if(amountToAdjust > 0)
            _meters[(int)meterType].AddPoints(amountToAdjust);
        else
            _meters[(int)meterType].RemovePoints(-amountToAdjust);
    }
}
