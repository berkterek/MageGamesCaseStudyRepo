using UnityEngine;
using UnityEngine.UI;
using MageStudy.Helpers;

namespace MageStudy.Abstracts.Uis
{
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] protected Button _button;

        protected virtual void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        protected virtual void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }

        protected virtual void OnValidate()
        {
             this.GetReference<Button>(ref _button);
        }

        protected abstract void HandleOnButtonClicked();
    }    
}

