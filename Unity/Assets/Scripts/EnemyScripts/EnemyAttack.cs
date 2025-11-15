using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
<<<<<<< HEAD
    bool DamageAreaActive;
    bool attackOnCooldown;
    bool inRange;
    float windUpTime;
    float currentWindUpTime;

    void Start()
    {
        attackOnCooldown = true;
        inRange = false;
        currentWindUpTime = 0f;
        DamageAreaActive = false;
        gameObject.SetActive(DamageAreaActive);
    } 
=======
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
>>>>>>> 63f1b3eb (Adding Health and Attack Tags and things)

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (inRange)
        {
            currentWindUpTime++;
        }

        if (currentWindUpTime >= windUpTime)
        {
            DoAttack();
        }
    }

    public void AttackRangeDetection()
    {
        Debug.Log("We are ready to attack!");
        inRange = true;
    }

    public void DoAttack()
    {
        DamageAreaActive = true;
        gameObject.SetActive(DamageAreaActive);
        DamageAreaActive = false;
=======
        
>>>>>>> 63f1b3eb (Adding Health and Attack Tags and things)
    }
}
