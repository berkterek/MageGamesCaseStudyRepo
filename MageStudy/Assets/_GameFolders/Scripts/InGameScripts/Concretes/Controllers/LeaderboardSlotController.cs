using MageStudy.DataEntities;
using TMPro;
using UnityEngine;

namespace MageStudy.Controllers
{
    public class LeaderboardSlotController : MonoBehaviour
    {
        [SerializeField] TMP_Text _rankText;
        [SerializeField] TMP_Text _nicknameText;
        [SerializeField] TMP_Text _scoreText;

        public void Bind(LeaderboardPlayerEntityData entity)
        {
            _rankText.text = entity.Rank.ToString();
            _nicknameText.text = entity.Nickname;
            _scoreText.text = entity.Score.ToString();
        }
    }    
}