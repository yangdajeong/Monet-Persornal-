using UnityEngine;

namespace YDJ
{
    public class CellRange : MonoBehaviour
    {
        [SerializeField] LayerMask playerLayer;
        [SerializeField] Transform respawnPoint;

        private void OnTriggerExit(Collider other)
        {
            if (playerLayer.Contain(other.gameObject.layer))
            {
                //gameObject.transform.position = respawnPoint.position;
                //GetComponentInParent<Transform>().position = respawnPoint.position;
                transform.parent.position = respawnPoint.position;
                transform.parent.localRotation = Quaternion.identity;
                //transform.position = respawnPoint.position;
                //transform.rotation = Quaternion.identity;
            }
        }
    }
}
