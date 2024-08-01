using UnityEngine;

namespace YDJ
{
    public class EyeTransform : MonoBehaviour
    {
        [SerializeField] GameObject linePackge;
        [SerializeField] float Range;
        [SerializeField] float Height;

        //public void Test1()
        //{
        //    linePackge.transform.position = Camera.main.transform.position + Camera.main.transform.forward * Range + Camera.main.transform.up * Height;
        //    linePackge.transform.forward = Camera.main.transform.forward;
        //    //linePackge.transform.position.z = 2;
        //    linePackge.SetActive(true);
        //    Destroy(gameObject);
        //}

        private void OnTriggerEnter(Collider other)
        {
            linePackge.SetActive(true);
        }
    }
}
