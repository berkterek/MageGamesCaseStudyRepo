using MageStudy.Abstracts.Controllers;
using MageStudy.Abstracts.Uis;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MageStudy.Helpers;

namespace MageStudy.Controllers
{
    public class AnswerSlotController : BaseButton, IAnswerSlotController
    {
        [SerializeField] TMP_Text _answerText;
        [SerializeField] Image _answerImage;
        [SerializeField] bool _isCorrectAnswer;

        public bool IsCorrectAnswer => _isCorrectAnswer;

        public event System.Action<bool> OnAnswerButtonClicked;

        protected override void OnValidate()
        {
            base.OnValidate();
            
            this.GetReferenceInChildren<TMP_Text>(ref _answerText);
            this.GetReferenceInChildren<Image>(ref _answerImage);
        }

        public void Bind(AnswerSlotModel model)
        {
            _answerImage.enabled = false;
            _isCorrectAnswer = model.IsCorrectAnswer;
            _answerImage.color = model.AnswerColor;
            _answerText.text = model.Choice;
        }
        
        protected override void HandleOnButtonClicked()
        {
            ShowCorrectAnswer();
            OnAnswerButtonClicked?.Invoke(_isCorrectAnswer);
        }

        public void ShowCorrectAnswer()
        {
            _answerImage.enabled = true;
        }
    }
    
    public struct AnswerSlotModel
    {
        public string Choice { get; set; }
        public Color AnswerColor { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}