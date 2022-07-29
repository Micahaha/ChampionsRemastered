using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthSystem enemyHealthSystem;
    private Animator animator;
    

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        enemyHealthSystem = new HealthSystem(80);
    }



    // Update is called once per frame
    void Update()
    {
        enemyHealthSystem.onDeath(gameObject);

    }

    void onHit() 
    {
        animator.SetTrigger("OnHit");       
    }

    public void Damage(int damage) 
    {
        enemyHealthSystem.Damage(damage);
        onHit();
    }

}
