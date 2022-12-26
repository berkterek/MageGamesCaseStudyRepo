using MageStudy.Abstracts.ScriptableObjects;
using UnityEngine;

namespace MageStudy.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Game Rule Data Container",menuName = "Mage Games/Data Container/Game Rule Data Container")]
    public class GameRuleDataContainerSO : ScriptableObject,IGameRuleDataContainer
    {
        [Range(1,50)]
        [SerializeField] int _correctAnswerPoint = 1;
        
        [Range(-50,-1)]
        [SerializeField] int _wrongAnswerPoint = -1;
        [Range(-50,-1)]
        [SerializeField] int _timesEndPoint = -1;

        public int CorrectAnswerPoint => _correctAnswerPoint;
        public int WrongAnswerPoint => _wrongAnswerPoint;
        public int TimesEndPoint => _timesEndPoint;
    }
}