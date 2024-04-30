using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTreeWithOranges : MonoBehaviour
{
    Animator animator;
    public int treeHp = 2;
    public Player player;
    public float rage = 0.5f;
    float distance;
    public GameObject peachPrefab;
    public GameObject applePrefab;
    public GameObject[] spawnPoints;
    private bool treeIsFelled = false;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckForHit();
    }

    void CheckForHit()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (Input.GetKeyDown(KeyCode.Q) && rage >= distance && treeHp > 0)
        {
            treeHp--;
            animator.SetTrigger("Hit_tree");
        }

        if (treeHp <= 0 && !treeIsFelled)
        {
            treeIsFelled = true;
            animator.SetTrigger("Falled_tree");
            StartCoroutine(SpawnApples());
        }
    }
    IEnumerator SpawnApples()
    {
        yield return new WaitForSeconds(1.9f);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(applePrefab, spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
