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
            _answerImage.enabled = true;
            OnAnswerButtonClicked?.Invoke(_isCorrectAnswer);
        }
    }
    
    public struct AnswerSlotModel
    {
        public string Choice { get; set; }
        public Color AnswerColor { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }

    public interface IAnswerSlotController
    {
        void Bind(AnswerSlotModel model);
        event System.Action<bool> OnAnswerButtonClicked;
    }
}