using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] items;
    public Transform spawnPoint;
    public float spawnRadius = 1f;

    private bool isOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            if (Vector2.Distance(transform.position, Player.Instance.transform.position) <= spawnRadius)
            {
                GetComponent<Animator>().SetTrigger("chest");
                SpawnRandomItem();
                isOpen = true;
            }
        }
    }

    private void SpawnRandomItem()
    {
        if (items.Length == 0)
        {
            Debug.LogWarning("Пусто");
            return;
        }

        int randomIndex = Random.Range(0, items.Length);
        GameObject itemToSpawn = items[randomIndex];

        Instantiate(itemToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
