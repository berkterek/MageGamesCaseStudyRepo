using MageStudy.Abstracts.Uis;
using MageStudy.ScriptableObjects;
using UnityEngine;

namespace MageStudy.Uis
{
    public class CloseButton : BaseButton
    {
        [SerializeField] GameEvent _closeEvent;

        protected override void HandleOnButtonClicked()
        {
            _closeEvent.InvokeEvents();
        }
    }    
}

