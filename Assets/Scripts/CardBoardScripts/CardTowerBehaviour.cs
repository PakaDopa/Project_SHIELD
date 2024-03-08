using UnityEngine;
using CardBaseScripts.ControlDelegate;

using Utils.ResourcePath;
using Base.TowerData;
using Base.CustomDebug;
using Unity.VisualScripting;

public class CardTowerBehaviour : MonoBehaviour
{
    [HideInInspector]
    private float _magnification = 1.5f;
    private Vector3 _originScale = Vector3.zero;
    private Vector3 _originPosition = Vector3.zero;
    private SpriteRenderer _thisSpriteRenderer = null;
    private Sprite _originSprite = null;

    //TestCode
    [Header("Tower ScriptableObject")]
    [SerializeField] public ScriptableObject _towerData = null;

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

    /// <summary>
    /// Tower Object Setting On Plot (When MouseUp)
    /// </summary>
    private void OnMouseUp()
    {
        gameObject.transform.position = _originPosition;
        gameObject.transform.localScale = _originScale;

        //TEST CODE
        ControlDelegate.Instance.DisableCardOnMouseUp(_towerData);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("UIZone"))
        {
            _thisSpriteRenderer.sprite = _originSprite;
            gameObject.transform.localScale = _originScale;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("UIZone"))
        {
            //TEST CODE
            TowerData towerData = (TowerData)_towerData;
            _thisSpriteRenderer.sprite = Resources.Load<Sprite>(ResourcePath.TexturesPath + towerData.spriteName);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
