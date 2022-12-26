using System.Linq;
using MageStudy.Enums;
using UnityEngine;

namespace MageStudy.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Color Data Container",menuName = "Mage Games/Data Container/Color Data Container")]
    public class AnswerColorDataContainerSO : ScriptableObject
    {
        [SerializeField] AnswerColorInspector[] _answerColorInspectors;

        public Color GetColor(AnswerColorType colorType)
        {
            return _answerColorInspectors.FirstOrDefault(x => x.ColorType == colorType).Color;
        }
    }

    [System.Serializable]
    public struct AnswerColorInspector
    {
        [SerializeField] AnswerColorType _colorType;
        [SerializeField] Color _color;

        public AnswerColorType ColorType => _colorType;
        public Color Color => _color;
    }
}

