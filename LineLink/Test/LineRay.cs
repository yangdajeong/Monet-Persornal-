using UnityEngine;

namespace YDJ
{
    public class LineRay : MonoBehaviour
    {
        [SerializeField] float maxDistance;
        [SerializeField] LayerMask layerMask;

        void Update()
        {
            Ray();
        }

        public bool Ray()
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.blue, 0.3f);

            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
            {
                return true;
            }
            return false;
        }
    }
}
