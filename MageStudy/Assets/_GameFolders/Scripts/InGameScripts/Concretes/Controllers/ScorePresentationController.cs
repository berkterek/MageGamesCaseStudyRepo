using MageStudy.Helpers;
using MageStudy.Systems;
using TMPro;
using UnityEngine;

namespace MageStudy.Controllers
{
    public class ScorePresentationController : MonoBehaviour
    {
        [SerializeField] TMP_Text _scoreText;
        [SerializeField] QuestionAnswerSystem _questionAnswerSystem;

        void OnValidate()
        {
            if (_scoreText == null)
            {
                this.GetReferenceInChildren<TMP_Text>(ref _scoreText);
            } 
        }

        void OnEnable()
        {
            _questionAnswerSystem.OnPlayerScoreChanged += HandleOnPlayerScoreChanged;
        }

        void OnDisable()
        {
            _questionAnswerSystem.OnPlayerScoreChanged -= HandleOnPlayerScoreChanged;
        }
        
        void HandleOnPlayerScoreChanged(int value)
        {
            _scoreText.SetText(value.ToString("00"));
        }
    }    
}

