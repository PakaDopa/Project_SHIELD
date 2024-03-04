using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [HideInInspector]
    private float _magnification = 1.5f;
    private Vector3 _originScale = Vector3.zero;
    private Vector3 _originPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        _originScale = transform.localScale;
        _originPosition = transform.position;
    }

    private void OnMouseEnter()
    {
        Vector3 value = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(value.x * _magnification, value.y * _magnification, 1);
    }
    private void OnMouseExit()
    {
        gameObject.transform.localScale  = _originScale;
    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 objPos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, objPos.z);
        Debug.Log(gameObject.transform.position);
    }
    private void OnMouseUp()
    {
        gameObject.transform.position = _originPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
