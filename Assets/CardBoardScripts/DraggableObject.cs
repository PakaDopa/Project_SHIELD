using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using CardBaseScripts.ControlDelegate;

public class DraggableObject : MonoBehaviour
{
    [HideInInspector]
    private float _magnification = 1.5f;
    private Vector3 _originScale = Vector3.zero;
    private Vector3 _originPosition = Vector3.zero;
    private SpriteRenderer _thisSpriteRenderer = null;
    private Sprite _originSprite = null;

    [Header("TowerInfo")]
    [SerializeField] private TowerInfo _towerInfo;

    void Start()
    {
        _thisSpriteRenderer = GetComponent<SpriteRenderer>();
        _originSprite = _thisSpriteRenderer.sprite;
        _originScale = transform.localScale;
        _originPosition = transform.position;
    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 objPos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, objPos.z);
    }
    private void OnMouseUp()
    {
        gameObject.transform.position = _originPosition;
        gameObject.transform.localScale = _originScale;

        //놨을 때, CardTower에 값 전송
        ControlDelegate.Instance.Disable_CardOnMouseUp(_towerInfo);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BoardZone"))
        {
            _thisSpriteRenderer.sprite = _towerInfo._sprite;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("UIZone"))
        {
            _thisSpriteRenderer.sprite = _originSprite;
            gameObject.transform.localScale = _originScale;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
