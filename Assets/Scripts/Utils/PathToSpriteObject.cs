using System;
using UnityEngine;
using Base.Singleton;

namespace Utils.PathToSprteObject
{
    public class PathToSpriteObject : Singleton<PathToSpriteObject>
    {
        protected PathToSpriteObject() { }

        public Sprite ConvertStringPathToSpriteObject(string path)
        {
            Sprite sprite = Resources.Load<Sprite>(path);
            if (sprite == null)
                Debug.Log("[Warning] Cannot Fnid Sprite Path!");
            return sprite;
        }
    }
}
