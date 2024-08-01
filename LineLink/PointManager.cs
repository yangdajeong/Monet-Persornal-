using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace YDJ
{
    public class PointManager : MonoBehaviour
    {
        private Transform beforePoint;
        [SerializeField] GameObject FirstPoint; // 첫 점을 잡았을 때부터 시작이기 때문에 따로 변수 지정
        [SerializeField] GameObject SecondPoint;
        [SerializeField] List<GameObject> Allpoints; //모든 포인트가 저장된 리스트
        [SerializeField] List<GameObject> points; //트리거에 닿았던 포인트가 저장된 리스트
        [SerializeField] int maxPoint;
        private bool firstSeletCheck = false;

        [Header("Layer")]
        [SerializeField] LayerMask pointLayer;

        [Header("Color")]
        [SerializeField] Material red;
        [SerializeField] Material yellow;

        [Header("Sussces Object")]
        [SerializeField] GameObject susscesObject;

        [Header("Fade Out")]
        [SerializeField] Material pointMat;
        [SerializeField] Material lineMat;
        [SerializeField] FadeOut fadeOut;

        [Header("Csv_Leader")]
        [SerializeField] CSV_Reader csv_Reader;
        [SerializeField] int level;
        public int Level { get { return level; } }

        [Header("Paticle")]
        [SerializeField] GameObject beforeEffect;
        //[SerializeField] GameObject leftControllerpaticle;
        //[SerializeField] GameObject rightControllerpaticle1;
        [SerializeField] XRGrabInteractable Interactable;
        private string seletHand;

        [Header("AudioClip")]
        [SerializeField] AudioClip[] audioClip;

        private void Awake()
        {
            Interactable = GetComponent<XRGrabInteractable>();
            if (Interactable != null)
            {
                Interactable.selectEntered.AddListener(OnSelect);
                Interactable.selectExited.AddListener(OnExit);
            }
            points.Add(FirstPoint); //첫번째 포인트 리스트에 추가 시작
            beforePoint = FirstPoint.transform;
        }

        private void Start()
        {
            Color p = pointMat.color;        //포인트, 라인 메트리얼 초기화
            p.a = 255;
            pointMat.color = p;
            Color l = lineMat.color;
            l.a = 255;
            lineMat.color = l;

            for (int i = 0; i < csv_Reader.Xpoint.Count; i++)
            {
                Allpoints[i].transform.localPosition = new Vector3(csv_Reader.Xpoint[i], csv_Reader.Ypoint[i], 0f);  // Csv 리더기로 포인트 위치 설정
            }

            maxPoint = csv_Reader.Xpoint.Count;

            gameObject.transform.position = FirstPoint.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (pointLayer.Contain(other.gameObject.layer))//point 레이어만 포함되게 하기
            {
                if (points[0].gameObject == other.gameObject && points.Count == maxPoint) //마지막 포인트에 연결했을 때 포인트빈 오브젝트 비활성화, 서세스 오브젝트 활성화
                {
                    beforePoint = other.gameObject.transform;
                    Manager.Sound.PlaySFX(audioClip[points.Count]);
                    Susses();
                    return;
                }

                if (points.Count == maxPoint - 1)
                    points[0].gameObject.GetComponent<Renderer>().material = yellow; //마지막 공 노란색으로 변하기

                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i].gameObject == other.gameObject) //포인츠 리스트의 모든 오브젝트들과 지금 닿은 오브젝트가 하나라도 겹치면 리턴(중복 방지)
                        return;
                }

                other.GetComponent<Renderer>().material = red;
                beforePoint = other.gameObject.transform;
                points.Add(other.gameObject);
                AfterPoint(other);
                Manager.Sound.PlaySFX(audioClip[points.Count - 1]);
            }
        }

        public Transform FindPoint() //LineLink 스크립트에 beforePoint 값 전달
        {
            return beforePoint;
        }

        private void AfterPoint(Collider other) // 다음 점 보이게 활성화
        {
            if (points.Count != maxPoint)
                Allpoints[points.Count].gameObject.SetActive(true);
        }

        public void StartPoint() //시작할 때 두번째 포인트 생성
        {
            //if (seletHand == "left")
            //    leftControllerpaticle.SetActive(true);
            //else if (seletHand == "right")
            //    rightControllerpaticle1.SetActive(true);

            beforeEffect.SetActive(false);
            SecondPoint.SetActive(true);

            if (!firstSeletCheck)
                FirstPoint.GetComponent<Renderer>().material = red;

            firstSeletCheck = true;
        }

        public void SeletExit() //잡고 있는 점을 풀었을 때 그 전 점으로 되돌아가기
        {
            //if (seletHand == "left")
            //    leftControllerpaticle.SetActive(false);
            //else if (seletHand == "right")
            //    rightControllerpaticle1.SetActive(false);

            beforeEffect.SetActive(true);
            gameObject.transform.position = beforePoint.transform.position;
        }

        public UnityEvent OnClear;
        private void Susses() // 점 잇기 성공
        {
            //if (seletHand == "left")
            //    leftControllerpaticle.SetActive(false);
            //else if (seletHand == "right")
            //    rightControllerpaticle1.SetActive(false);
            Interactable.enabled = false;
            fadeOut.enabled = true;
            csv_Reader.NextId.Clear();
            csv_Reader.Xpoint.Clear();
            csv_Reader.Ypoint.Clear();
            susscesObject.transform.SetParent(null);
            susscesObject.SetActive(true);
            Manager.Sound.PlaySFX(audioClip[12]);
            OnClear?.Invoke();
        }

        public void OnSelect(SelectEnterEventArgs args)
        {
            //XRGrabInteractable interactable = args.interactableObject.transform.GetComponent<XRGrabInteractable>();
            //{
            //    if (args.interactorObject.transform.parent.name == "Left Controller")
            //    {
            //        if (interactable == null)
            //            return;

            //        seletHand = "left";
            //    }
            //    else if (args.interactorObject.transform.parent.name == "Right Controller")
            //    {
            //        if (interactable == null)
            //            return;

            //        seletHand = "right";
            //    }
            //}
            StartPoint();
        }

        public void OnExit(SelectExitEventArgs arg)
        {
            SeletExit();
        }
    }
}
