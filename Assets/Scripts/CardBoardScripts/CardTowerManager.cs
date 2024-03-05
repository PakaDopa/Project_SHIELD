using UnityEngine;
using CardBaseScripts.ControlDelegate;
using Utils.ResourcePath;
using Base.TowerData;
using Base.Singleton;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CardTowerManager : MonoBehaviour
{
    [Header("Tower Parent Object")]
    [SerializeField] public GameObject _towersParent;

    void Start()
    {
        ControlDelegate.OnStart += SetTower;
    }

    public void SetTower(ScriptableObject _scripteableObject)
    {
        //조건 걸어주기 (돈 등등)

        //
        RaycastHit2D[] hits = RayColliderObjectManager.Instance.GetCurrentMouseRayColliderObjects(1 << LayerMask.NameToLayer("Plot"));
        if (hits.Length == 0 || hits.Length > 1 || _towersParent == null)
            return;

        //make object
        GameObject towerObj = (GameObject)Instantiate(Resources.Load(ResourcePath.PrefabTowerPath));
        TowerData towerData = (TowerData)_scripteableObject;
        towerObj.GetComponent<Tower>().towerData = towerData;
        towerObj.transform.position = new Vector3(
            hits[0].transform.position.x,
            hits[0].transform.position.y,
            hits[0].transform.position.z - 5);
        towerObj.name = "Tower";
        string path = ResourcePath.TexturesPath + towerData.spriteName;
        towerObj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
        towerObj.transform.parent = _towersParent.transform;
    }
}
