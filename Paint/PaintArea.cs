using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace YDJ
{
    public class PaintArea : MonoBehaviour
    {
        [SerializeField] List<GameObject> paintObjects;
        public List<GameObject> PaintObjects { get { return paintObjects; } }
        [SerializeField] LayerMask playerLayer;

        [Header("Susseces")]
        [SerializeField] GameObject sussecesEffect;
        private bool sussecesCheck = false;

        [Header("Area")]
        [SerializeField] WarningArea warningArea;
        [SerializeField] AudioClip[] audioClip;

        [SerializeField] WindowUI warningPrefab;
        private WindowUI warning;

        private void OnTriggerExit(Collider other) //플레이 중 나갔을 시 리셋
        {
            if (sussecesCheck) //성공 시 리턴
                return;

            if (playerLayer.Contain(other.gameObject.layer))
            {
                warningArea.WarningCheck = false; //에리어 자체를 나가면 위험 표지 안뜨게 하기
                if (warning != null)
                {
                    warning.Close();
                    warning = null;
                }

                foreach (var paintObject in paintObjects) //페인트 오브젝트 스크립트를 갖고있는 대표 오브젝트들 돌리기
                {
                    SpriteRenderer[] spriteRenderer = paintObject.gameObject.GetComponent<PaintObject>().SpriteRenderer;

                    foreach (var paintObjectPart in spriteRenderer) // 페인트 오브젝트 스크립트를 갖고 있지 않은 부속 오브젝트들 돌리기
                    {
                        paintObjectPart.gameObject.GetComponent<SpriteRenderer>().sprite = paintObject.gameObject.GetComponent<PaintObject>().beforeSprite;
                    }
                    paintObject.gameObject.layer = 26;
                }
                Manager.Sound.PlaySFX(audioClip[0]);
            }
        }

        public void Susseces()
        {
            StartCoroutine(Delay());
        }

        public UnityEvent OnClear;
        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1.5f);
            sussecesCheck = true;
            sussecesEffect.SetActive(true);
            Manager.Sound.PlaySFX(audioClip[1]);
            yield return new WaitForSeconds(3f);
            OnClear?.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            if (playerLayer.Contain(other.gameObject.layer)) //플레이어일때만 반응
            {
                if (warningArea.WarningCheck && !sussecesCheck) //위험 지역에 있고 성공한게 아닐 시
                {
                    if (warning == null)
                        warning = Manager.UI.ShowWindowUI(warningPrefab);
                }
                else if (!warningArea.WarningCheck && !sussecesCheck)
                {
                    if (warning == null)
                        return;
                    warning.Close();
                    warning = null;
                }
            }
        }
    }
}
