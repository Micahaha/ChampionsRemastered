using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthSystem enemyHealthSystem;
    public GameObject ragdollPrefab;
    public Animator animator;

    void Start()
    {
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

    private void OnDestroy()
    {
        Instantiate(ragdollPrefab, gameObject.transform.position, gameObject.transform.rotation);
        
    }

}
