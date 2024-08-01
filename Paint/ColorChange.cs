using UnityEngine;

namespace YDJ
{
    public class ColorChange : MonoBehaviour
    {
        [SerializeField] GameObject paintBuket;
        [SerializeField] Bucket bucket;
        [SerializeField] int thisColorNum;

        public void ColorSelect()
        {
            paintBuket.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material; //물감통 메트리얼을 현재 게임 오브젝트 버튼의 메트리얼로 바꾼다
            bucket.ColorNum = thisColorNum;
        }
    }
}
