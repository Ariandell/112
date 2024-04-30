using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    private Rigidbody2D rb;
    private bool UpPressed;
    private bool DownPressed;
    private bool LeftPressed;
    private bool RightPressed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Mining");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Watering");
        }
        UpPressed = Input.GetKey(KeyCode.W);
        DownPressed = Input.GetKey(KeyCode.S);
        LeftPressed = Input.GetKey(KeyCode.A);
        RightPressed = Input.GetKey(KeyCode.D);

        SetAnimatorParameters();
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (!isMoving)
        {
            if (input.x != 0) input.y = 0;
            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                StartCoroutine(Move(targetPos));
            }
        }
    }

    private void SetAnimatorParameters()
    {
        if (UpPressed)
            animator.SetBool("Up", true);
        else
            animator.SetBool("Up", false);

        if (DownPressed)
            animator.SetBool("Down", true);
        else
            animator.SetBool("Down", false);

        if (LeftPressed)
            animator.SetBool("Left", true);
        else
            animator.SetBool("Left", false);

        if (RightPressed)
            animator.SetBool("Right", true);
        else
            animator.SetBool("Right", false);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
