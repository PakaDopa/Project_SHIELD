using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBaseScripts.ControlDelegate;

using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class CardTowerManager : MonoBehaviour
{
    
    private int layer;
    void Start()
    {
        ControlDelegate.OnStart += SetTower;
        layer = 1 << LayerMask.NameToLayer("Plot");
    }

    public void SetTower(TowerInfo _towerInfo)
    {
        //make object
        var towerObj = Instantiate(new GameObject());
        towerObj.AddComponent<SpriteRenderer>();
        towerObj.GetComponent<SpriteRenderer>().sprite = _towerInfo._sprite;
        //towerObj.AddComponent<Tower>

        //get mouse Info
        RaycastHit2D hit = Physics2D.Raycast(
            Camera.main.ScreenToWorldPoint(Input.mousePosition),
            Vector3.forward,
            100.0f,
            layer);
        if (hit.transform != null)
        {
            //여기 소속 Tower 밑으로 보내줘야함.
            towerObj.transform.position = hit.transform.position;
        } 
    }
}
