using System.Collections;
using UnityEngine;
using MageStudy.Helpers;

namespace MageStudy.Controllers
{
    public class FadeInOutController : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvasGroup;
        [SerializeField] float _fadeInSpeed = 5f;
        [SerializeField] float _fadeOutSpeed = 5f;

        void OnValidate()
        {
            this.GetReference<CanvasGroup>(ref _canvasGroup);
        }

        /// <summary>
        /// This methods call from unity event system
        /// </summary>
        public void Active()
        {
            StartCoroutine(FadeOutInAsync(1, _fadeInSpeed));
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        /// <summary>
        /// This methods call from unity event system
        /// </summary>
        public void Deactivate()
        {
            StartCoroutine(FadeOutInAsync(-1, _fadeOutSpeed));
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private IEnumerator FadeOutInAsync(int value, float speed)
        {
            while (true)
            {
                _canvasGroup.alpha += value * Time.deltaTime * speed;
                yield return null;

                if (_canvasGroup.alpha >= 1f || _canvasGroup.alpha <= 0f)
                {
                    break;
                }
            }
        }
    }
}