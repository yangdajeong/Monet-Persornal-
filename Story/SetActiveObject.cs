using UnityEngine;

namespace YDJ
{
    public class SetActiveObject : MonoBehaviour
    {
        [SerializeField] bool SetActive;

        private void SetActiveManager()
        {
            if (SetActive) //true
                gameObject.SetActive(true);
            else            //false
                gameObject.SetActive(false);
        }
    }
}
