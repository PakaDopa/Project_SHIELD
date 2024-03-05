using UnityEngine;
using Base.Singleton;

namespace CardBaseScripts.ControlDelegate
{
    public class ControlDelegate : Singleton<ControlDelegate>
    {
        protected ControlDelegate() { }

        public delegate void CardOnMouseUpChainFunction(ScriptableObject _towerInfo);
        public static event CardOnMouseUpChainFunction OnStart;

        //Card Object, Mouse Up
        public void DisableCardOnMouseUp(ScriptableObject _towerInfo)
        {
            OnStart(_towerInfo);
        }
    }
}
