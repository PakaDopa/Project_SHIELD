using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2.0f;

    private Transform target;
    private int pathIndex = 0;
    private Vector3 savePos = Vector3.zero;

    private void Start()
    {
        savePos = transform.position;
        target = LevelManager.main.path[pathIndex];
    }
    // Update is called once per frame
    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            if (pathIndex == LevelManager.main.path.Length)
            {
                ResetEnemyPosition();
                gameObject.SetActive(false);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    public void ResetEnemyPosition()
    {
        pathIndex = 0;
        target = LevelManager.main.path[pathIndex];
        transform.position = savePos;
    }
}
