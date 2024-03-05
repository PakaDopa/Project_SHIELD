using UnityEngine;
using Base.Singleton;

public class RayColliderObjectManager : Singleton<RayColliderObjectManager>
{
    protected RayColliderObjectManager() { }
    public RaycastHit2D[] GetCurrentMouseRayColliderObjects(int layer)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(
            Camera.main.ScreenToWorldPoint(Input.mousePosition),
            Vector3.forward,
            Mathf.Infinity,
            layer);

        return hits;
    }
}

