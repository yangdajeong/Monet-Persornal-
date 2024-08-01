using System.Collections.Generic;
using UnityEngine;

namespace YDJ
{
    public class LineLink : MonoBehaviour
    {
        private LineRenderer line;
        [SerializeField] PointManager lineBin;
        [SerializeField] Transform lineBinTransform;
        [SerializeField] List<Transform> points;
        private Transform beforePoint; //마지막에 닿은 포인트
        [SerializeField] Transform firstPoint;

        private void Awake()
        {
            line = GetComponent<LineRenderer>();
            line.positionCount = 2;
            points = new List<Transform>();
            points.Add(firstPoint);
        }

        private void AddPoint()
        {
            if (lineBin.FindPoint() != beforePoint) //포인츠 빈에 닿은 트리거와 마지막에 닿은 포인트가 같지 않다면(똑같은거 또 반복추가 방지)
            {
                line.positionCount++; //라인렌더러의 점 갯수 늘리기
                beforePoint = lineBin.FindPoint(); //포인트빈에 닿은 트리거를 마지막에 닿은 포인트로 지정
                points.Add(beforePoint); //포인츠 리스트에 마지막에 닿은 포인트 추가하기
            }
        }

        private void Update()
        {
            AddPoint();

            for (int i = 0; i < points.Count; i++)
            {
                line.SetPosition(i, points[i].position);    //라인 렌더러의 포인트 위치 지정하기
                line.SetPosition(i + 1, lineBinTransform.position);
            }
        }
    }
}
