using System.Collections;
using UnityEngine;
using Base.Singleton;
using System.Collections.Generic;

public class TowerAttackManager : Singleton<TowerAttackManager>
{
    //Main Various
    private Queue<TowerAttackPacket> _attackQueue;
    private Queue _bufferQueue; //contain debuffer
    private int _maxCount = 100000;

    protected TowerAttackManager()
    {
        _attackQueue = new Queue<TowerAttackPacket>();
    }
    public void Add(TowerAttackPacket packet)
    {
        if(_attackQueue.Count < _maxCount)
            _attackQueue.Enqueue(packet);
    }
    private void Update()
    {
        while(_attackQueue.Count > 0)
        {
            //
            //Debug.Log("In Tower Update Function");
            TowerAttackPacket packet = _attackQueue.Dequeue();
            GameObject targetEnemy = packet.targetObject;
            if(targetEnemy != null)
            {
                float damage = packet.damage;
                Enemy enemy = targetEnemy.GetComponent<Enemy>();
                enemy.Hittd(packet);
            }
            //1. Queue contain data what ( target eneny, damage, hitted effect etc..)
            //2. target enemy trigger on 
        }
    }
}