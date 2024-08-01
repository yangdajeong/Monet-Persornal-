using UnityEngine;

namespace YDJ
{
    public class DirectionCube : MonoBehaviour
    {
        [SerializeField] LayerMask directCube;
        [SerializeField] bool direct = false;
        public bool Direct { get { return direct; } }

        private void OnTriggerEnter(Collider other)
        {
            if (directCube.Contain(other.gameObject.layer))
            {
                direct = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (directCube.Contain(other.gameObject.layer))
            {
                direct = false;
            }
        }
    }
}
