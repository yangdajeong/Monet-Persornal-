using UnityEngine;

namespace YDJ
{
    public class CameraRay : MonoBehaviour
    {
        [SerializeField] PointCube canvasScreen;
        [SerializeField] LayerMask paintObjectLayer;

        public GameObject RayFire()
        {
            //Debug.DrawRay(gameObject.transform.position , canvasScreen.FixVector3() - gameObject.transform.position,Color.red);

            if (Physics.Raycast(gameObject.transform.position, (canvasScreen.FixVector3() - gameObject.transform.position).normalized, out RaycastHit hit, 100f, paintObjectLayer))
            {
                return hit.collider.gameObject;
            }
            return null;
        }
    }
}
