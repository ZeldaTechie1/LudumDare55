using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    public static Func<int> EndScreenEvent;
    [SerializeField]List<GameObject> _endingScreens;
    void Start()
    {
        int endScreenIndex = EndScreenEvent.Invoke();
        _endingScreens[endScreenIndex].SetActive(true);
    }
}
