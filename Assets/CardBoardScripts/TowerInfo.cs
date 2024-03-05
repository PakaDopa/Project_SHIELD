using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] public float _damage = 1.0f;
    
    [Header("Attack Range (radius)")]
    [SerializeField] public float _attackRange = 5.0f;

    [Header("Tower Sprite")]
    [SerializeField] public Sprite _sprite;
}
