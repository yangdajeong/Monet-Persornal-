using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace YDJ
{
    public class VibrationManager : MonoBehaviour
    {
        [SerializeField] XRBaseController leftController, rightController;
        private float defaultAmplitude = 0.2f; //진동세기
        private float defaultDuration = 0.5f; //지속시간

        public void SendHapticsDouble(float amplitude, float duration, float waitTime)
        {
            StartCoroutine(Loop(amplitude, duration, waitTime));
        }

        private IEnumerator Loop(float amplitude, float duration, float waitTime)
        {
            leftController.SendHapticImpulse(amplitude, duration);
            rightController.SendHapticImpulse(amplitude, duration);
            yield return new WaitForSeconds(waitTime);
            leftController.SendHapticImpulse(amplitude, duration);
            rightController.SendHapticImpulse(amplitude, duration);
        }

        //public void SendHapticsIng(float amplitude, float duration, float speed)
        //{
        //    StartCoroutine(LoopIng(amplitude, duration, speed));
        //}

        //public IEnumerator LoopIng(float amplitude, float duration, float speed)
        //{
        //    leftController.SendHapticImpulse(amplitude, duration);
        //    rightController.SendHapticImpulse(amplitude, duration);
        //    Debug.Log("SendHapticImpulse1");
        //    yield return new WaitForSeconds(speed);
        //    StartCoroutine(LoopIng(amplitude, duration, speed ));
        //}








        //오버라이드

        [ContextMenu("Send Haptics")]
        public void SendHaptics() //디폴트
        {
            leftController.SendHapticImpulse(defaultAmplitude, defaultDuration);
            rightController.SendHapticImpulse(defaultAmplitude, defaultDuration);
        }

        public void SendHaptics(float amplitude, float duration)
        {
            leftController.SendHapticImpulse(amplitude, duration);
            rightController.SendHapticImpulse(amplitude, duration);
        }

        public void SendHaptics(bool isLeftController, float amplitude, float duration)
        {
            if (isLeftController)
            {
                leftController.SendHapticImpulse(amplitude, duration);
            }
            else
            {
                rightController.SendHapticImpulse(amplitude, duration);
            }
        }

        public void SendHaptics(XRBaseController controller, float amplitude, float duration)
        {
            controller.SendHapticImpulse(amplitude, duration);
        }
    }
}
