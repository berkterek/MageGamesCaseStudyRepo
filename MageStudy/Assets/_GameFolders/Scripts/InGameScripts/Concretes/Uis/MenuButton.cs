using MageStudy.Abstracts.Uis;
using MageStudy.Managers;

namespace MageStudy.Uis
{
    public class MenuButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            if (GameManager.Instance == null) return;
            
            GameManager.Instance.LoadMenuScene();
        }
    }
}