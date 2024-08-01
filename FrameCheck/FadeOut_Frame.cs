using UnityEngine;

namespace YDJ
{
    public class FadeOut_Frame : MonoBehaviour
    {
        [Header("Fada Out")]
        [SerializeField] float frameTime = 4;
        [SerializeField] float brigeTime = -4;
        [SerializeField] SpriteRenderer frameRender;
        [SerializeField] SpriteRenderer[] brigeRender;
        [SerializeField] GameObject brigeCollider;
        [SerializeField] GameObject beforeBrige;
        [SerializeField] GameObject afterMone;

        void Update()
        {
            if (brigeTime < 1)
            {
                frameTime -= Time.deltaTime * 0.3f;
                Color f = frameRender.color;
                f.a = frameTime;
                frameRender.color = f;

                brigeTime += Time.deltaTime;
                foreach (var brigeRender in brigeRender)
                {
                    Color b = brigeRender.color;
                    b.a = brigeTime;
                    brigeRender.color = b;
                }
            }
            else
            {
                brigeCollider.SetActive(true);
                beforeBrige.SetActive(false);
                afterMone.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
