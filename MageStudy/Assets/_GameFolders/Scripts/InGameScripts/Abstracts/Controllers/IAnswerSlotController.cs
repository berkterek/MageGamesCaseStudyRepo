using MageStudy.Controllers;

namespace MageStudy.Abstracts.Controllers
{
    public interface IAnswerSlotController
    {
        void Bind(AnswerSlotModel model);
        void ShowCorrectAnswer();
        event System.Action<bool> OnAnswerButtonClicked;
        bool IsCorrectAnswer { get; }
    }
}