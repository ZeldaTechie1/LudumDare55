using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsHolder : MonoBehaviour
{
    public int winIndex;

    public void Start()
    {
        EndScreenManager.EndScreenEvent += GetWinConditionIndex;
    }

    int GetWinConditionIndex()
    {
        return winIndex;    
    }
}
