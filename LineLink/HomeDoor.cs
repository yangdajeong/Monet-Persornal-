using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace YDJ
{
    public class HomeDoor : MonoBehaviour
    {
        [Header("TouchDoor")]
        [SerializeField] Animator doorOpen;
        [SerializeField] GameObject linePuzzle;
        //[SerializeField] LayerMask controllerLayer;
        //[SerializeField] Animator[] doorHintAni;
        [SerializeField] LayerMask playerLayer;
        [SerializeField] GameObject doorHintFlash;
        [SerializeField] GameObject[] doorHint;
        private bool doorTouchCheck = false;

        [Header("DoorSound")]
        [SerializeField] AudioClip[] audioClip;

        private void OnTriggerEnter(Collider other)
        {
            if (doorTouchCheck)
                return;

            if (playerLayer.Contain(other.gameObject.layer))
            {
                doorHint[0].SetActive(false);
                doorHint[1].SetActive(true);
            }
        }

        public void DoorGrab()
        {
            if (!doorTouchCheck)
            {
                doorTouchCheck = true;
                //doorHintAni[0].speed = 0;
                //doorHintAni[1].speed = 0;
                doorHintFlash.SetActive(true);
                doorHint[1].SetActive(false);
                StartCoroutine(DoorHint());
                Manager.Sound.PlaySFX(audioClip[0]);
            }
        }

        public UnityEvent showTutorial;
        IEnumerator DoorHint()
        {
            yield return new WaitForSeconds(3);
            linePuzzle.SetActive(true);
            yield return new WaitForSeconds(1);
            showTutorial?.Invoke();
            yield return new WaitForSeconds(1);
            doorHintFlash.SetActive(false);
        }

        public void DoorOpen() //이벤트로 작동
        {
            doorOpen.Play("Door");
            Manager.Sound.PlaySFX(audioClip[1]);
        }
    }
}