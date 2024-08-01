using System.Collections;
using UnityEngine;

namespace YDJ
{
    public class PaintObject : MonoBehaviour
    {
        public Sprite beforeSprite;
        [SerializeField] Sprite afterSprite;
        [SerializeField] int paintColorNum;
        [SerializeField] Brush brush;
        [SerializeField] SpriteRenderer[] spriteRenderer;
        public SpriteRenderer[] SpriteRenderer { get { return spriteRenderer; } }
        [SerializeField] GameObject sussecesEffect;

        [Header("Sound")]
        [SerializeField] AudioClip[] audioClip;

        //private void Start()
        //{
        //    SpriteRenderer[0] = gameObject.GetComponent<SpriteRenderer>();
        //}

        public void ColorCheck()
        {
            foreach (var sprite in spriteRenderer)
            {
                if (sprite.color != new Color(1, 1, 1)) //기존 컬러에서 바꼈을 시
                {
                    if (paintColorNum == brush.ColorNum) //정답 / 자신의 정답지정색 번호와 브러쉬의 번호가 같을 때
                    {
                        Debug.Log("susseces");
                        StartCoroutine(True());
                        gameObject.layer = 0; // 다시 색칠 못하게 레이로 읽지 못 하게 하기
                    }
                    else                                //오답
                    {
                        Debug.Log("false");
                        StartCoroutine(False());
                    }
                }
            }
        }

        IEnumerator True()
        {
            yield return new WaitForSeconds(1f);
            foreach (var sprite in spriteRenderer)
            {
                sprite.sprite = afterSprite; //성공 시 성공 스프라이트로 바꿔주기
                sprite.color = new Color(1, 1, 1);
            }
            Manager.Sound.PlaySFX(audioClip[1]);
            sussecesEffect.SetActive(true);
            yield return new WaitForSeconds(3f);
            sussecesEffect.SetActive(false);
        }

        IEnumerator False()
        {
            yield return new WaitForSeconds(1f);
            foreach (var sprite in spriteRenderer)
            {
                sprite.color = new Color(1, 1, 1); //다시 흑백 이미지로 바꿔주기
                Manager.Sound.PlaySFX(audioClip[0]);
            }
        }
    }
}
