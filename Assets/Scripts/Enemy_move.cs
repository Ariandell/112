using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    private bool faceRight = false;
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 moveVector = player.transform.position - transform.position;

            if ((moveVector.x > 0 && faceRight) || (moveVector.x < 0 && !faceRight))
            {
                transform.localScale *= new Vector2(-1, 1);
                faceRight = !faceRight;
            }
        }
    }
}
