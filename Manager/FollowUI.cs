using UnityEngine;

namespace YDJ
{
    public class FollowUI : MonoBehaviour
    {
        void LateUpdate()
        {
            transform.position = Camera.main.transform.position + Camera.main.transform.forward;

            transform.LookAt(Camera.main.transform.position);
        }
    }
}
