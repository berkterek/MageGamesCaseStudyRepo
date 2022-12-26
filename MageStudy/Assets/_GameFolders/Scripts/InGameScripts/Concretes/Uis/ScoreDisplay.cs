using MageStudy.Helpers;
using MageStudy.Managers;
using TMPro;
using UnityEngine;

namespace MageStudy.Uis
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] TMP_Text _scoreText;

        void OnValidate()
        {
            this.GetReference<TMP_Text>(ref _scoreText);
        }

        void OnEnable()
        {
            GameManager.Instance.OnGameEnded += HandleOnGameEnded;
        }

        void OnDisable()
        {
            GameManager.Instance.OnGameEnded -= HandleOnGameEnded;
        }
        
        void HandleOnGameEnded(int value)
        {
            _scoreText.SetText(value.ToString("00"));
        }
    }    
}

