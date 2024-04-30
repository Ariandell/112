using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isDamaging = false;
    IEnumerator DamagePlayer()
    {
        isDamaging = true;
        HeartSystem.healh -= 1;
        yield return null;
        isDamaging = false;

    }
}