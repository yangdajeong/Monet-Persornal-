using UnityEngine;
using UnityEngine.Events;

namespace YDJ
{
    public class Key : MonoBehaviour
    {
        public UnityEvent OnClear;
        [SerializeField] LayerMask doorLayer;

        private void OnTriggerEnter(Collider other)
        {
            if (doorLayer.Contain(other.gameObject.layer))
            {
                Destroy(gameObject);
                OnClear?.Invoke();
            }
        }
    }
}
