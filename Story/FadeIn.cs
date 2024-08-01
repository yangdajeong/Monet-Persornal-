using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace YDJ
{
    public class FadeIn : MonoBehaviour
    {
        [Header("Fada Out")]
        [SerializeField] float brigeTime;
        [SerializeField] SpriteRenderer[] brigeRender;

        public UnityEvent onFinished;

        private void Start()
        {
            StartCoroutine(fadeIn());
        }

        IEnumerator fadeIn()
        {
            float rate = 0;
            Color fadeInColor = Color.white;
            Color[] fadeOutColor = new Color[brigeRender.Length];

            for (int i = 0; i < brigeRender.Length; i++)
            {
                fadeOutColor[i] = brigeRender[i].color;
            }

            while (rate <= 1)
            {
                rate += Time.deltaTime / brigeTime;
                for (int i = 0; i < brigeRender.Length; i++)
                {
                    brigeRender[i].color = Color.Lerp(fadeOutColor[i], fadeInColor, rate);
                }
                yield return null;
            }
            onFinished?.Invoke();
        }

        //void Update()
        //{
        //    if (brigeTime < 1)
        //    {
        //        brigeTime += Time.deltaTime;
        //        foreach (var brigeRender in brigeRender)
        //        {
        //            Color b = brigeRender.color;
        //            b.a = brigeTime;
        //            brigeRender.color = b;
        //        }
        //    }
        //}
    }
}
