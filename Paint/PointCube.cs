using UnityEngine;

namespace YDJ
{
    public class PointCube : MonoBehaviour
    {
        private Vector3 canvasScreenVec;
        public Vector3 CanvasScreenVec { get { return canvasScreenVec; } }

        private Vector3 fixVectorfixVector;
        [SerializeField] GameObject backPointCube; //영점조절용

        public Vector3 FixVector3()
        {
            //2D를 3D화 시키기
            fixVectorfixVector = gameObject.transform.localPosition;
            fixVectorfixVector.x = gameObject.transform.localPosition.z;
            fixVectorfixVector.z = 0;

            backPointCube.transform.localPosition = fixVectorfixVector * 15; //1대1 비율이기 때문에 곱하는 수만 잘 조절하면 맞출 수 있다

            return backPointCube.transform.position;
        }
    }
}
