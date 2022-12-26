using System.Collections;
using System.Collections.Generic;
using MageStudy.Controllers;
using MageStudy.DataEntities;
using MageStudy.Enums;
using MageStudy.Helpers;
using MageStudy.Managers;
using MageStudy.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace MageStudy.Systems
{
    public class QuestionAnswerSystem : MonoBehaviour
    {
        [SerializeField] GameRuleDataContainerSO _gameRuleDataContainer;
        [SerializeField] AnswerColorDataContainerSO _colorDataContainer;
        [SerializeField] AnswerSlotManager _answerSlotManager;
        [SerializeField] QuestionPresentationController _questionPresentationController;
        [SerializeField] Image _blocker;
        [SerializeField] int _maxQuestionCount;
        [SerializeField] int _playerScore = 0;
        
        List<QuestionEntity> _questions;
        int _currentQuestionCount = 0;
        float _currentTime = 0f;
        bool _isTimeEnd = false;

        public event System.Action<float> OnTimeChanged;
        public event System.Action<int> OnPlayerScoreChanged;

        async void Start()
        {
            _questions = await BackendManager.Instance.GetQuestions();
            _maxQuestionCount = _questions.Count;
            _currentQuestionCount = 0;

            ShowQuestion();
        }

        void OnEnable()
        {
            _answerSlotManager.OnAnswerSelected += HandleOnAnswerSelected;
        }

        void OnDisable()
        {
            _answerSlotManager.OnAnswerSelected -= HandleOnAnswerSelected;
        }

        void OnValidate()
        {
            this.GetReferenceInChildren<AnswerSlotManager>(ref _answerSlotManager);
            this.GetReferenceInChildren<QuestionPresentationController>(ref _questionPresentationController);
        }
        
        void Update()
        {
            if (_isTimeEnd) return;
            
            _currentTime += Time.deltaTime;

            if (_currentTime > _gameRuleDataContainer.MaxOneQuestionTime)
            {
                _isTimeEnd = true;
                _currentTime = 0f;
                _answerSlotManager.ShowCorrectAnswer();
                HandleOnAnswerSelected(false);
            }
            
            OnTimeChanged?.Invoke(_currentTime);
        }

        private void ShowQuestion()
        {
            var currentQuestion = _questions[_currentQuestionCount];

            AnswerSlotModel[] models = new AnswerSlotModel[4];
            
            for (int i = 0; i < models.Length; i++)
            {
                AnswerSlotModel model = new AnswerSlotModel();
                model.Choice = currentQuestion.Choices[i];
                model.IsCorrectAnswer = model.Choice.StartsWith(currentQuestion.Answer);
                model.AnswerColor = model.IsCorrectAnswer
                    ? _colorDataContainer.GetColor(AnswerColorType.Correct)
                    : _colorDataContainer.GetColor(AnswerColorType.Wrong);
                models[i] = model;
            }
            
            _answerSlotManager.Bind(models);
            
            _questionPresentationController.Bind(new QuestionPresentationModel
            {
                Question = currentQuestion.Question,
                Category = currentQuestion.Category
            });
        }
        
        void HandleOnAnswerSelected(bool value)
        {
            _blocker.enabled = true;
            
            if (value)
            {
                _playerScore += _gameRuleDataContainer.CorrectAnswerPoint;
            }
            else
            {
                if (_isTimeEnd)
                {
                    _playerScore += _gameRuleDataContainer.TimesEndPoint;
                }
                else
                {
                    _playerScore += _gameRuleDataContainer.WrongAnswerPoint;
                }
            }
            
            OnPlayerScoreChanged?.Invoke(_playerScore);

            StartCoroutine(NextQuestionAsync());
        }

        IEnumerator NextQuestionAsync()
        {
            _isTimeEnd = true;
            _currentTime = 0f;
            _currentQuestionCount++;
            
            yield return new WaitForSeconds(3f);

            if (_currentQuestionCount >= _maxQuestionCount)
            {
                _blocker.enabled = true;
                _isTimeEnd = true;
            }
            else
            {
                _blocker.enabled = false;
                _isTimeEnd = false;             
                ShowQuestion();
            }
        }
    }
}