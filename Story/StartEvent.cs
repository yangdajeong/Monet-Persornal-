using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace YDJ
{
    public class StartEvent : MonoBehaviour
    {
        public UnityEvent startEvent;

        void Start()
        {
            StartCoroutine(Delay());
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1);
            startEvent?.Invoke();
        }
    }
}
