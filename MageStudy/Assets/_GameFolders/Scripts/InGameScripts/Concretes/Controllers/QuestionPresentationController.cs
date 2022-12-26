using TMPro;
using UnityEngine;

namespace MageStudy.Controllers
{
    public class QuestionPresentationController : MonoBehaviour
    {
        [SerializeField] TMP_Text _questionText;
        [SerializeField] TMP_Text _categoryText;

        public void Bind(QuestionPresentationModel model)
        {
            _questionText.text = model.Question;
            _categoryText.text = model.Category;
        }
    }

    public struct QuestionPresentationModel
    {
        public string Question { get; set; }
        public string Category { get; set; }
    }
}

