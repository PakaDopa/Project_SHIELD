using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnMouseDrag()
    {
        //Vector3 newWorldPosition = new Vector3(_controller.currentMousePosition.x, _controller.currentMousePosition.y, _controller.currentMousePosition.z);
        
        //var differ = newWorldPosition - transform.position;
        ////Debug.Log(string.Format("{0},    {1}", newWorldPosition, differ));
        //_rigidbody.velocity = differ * 10;
        //_rigidbody.rotation = Quaternion.Euler(new Vector3(_rigidbody.velocity.z, 0, -_rigidbody.velocity.x));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
