using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sceleton_attack : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rigidbody;
    float speed = 1f;
    MonoBehaviour monoBehaviour;
    public float atcRadius = 2f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody2D>();
        monoBehaviour = animator.GetComponent<MonoBehaviour>();
        OnDrawGizmosSelected();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rigidbody.position, target, speed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPos);
        if (Vector2.Distance(player.position, rigidbody.position) <= atcRadius)
        {
            animator.SetTrigger("atcTrigger");
        }
    }

    // Удалить
    void OnDrawGizmosSelected()
    {
        if (player != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(player.position, atcRadius);
        }
    }
}
