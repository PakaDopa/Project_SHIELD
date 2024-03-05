using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotScript : MonoBehaviour
{
    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
