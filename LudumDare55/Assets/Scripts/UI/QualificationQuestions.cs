using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QualificationQuestions : MonoBehaviour
{
    public static Action<int, int> QuestionAnsweredEvent;

    [System.Serializable]
    public struct QualificationQuestion
    {
        public string questionString;
        public int justiceVal;
        public int insanityVal;
    };

    [SerializeField]
    SceneChanger _sceneChanger;
    [SerializeField] 
    QualificationQuestion[] _qualificationQuestionArray;
    [SerializeField]
    TextMeshProUGUI _questionText;
    [SerializeField]
    float _charactersPerMinute;
    [SerializeField]
    Button _yesButton;
    [SerializeField]
    Button _noButton;
    [SerializeField]
    List<MeterDisplay> _meters;

    List<QualificationQuestion> _remainingQuestions;
    QualificationQuestion _currentQuestion;
    bool _isContemptOfCourt;
    bool _isFitForJuryDuty;
    bool _isExcused;
    int _questionsAsked;
    int _maxQuestionsToAsk = 10;

    private void Start()
    {
        DontDestroyOnLoad(this);
        _remainingQuestions = new List<QualificationQuestion>(_qualificationQuestionArray);
        EndScreenManager.EndScreenEvent += GetWinConditionIndex;
        SceneManager.sceneLoaded += ResetQuestions;
        _yesButton.interactable = false;
        _noButton.interactable = false;
        AskQuestion();
    }

    void AskQuestion()
    {
        _questionsAsked++;
        _questionText.text = "";
        int randQuestionIndex = Random.Range(0, _remainingQuestions.Count);
        _currentQuestion = _remainingQuestions[randQuestionIndex];
        _remainingQuestions.RemoveAt(randQuestionIndex);
        StartCoroutine(TypeText(_currentQuestion.questionString));
    }

    IEnumerator TypeText(string question)
    {
        foreach(char c in question)
        {
            _questionText.text += c;
            yield return new WaitForSeconds(60f/_charactersPerMinute);
        }
        _yesButton.interactable = true;
        _noButton.interactable = true;
    }

    public void ValidateAnswer(bool answer)
    {
        _yesButton.interactable = false;
        _noButton.interactable = false;
        int justiceValue = _currentQuestion.justiceVal * (answer ? 1 : -1);
        int insanityValue = _currentQuestion.insanityVal * (answer ? 1 : -1);
        QuestionAnsweredEvent?.Invoke(justiceValue,insanityValue);
        StartCoroutine(VerifyWinCondition());
    }

    public int GetWinConditionIndex()
    {
        if (_meters[0]._currentPoints == 100 && _meters[1]._currentPoints > 0)
            return 0;//serve

        if (_meters[0]._currentPoints > 0 && _meters[1]._currentPoints == 100)
            return 1;//excused

        if (_meters[0]._currentPoints > 0 && _meters[1]._currentPoints > 0)
            return 3;//retry

        if (_meters[0]._currentPoints == 0)
            return 2;//contempt
        
        return -1;
    }

    void ResetQuestions(Scene sceneLoaded, LoadSceneMode mode)
    {
        if (sceneLoaded.name != "GameScene")
            return;

        _remainingQuestions = new List<QualificationQuestion>(_qualificationQuestionArray);
        _isContemptOfCourt = false;
        _isFitForJuryDuty = false;

    }

    IEnumerator VerifyWinCondition()
    {
        yield return new WaitForSeconds(2);

        if (_questionsAsked > _maxQuestionsToAsk)
            _sceneChanger.LoadEndScene();
        else if (_meters[0]._currentPoints == 0 || _meters[1]._currentPoints == 0 || _meters[0]._currentPoints == 100 || _meters[1]._currentPoints == 100)
            _sceneChanger.LoadEndScene();
        else
            AskQuestion();

    }
}
