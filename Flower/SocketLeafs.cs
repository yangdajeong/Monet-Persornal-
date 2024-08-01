using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace YDJ
{

    public class SocketLeafs : MonoBehaviour
    {
        private XRSocketInteractor socketInteractor;

        //꽃잎을 떼면 다시 못붙게 소켓인터렉터 비활성화
        private void Start()
        {
            socketInteractor = GetComponent<XRSocketInteractor>();
        }

        public void LeafExit()
        {
            socketInteractor.enabled = false;
        }
    }
}
