using System.Collections;
using UnityEngine;

namespace YDJ
{
    public class CellRay : MonoBehaviour
    {
        [SerializeField] LayerMask hideLayer;
        [SerializeField] CellHide cellHide;
        [SerializeField] Transform cellSocket;
        public bool grabCheck = false;
        public bool hideCheck = false;

        private void Start()
        {
            StartCoroutine(Delay());
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(1f);
            transform.position = cellSocket.position;

        }

        public void Select()
        {
            grabCheck = true;
        }

        public void Exit()
        {
            grabCheck = false;
        }

        void Update()
        {
            if (!grabCheck)
            {
                cellHide.HideGrabOff();
                return;
            }

            float maxDistance = 10;
            if (Physics.BoxCast(Camera.main.transform.position, transform.lossyScale / 4, (transform.position - Camera.main.transform.position).normalized, transform.rotation, maxDistance, hideLayer))
            {
                cellHide.HideGrabOn();
            }
            else
            {
                cellHide.HideGrabOff();
            }
        }

        void OnDrawGizmos()
        {
            float maxDistance = 10;

            Gizmos.color = Color.red;

            // 함수 파라미터 : 현재 위치, Box의 절반 사이즈, Ray의 방향, RaycastHit 결과, Box의 회전값, BoxCast를 진행할 거리
            if (true == Physics.BoxCast(Camera.main.transform.position, transform.lossyScale / 4, (transform.position - Camera.main.transform.position).normalized, out RaycastHit hit, transform.rotation, maxDistance, hideLayer))
            {
                // Hit된 지점까지 ray를 그려준다.
                Gizmos.DrawRay(Camera.main.transform.position, (transform.position - Camera.main.transform.position).normalized * hit.distance);

                // Hit된 지점에 박스를 그려준다.
                Gizmos.DrawWireCube(Camera.main.transform.position + (transform.position - Camera.main.transform.position).normalized * hit.distance, transform.lossyScale / 4);
            }
            else
            {
                // Hit가 되지 않았으면 최대 검출 거리로 ray를 그려준다.
                Gizmos.DrawRay(Camera.main.transform.position, (transform.position - Camera.main.transform.position).normalized * maxDistance);
            }
        }



        //private void OnDrawGizmos()
        //{
        //    float maxDistance = 10;
        //    //RaycastHit hit;

        //    //bool ishit = Physics.BoxCast(Camera.main.transform.position, transform.lossyScale / 2, Camera.main.transform.position - transform.position, out hit, transform.rotation, maxDistance);

        //    Gizmos.color = Color.red;
        //    Gizmos.DrawRay(Camera.main.transform.position, (transform.position - Camera.main.transform.position).normalized * maxDistance);
        //    Debug.Log(transform.position);
        //}
    }
}
