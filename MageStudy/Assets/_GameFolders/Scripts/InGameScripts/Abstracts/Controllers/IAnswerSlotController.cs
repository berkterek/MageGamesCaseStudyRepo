using MageStudy.Controllers;

namespace MageStudy.Abstracts.Controllers
{
    public interface IAnswerSlotController
    {
        void Bind(AnswerSlotModel model);
        event System.Action<bool> OnAnswerButtonClicked;
    }
}