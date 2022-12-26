using MageStudy.Helpers;
using MageStudy.Systems;
using TMPro;
using UnityEngine;

namespace MageStudy.Controllers
{
    public class TimerPresentationController : MonoBehaviour
    {
        [SerializeField] TMP_Text _timerText;
        [SerializeField] QuestionAnswerSystem _system;

        void OnValidate()
        {
            this.GetReferenceInChildren<TMP_Text>(ref _timerText);
        }

        void OnEnable()
        {
            _system.OnTimeChanged += HandleOnTimeChanged;
        }

        void OnDisable()
        {
            
        }
        
        void HandleOnTimeChanged(float value)
        {
            _timerText.SetText(value.ToString("00"));
        }
    }    
}

