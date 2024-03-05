using Base.TowerData;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlotScript : MonoBehaviour
{
    [SerializeField] private LineRenderer renderer;

    private void OnMouseEnter()
    {
        DrawCicle(4, 120);
    }
    private void OnMouseLeave()
    {
        renderer.positionCount = 0;
    }
    public void DrawCicle(float radius, int steps)
    {
        Vector3 objectPosition = gameObject.transform.position;
        renderer.positionCount = steps;

        for(int i = 0; i < steps; i++)
        {
            float circumferenceProgress = (float)i / steps;

            float currentRadian = circumferenceProgress * 4 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(objectPosition.x + x, objectPosition.y + y, objectPosition.z);

            renderer.SetPosition(i, currentPosition);
        }
    }
}
