using UnityEngine;

namespace YDJ
{
    public class Bucket : MonoBehaviour
    {
        private int colorNum = 1;
        public int ColorNum { get { return colorNum; } set { colorNum = value; } }
        [SerializeField] LayerMask paintFurLayer;
        [SerializeField] Brush brush;

        private void OnTriggerEnter(Collider other)
        {
            if (paintFurLayer.Contain(other.transform.gameObject.layer))
            {
                other.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
                brush.ColorNum = colorNum;
            }
        }
    }
}
