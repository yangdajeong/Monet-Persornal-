using UnityEngine;

namespace YDJ
{
    public class Frame : MonoBehaviour
    {
        private bool frameHandle;
        public bool FrameHandle { get { return frameHandle; } }

        public void areaOn() // 퍼스트 셀렉트, 라스트 셀렉트로 다시 시도
        {
            frameHandle = true;
        }

        public void areaOff()
        {
            frameHandle = false;
        }
    }
}
