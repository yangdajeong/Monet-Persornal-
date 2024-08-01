using UnityEngine;
using UnityEngine.Events;

namespace YDJ
{
    public class TriggerObject : MonoBehaviour
    {
        [SerializeField] string ableTriggerTag;

        public UnityEvent setAcitveObject;
        private void OnTriggerEnter(Collider other)
        {
            if (ableTriggerTag == "")
            {
                setAcitveObject?.Invoke();
                return;
            }
            else if (other.CompareTag(ableTriggerTag))
                setAcitveObject?.Invoke();
        }
    }
}
