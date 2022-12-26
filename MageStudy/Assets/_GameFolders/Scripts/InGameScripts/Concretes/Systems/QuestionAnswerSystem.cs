using System.Collections.Generic;
using MageStudy.Controllers;
using MageStudy.DataEntities;
using MageStudy.Enums;
using MageStudy.Helpers;
using MageStudy.Managers;
using MageStudy.ScriptableObjects;
using UnityEngine;

namespace MageStudy.Systems
{
    public class QuestionAnswerSystem : MonoBehaviour
    {
        [SerializeField] GameRuleDataContainerSO _gameRuleDataContainer;
        [SerializeField] AnswerColorDataContainerSO _colorDataContainer;
        [SerializeField] AnswerSlotManager _answerSlotManager;
        [SerializeField] QuestionPresentationController _questionPresentationController;
        [SerializeField] int _maxQuestionCount;
        
        List<QuestionEntity> _questions;
        int _currentQuestionCount = 0;
        float _currentTime = 0f;

        public event System.Action<float> OnTimeChanged;

        async void Start()
        {
            _questions = await BackendManager.Instance.GetQuestions();
            _maxQuestionCount = _questions.Count;
            _currentQuestionCount = 0;

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
        
        void OnValidate()
        {
            this.GetReferenceInChildren<AnswerSlotManager>(ref _answerSlotManager);
            this.GetReferenceInChildren<QuestionPresentationController>(ref _questionPresentationController);
        }
        
        void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _gameRuleDataContainer.MaxOneQuestionTime)
            {
                _currentTime = 0f;
            }
            
            OnTimeChanged?.Invoke(_currentTime);
        }
    }
}