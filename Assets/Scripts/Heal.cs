using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private bool isDamaging = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isDamaging)
        {
            StartCoroutine(DamagePlayer());
            Destroy(gameObject);
        }
    }

    IEnumerator DamagePlayer()
    {
        isDamaging = true;
        HeartSystem.healh += 1;
        yield return new WaitForSeconds(1);
        isDamaging = false;
        
    }
}
