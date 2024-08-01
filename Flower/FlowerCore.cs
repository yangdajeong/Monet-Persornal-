using UnityEngine;

namespace YDJ
{
    public class FlowerCore : MonoBehaviour
    {
        [SerializeField] Collider colliders;

        //꽃을 집은 다음 꽃잎을 떼야하므로 꽃을 집기전에는 콜리더를 켜서 꽃잎 못떼게 하기
        public void HoldTrue()
        {
            colliders.enabled = false;
        }

        public void Holdfalse()
        {
            colliders.enabled = true;
        }
    }
}