using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    [Header("스테이지 스폰 몬스터")]
    [SerializeField] public GameObject spawnEnemy;
    private int currentSpawnMonsterNumber = 0;

    [Header("스테이지 스폰 몬스터 부모 객체")]
    [SerializeField] public GameObject parentEnemy;
    private GameObject[] enemyPool;

    [Header("스테이지 당 스폰 몬스터 수")]
    [SerializeField] public int enemyNumber = 60;
    [Header("풀링 배열 크기 설정")]
    [SerializeField] public int enemyPoolNumber = 15;

    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        if (spawnEnemy == null || parentEnemy == null)
            return;
        enemyPool = new GameObject[enemyPoolNumber];
        for (int i = 0; i < enemyPoolNumber; i++)
        {
            //get monster information
            GameObject enemy = Instantiate(spawnEnemy, parentEnemy.transform);
            enemyPool[i] = enemy;
            enemyPool[i].SetActive(false);
        }

        StartCoroutine("EnableEnemy");
    }
    IEnumerator EnableEnemy()
    {
        yield return new WaitForSeconds(0.25f);

        if (currentSpawnMonsterNumber >= enemyNumber)
        {
            Debug.Log(string.Format("코루틴 중단"));
            StopCoroutine("EnableEnemy");
            yield return null;
        }

        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.active)
            {
                enemy.SetActive(true);
                Debug.Log(string.Format("{0} 마리 생성 되었습니다.", currentSpawnMonsterNumber));
                currentSpawnMonsterNumber++;
                break;
            }
        }

        StartCoroutine("EnableEnemy");
    }
}
