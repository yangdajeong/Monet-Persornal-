using UnityEngine;

namespace YDJ
{
    public class ColliderInfo : MonoBehaviour
    {
        public float colliderNum;
        public float ColliderNum { get { return colliderNum; } set { colliderNum = value; } }

        [SerializeField] VibrationManager vibrationManager;
        [SerializeField] LayerMask areaLayer;
        [SerializeField] AudioClip[] audioClip;
        [SerializeField] Frame frame;
        [SerializeField] LayerMask frameLayer;

        [Header("property")]
        [SerializeField] float waitTime = 2f; //연속 쿨타임 시간

        /*public void Select(SelectEnterEventArgs arg)
        {
            if(frameLayer.Contain(arg.interactableObject.transform.gameObject.layer))
                frame = arg.interactableObject.transform.GetComponent<Frame>();
        }*/

        private void OnTriggerEnter(Collider other)
        {
            if (frame == null)
                return;
            if (areaLayer.Contain(other.gameObject.layer)) //사실상 콜리더 갯수 세기는 계속 작동하되 액자 들고있음 여부로 진동과 사운드를 조정한다
            {
                colliderNum++;

                if (!frame.FrameHandle) //액자를 안들고 있으면 리턴
                    return;

                //이벤트 진동
                switch (colliderNum)
                {
                    case 1:
                        vibrationManager.SendHapticsDouble(0.1f, 0.3f, waitTime);
                        break;
                    case 2:
                        vibrationManager.SendHapticsDouble(0.3f, 0.3f, waitTime);
                        break;
                    case 3:
                        vibrationManager.SendHapticsDouble(0.6f, 0.3f, waitTime);
                        break;
                    case 4:
                        vibrationManager.SendHapticsDouble(1f, 0.3f, waitTime); //최고 중심부 진동이 제일 쎔
                        break;
                }
                Manager.Sound.PlaySFX(audioClip[1]);
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (frame == null)
                return;
            if (areaLayer.Contain(other.gameObject.layer))
            {
                colliderNum--;

                if (!frame.FrameHandle)
                    return;

                //이벤트 진동
                switch (colliderNum)
                {
                    case 0:
                        vibrationManager.SendHapticsDouble(0.1f, 0.3f, waitTime);
                        break;
                    case 1:
                        vibrationManager.SendHapticsDouble(0.3f, 0.3f, waitTime);
                        break;
                    case 2:
                        vibrationManager.SendHapticsDouble(0.6f, 0.3f, waitTime);
                        break;
                    case 3:
                        vibrationManager.SendHapticsDouble(1f, 0.3f, waitTime);
                        break;
                }
                Manager.Sound.PlaySFX(audioClip[0]);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (frame == null)
                return;

            if (!frame.FrameHandle)
                return;

            if (areaLayer.Contain(other.gameObject.layer))
            {
                vibrationManager.SendHaptics(colliderNum / 7, 0.2f); //상시진동
            }
        }
    }
}

