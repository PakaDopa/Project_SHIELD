
using UnityEngine;

namespace Base.TowerData
{
    [CreateAssetMenu(fileName = "Tower data", menuName = "Scriptable Object/Tower Data", order = int.MaxValue)]
    public class TowerData : ScriptableObject
    {
        [SerializeField]
        private string _towerName;
        public string towerName { get { return _towerName; } }
        [SerializeField]
        private float _attackSpeed;
        public float attackSpeed { get { return _attackSpeed; } }
        [SerializeField]
        private float _attackRange;
        public float attackRange { get { return _attackRange; } }

        [Header("Tower의 Sprite Name *불일치시 정상작동X*")]
        [SerializeField]
        private string _spriteName;
        public string spriteName {  get { return _spriteName; } }  

        //Skill ( active skill script, passive skill script )

        //Type (buffer, dealer [ short range, long range ])
    }
}
