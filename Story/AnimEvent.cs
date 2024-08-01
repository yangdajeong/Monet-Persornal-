using UnityEngine;
using UnityEngine.Events;

namespace YDJ
{
    public class AnimEvent : MonoBehaviour
    {
        public UnityEvent onFinishAnimation;

        void FinishAnim()
        {
            onFinishAnimation?.Invoke();
        }
    }
}
