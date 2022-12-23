using UnityEngine;

namespace MageStudy.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Url Data Container",menuName = "Mage Games/Data Container/Url Data Container")]
    public class ApiCallUrlDataContainerSO : ScriptableObject
    {
        [SerializeField] string[] _apiUrls;

        public string GetUrlByIndex(int index)
        {
            try
            {
                string result = _apiUrls[index];
                return result;
            }
            catch
            {
                Debug.Log($"Can't find api url this index number {index}");
                return string.Empty;
            }
        }
    }    
}