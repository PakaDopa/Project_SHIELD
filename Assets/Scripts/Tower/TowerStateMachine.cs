using UnityEngine;

public class TowerStateMachine
{
    public enum State
    {
        NORMAL = 0,
        ATTACK,
        ATTACK_DELAY, //animation

        STOP, // debug
    }
    
}