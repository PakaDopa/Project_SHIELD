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

    [Header("Spawn Enemy")]
    [SerializeField] public GameObject spawnEnemy;
    private int currentSpawnMonsterNumber = 0;

    [Header("Spawn FolderObject Enemy")]
    [SerializeField] public GameObject parentEnemy;
    private GameObject[] enemyPool;

    [Header("Spawn Enemy Number")]
    [SerializeField] public int enemyNumber = 60;
    [Header("Enemy Pool Number (ObjectPooling")]
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
        yield return new WaitForSeconds(0.5f);

        if (currentSpawnMonsterNumber >= enemyNumber)
        {
            //Debug.Log(string.Format("End Coroutine"));
            StopCoroutine("EnableEnemy");
            yield return null;
        }

        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
                //Debug.Log(string.Format("{0}st spawn enemy!", currentSpawnMonsterNumber));
                currentSpawnMonsterNumber++;
                break;
            }
        }

        StartCoroutine("EnableEnemy");
    }
}
