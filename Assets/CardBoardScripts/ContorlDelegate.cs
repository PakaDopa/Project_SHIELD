using UnityEngine;
using System;
using Base.Singleton;

namespace CardBaseScripts.ControlDelegate
{
    public class ControlDelegate : Singleton<ControlDelegate>
    {
        protected ControlDelegate() { }

        public delegate void CardOnMouseUpChainFunction(TowerInfo _towerInfo);
        public static event CardOnMouseUpChainFunction OnStart;

        //Card Object, Mouse Up
        public void Disable_CardOnMouseUp(TowerInfo _towerinfo)
        {
            OnStart(_towerinfo);
        }
    }
}
