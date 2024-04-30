using UnityEngine;

public class Vegetables : MonoBehaviour
{
    public GameObject plant;
    public float growthDuration = 10f;
    public Animator animator;
    public Player player;
    public float range = 1f;

    private bool isGrowing = false;
    private bool canWater = true;
    private bool canHarvest = false;
    private int currentState = 0;
    private float growthTimer = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        bool isNearPlant = distance <= range;

        if (isNearPlant)
        {
            if (canWater && Input.GetKeyDown(KeyCode.Q))
            {
                Water();
            }
            else if (canHarvest && Input.GetKeyDown(KeyCode.E))
            {
                Harvest();
            }
        }

        if (isGrowing)
        {
            growthTimer += Time.deltaTime;
            if (growthTimer >= growthDuration)
            {
                if (currentState == 3)
                {
                    canHarvest = true;
                }
                else
                {
                    canWater = true;
                }
                growthTimer = 0f;
            }
        }
    }
    private void Water()
    {
        canWater = false;
        isGrowing = true;
        growthTimer = 0f;

        if (currentState == 0)
        {
            animator.SetTrigger("state1");
            currentState = 1;
        }
        else if (currentState == 1)
        {
            animator.SetTrigger("state2");
            currentState = 2;
        }
        else if (currentState == 2)
        {
            animator.SetTrigger("state3");
            currentState = 3;
        }
    }
    private void Harvest()
    {
        canHarvest = false;
        currentState = 0;
        Instantiate(plant, transform.position, Quaternion.identity);
        animator.SetTrigger("state0");
        canWater = true;
        isGrowing = false;
        growthTimer = 0f;
    }
}