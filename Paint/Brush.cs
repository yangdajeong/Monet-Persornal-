using UnityEngine;

namespace YDJ
{
    public class Brush : MonoBehaviour
    {
        [SerializeField] LayerMask canvasScreenLayer;
        [SerializeField] Transform pointBox;
        [SerializeField] CameraRay cameraRay;
        [SerializeField] PaintArea paintArea;
        private int colorNum;
        public int ColorNum { get { return colorNum; } set { colorNum = value; } }
        private int num;
        [SerializeField] AudioClip brushSound;

        private void OnTriggerEnter(Collider other)
        {
            if (colorNum == 0) //붓에 색이 없을 때 리턴
                return;

            if (canvasScreenLayer.Contain(other.transform.gameObject.layer)) //canvasScreenLayer에만 반응
            {
                pointBox.position = gameObject.transform.position; //레이 설정을 위해 포인트 박스를 붓이 캔버스에 닿은 위치에 설정

                if (cameraRay.RayFire() == null) // 레이로 쏜 곳에 canvasScreenLayer 물체가 없다면 리턴
                    return;

                SpriteRenderer[] spriteRenderer = cameraRay.RayFire().GetComponent<PaintObject>().SpriteRenderer;
                switch (colorNum) //컬러넘버로 색깔 바꾸기 , 최종 색바꿔야 하는게 스프라이트 렌더러여서 자신의 메트리얼로 바꾸는게 불가능해서 colorNum를 썼음
                {
                    case 1:
                        foreach (var sprite in spriteRenderer)
                        {
                            sprite.color = new Color(1, 0.5330188f, 0.7671394f); //분홍
                        }
                        break;
                    case 2:
                        foreach (var sprite in spriteRenderer)
                        {
                            sprite.color = new Color(0.5377358f, 0.3028756f, 0.2206745f); //갈색
                        }
                        break;
                    case 3:
                        foreach (var sprite in spriteRenderer)
                        {
                            sprite.color = new Color(0.3128782f, 0.6555388f, 0.8396226f); //파랑
                        }
                        break;

                        //컬러넘 전해지는 순서 : 버튼 순서대로 1, 2, 3 지정 -> 누르면 물감통에 값전달 -> 붓이 담가지면 붓에 값 전달 -> 붓이 캔버스에 닿았을 때 맞았을 시 붓의 값으로 스프라이트 렌더러 색 지정
                }
                Manager.Sound.PlaySFX(brushSound);

                cameraRay.RayFire().GetComponent<PaintObject>().ColorCheck();

                num = 0;
                foreach (var renderer in paintArea.PaintObjects)
                {
                    if (renderer.gameObject.layer == 0)
                    {
                        num++;
                    }
                }
                if (num == paintArea.PaintObjects.Count)
                {
                    paintArea.Susseces();
                }
            }
        }
    }
}
