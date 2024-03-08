using Base.TowerData;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    public enum STATE
    {
        NONE = 0,
        ATTACK,
        ATTACK_DELAY, // ANIMATION TIME
        STOP, // DEBUG
    }
    public TowerData towerData = default(TowerData);
    private GameObject enemyGroup = default(GameObject);
    private STATE _towerState = STATE.NONE;
    private GameObject targetEnemy = default(GameObject);
    // Debug Test Code
    // 원래는 애니메이션으로 공격관리하나 일단은 테스트용도로 만듦.

    // Start is called before the first frame update
    void Start()
    {
        //find enemyGroup
        GameObject towerGroup = gameObject.transform.parent.gameObject;
        GameObject gameBoard = towerGroup.transform.parent.gameObject;
        
        enemyGroup = gameBoard.transform.Find("Enemys").gameObject;
        if (enemyGroup == null)
            Debug.LogError("Cannot Find enemyGroup!");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyGroup == null)
            return;
       
        //state Normal
        switch (_towerState)
        {
            case STATE.NONE:
                {
                    float minDist = Mathf.Infinity;

                    //first enemy find
                    for (int i = 0; i < enemyGroup.transform.childCount; i++)
                    {
                        GameObject enemy = enemyGroup.transform.GetChild(i).gameObject;

                        float dist = Vector2.Distance(transform.position, enemy.transform.position);
                        if (dist <= towerData.attackRange && dist < minDist)
                        {
                            minDist = dist;
                            targetEnemy = enemy;
                        }
                    }

                    if (targetEnemy != null)
                    {
                        _towerState = STATE.ATTACK;
                        //debug code
                        Vector3 differ = transform.position - targetEnemy.transform.position;
                        
                        float angle = Mathf.Atan2(differ.y, differ.x) * Mathf.Rad2Deg;
                        Quaternion angleAxis = Quaternion.AngleAxis(angle - 180, Vector3.forward);
                        Quaternion rotaion = Quaternion.Slerp(transform.rotation, angleAxis, 3);
                        transform.rotation = rotaion;
                    }
                    break;
                }
            case STATE.ATTACK:
                {
                    // 대상 오브젝트가 활성화 되어 있는지 검사
                    if(targetEnemy != null && targetEnemy.activeSelf)
                        _towerState = STATE.ATTACK_DELAY;        
                    break;
                }
            case STATE.ATTACK_DELAY:
                {
                    _towerState = STATE.STOP;
                    StartCoroutine(DebugAttackDelay(targetEnemy));
                    //코루틴 끝
                    break;
                }
            case STATE.STOP:
                break;
        }
        
    }
    IEnumerator DebugAttackDelay(GameObject enemy)
    {
        //TEST CODE
        yield return new WaitForSeconds(towerData.attackSpeed);

        //attcking!
        Debug.Log(string.Format("{0} hitted!!", enemy.name));
        TowerAttackPacket packet = new TowerAttackPacket();
        packet.targetObject = enemy;
        TowerAttackManager.Instance.Add(packet);
        _towerState = STATE.NONE;   
    }
}
