using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace YDJ
{
    public class RayManager : MonoBehaviour
    {
        [SerializeField] Transform[] point;

        [SerializeField] int distance;
        [SerializeField] LayerMask pointLayer;
        private RaycastHit hit1;
        private RaycastHit hit2;
        private RaycastHit hit3;

        private bool rayCheck;

        [Header("Susseces")]
        [SerializeField] FadeOut_Frame fadeOut_Frame;
        [SerializeField] GameObject frame;
        [SerializeField] GameObject susscesePaticle;
        [SerializeField] AudioClip sussecesSound;

        private void OnTriggerEnter(Collider other)
        {
            rayCheck = true;
        }

        private void OnTriggerExit(Collider other)
        {
            rayCheck = false;
        }

        private void Ray()
        {
            if (Physics.Raycast(Camera.main.transform.position, (point[0].position - Camera.main.transform.position).normalized, out hit1, distance, pointLayer)) // 끝지점 - 시작지점 = 시작지점에서 끝지점 사이의 방향이 구해진다, normalized를 쓰면 높은 수치값도 1이 된다 (방향일 때 씀)
            {
                Debug.Log("1번 Sussces");
            }
            if (Physics.Raycast(Camera.main.transform.position, (point[1].position - Camera.main.transform.position).normalized, out hit2, distance, pointLayer)) // 끝지점 - 시작지점 = 시작지점에서 끝지점 사이의 방향이 구해진다, normalized를 쓰면 높은 수치값도 1이 된다 (방향일 때 씀)
            {
                Debug.Log("2번 Sussces");
            }
            if (Physics.Raycast(Camera.main.transform.position, (point[2].position - Camera.main.transform.position).normalized, out hit3, distance, pointLayer)) // 끝지점 - 시작지점 = 시작지점에서 끝지점 사이의 방향이 구해진다, normalized를 쓰면 높은 수치값도 1이 된다 (방향일 때 씀)
            {
                Debug.Log("3번 Sussces");
            }

            if (hit1.collider != null && hit2.collider != null && hit3.collider != null) //hit.transform.gameobject != null 로 하면 오류남
            {
                Debug.Log("Susseces");
                fadeOut_Frame.enabled = true;
                frame.GetComponent<XRGrabInteractable>().enabled = false;
                frame.GetComponent<Rigidbody>().isKinematic = true; //정답 맞추면 액자를 만지지 못하고 위에 떠있게 하기
                frame.GetComponent<Rigidbody>().useGravity = false;
                StartCoroutine(SussecesPaticle());
                OnClear?.Invoke();
            }
        }
        public UnityEvent OnClear;

        private void FixedUpdate() //물리연산 최적화를 위해 TriggerStay에 다 넣는 대신 레이 함수를 만들어서 FixedUpdate를 사용 했다. 레인지 1에 들어갔을 때만 실행되게 한다
        {
            if (rayCheck)
            {
                Ray();
            }
        }

        IEnumerator SussecesPaticle()
        {
            yield return new WaitForSeconds(1);
            susscesePaticle.SetActive(true);
            Manager.Sound.PlaySFX(sussecesSound);
            gameObject.SetActive(false);
        }
    }
}
