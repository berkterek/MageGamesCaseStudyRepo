using MageStudy.Abstracts.Controllers;
using UnityEngine;

namespace MageStudy.Controllers
{
    public class AnswerSlotManager : MonoBehaviour
    {
        [SerializeField] AnswerSlotController[] _slots;

        public event System.Action<bool> OnAnswerSelected;

        void OnValidate() => _slots ??= GetComponentsInChildren<AnswerSlotController>();

        void OnEnable()
        {
            foreach (IAnswerSlotController answerSlotController in _slots)
            {
                answerSlotController.OnAnswerButtonClicked += HandleOnAnswerButtonClicked;
            }
        }

        void OnDisable()
        {
            foreach (IAnswerSlotController answerSlotController in _slots)
            {
                answerSlotController.OnAnswerButtonClicked -= HandleOnAnswerButtonClicked;
            }
        }

        void HandleOnAnswerButtonClicked(bool value)
        {
            Debug.Log($"Answer is {value}");

            if (!value)
            {
                ShowCorrectAnswer();
            }

            OnAnswerSelected?.Invoke(value);
        }

        public void ShowCorrectAnswer()
        {
            foreach (IAnswerSlotController slot in _slots)
            {
                if (!slot.IsCorrectAnswer) continue;

                slot.ShowCorrectAnswer();
            }
        }

        public void Bind(AnswerSlotModel[] models)
        {
            for (int i = 0; i < models.Length; i++)
            {
                _slots[i].Bind(models[i]);
            }
        }
    }
}