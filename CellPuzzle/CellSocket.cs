using UnityEngine;

public class CellSocket : MonoBehaviour
{
    //[SerializeField] Vector3 offset;
    //[SerializeField] float yOffset;

    void LateUpdate()
    {
        transform.position = Camera.main.transform.position;  
    /*+ Camera.main.transform.forward * offset.z
    + Camera.main.transform.up * offset.y
    + Camera.main.transform.right * offset.x;*/
        transform.forward = Camera.main.transform.forward;

        //transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);

        Vector3 camerRot = Camera.main.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(0, camerRot.y, transform.rotation.eulerAngles.z));
        //gameObject.transform.position = Camera.main.transform.position + offset;
    }
}
