using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace YDJ
{
    public class Follow : MonoBehaviour
    {
        [SerializeField] Vector3 offsetTrans;
        [SerializeField] Quaternion offsetRotation;

        [SerializeField] LayerMask areaLayer;
        [SerializeField] GameObject compassOutLine1;
        [SerializeField] GameObject compassOutLine2;
        [SerializeField] Frame frame;
        public float colliderNum;
        [SerializeField] GameObject area1Effect;
        //[SerializeField] AudioClip[] audioClip;

        private Transform target;

        private void Start()
        {
            target = FindObjectOfType<ActionBasedController>().transform;
        }

        private void LateUpdate()
        {
            transform.position = target.position + offsetTrans;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (areaLayer.Contain(other.gameObject.layer)) //사실상 콜리더 갯수 세기는 계속 작동하되 액자 들고있음 여부로 진동과 사운드를 조정한다
            {
                colliderNum++;

                if (!frame.FrameHandle) //액자를 안들고 있으면 리턴
                    return;

                //이벤트 진동
                switch (colliderNum)
                {
                    case 2:
                        compassOutLine1.SetActive(true);
                        break;
                    case 4:
                        compassOutLine2.SetActive(true);
                        area1Effect.SetActive(true);
                        break;
                }
                // Manager.Sound.PlaySFX(audioClip[1]);
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (areaLayer.Contain(other.gameObject.layer))
            {
                colliderNum--;

                if (!frame.FrameHandle)
                    return;

                //이벤트 진동
                switch (colliderNum)
                {
                    case 1:
                        compassOutLine1.SetActive(false);
                        break;
                    case 3:
                        compassOutLine2.SetActive(false);
                        area1Effect.SetActive(false);
                        break;
                }
                //Manager.Sound.PlaySFX(audioClip[0]);
            }
        }
    }
}
