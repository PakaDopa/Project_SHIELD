using System.Collections;
using UnityEditor;
using UnityEngine;

public class TowerAttackPacket : ScriptableObject
{
    public GameObject targetObject { get; set; }
    public int damage { get; set; }
    //public Effect data
    //public Damage Type ( 마뎀? 물뎀?)
}
