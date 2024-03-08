
using UnityEngine;

namespace Base.EnemyData
{
    [CreateAssetMenu(fileName = "Enemy data", menuName = "Scriptable Object/Enemy Data", order = int.MaxValue)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField]
        private string _enemyName;
        public string EenemyName { get { return _enemyName; } }
        [SerializeField]
        private int _enemyHP;
        public int EnemyHP { get { return _enemyHP; } }
        [SerializeField]
        private float _moveSpeed;
        public float MoveSpeed { get { return _moveSpeed; } }

        [Header("Enemy의 Sprite Name *불일치시 정상작동X*")]
        [SerializeField]
        private string _spriteName;
        public string spriteName {  get { return _spriteName; } }  
    }
}
