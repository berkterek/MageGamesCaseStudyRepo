using MageStudy.Abstracts.Uis;
using UnityEngine;

namespace MageStudy.Uis
{
    public class StartButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            Debug.Log("Start Button Triggered");
        }
    }
}