using UnityEngine;
using Base.EnemyData;
using UnityEditor.Build.Content;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Data ScriptableObject")]
    [SerializeField] private EnemyData enemyData;

    //real info
    private int _hp;
    //private void sprite;
    private void Start()
    {
        //_hp = enemyData.EnemyHP;
        _hp = 10;
    }
    public void Hittd(TowerAttackPacket packet)
    {
        float damage = packet.damage;
        _hp -= _hp;

        if(damage <= 0)
        {
            gameObject.GetComponent<EnemyMovement>().ResetEnemyPosition();
            gameObject.SetActive(false);
        }
    }
}
