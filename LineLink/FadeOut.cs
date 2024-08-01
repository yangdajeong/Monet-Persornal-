using UnityEngine;

namespace YDJ
{
    public class FadeOut : MonoBehaviour
    {
        //[Header("Fada Out")]
        //[SerializeField] float time = 5;
        //[SerializeField] Material pointMat;
        //[SerializeField] Material lineMat;

        void Update()
        {
            gameObject.SetActive(false);  //쉐이더 타입 변경으로 얼룩덜룩함 제거, 투명도 조절 불가능으로 게임오브젝트만 꺼줌
        }

        //void Update()
        //{
        //    if (time > 0)
        //    {
        //        time -= Time.deltaTime;
        //        //float f = time / 10f;
        //        Color p = pointMat.color;
        //        Color l = lineMat.color;
        //        p.a = time;
        //        l.a = time;
        //        pointMat.color = p;
        //        lineMat.color = l;
        //    }
        //    else
        //        gameObject.SetActive(false);
        //        //Destroy(gameObject);

        //    // 메트리얼을 Transparent / Diffuse 바꾸기
        //}
    }
}
