using UnityEngine;

namespace YDJ
{
    public class LineController : MonoBehaviour
    {
        [SerializeField] LineLink lineLink;
        [SerializeField] LineRay lineRay;

        private void LinkStop()
        {
            if (lineRay.Ray())
            {
                lineLink.enabled = false;
            }
        }
    }
}
