using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualificationQuestions : MonoBehaviour
{
    [System.Serializable]
    public struct QualificationQuestion
    {
        public string questionString;
        public int justiceVal;
        public int insanityVal;
    };

    [SerializeField] 
    QualificationQuestion[] _qualificationQuestionArray;

    void Start()
    {
    }

    void Update()
    {
        
    }
}
