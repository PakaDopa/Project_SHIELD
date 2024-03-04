using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngineInternal;

public class TowerCardController : MonoBehaviour
{
    void Start()
    {
        // Test Code
        int count = 5;
        for(int i = 0; i < count; i++)
        {
            GameObject obj = Resources.Load<GameObject>("Prefabs/TowerCard");
            var realObj = Instantiate(obj, this.transform);
            realObj.transform.position = new Vector3(realObj.transform.position.x + i * 1, realObj.transform.position.y, realObj.transform.position.z);
        }
    }
}
    