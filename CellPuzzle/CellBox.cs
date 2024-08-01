using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellBox : MonoBehaviour
{
    [SerializeField] CellKeyManager[] cellKeyManagers;
    [SerializeField] Animator boxOpen;
    public UnityEvent onOpen;

    public void OpenBox()
    {
        for (int i = 0; i < cellKeyManagers.Length; i++)
        {
            if (cellKeyManagers[i].SocketCheck == false)
                return;
        }
        boxOpen.enabled = true;
        onOpen?.Invoke();
    }
}
