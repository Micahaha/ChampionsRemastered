using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float health = 100;
    public HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem(health);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy hit Player");

        if (other.gameObject.CompareTag("Weapon"))
        {
            healthSystem.Damage(7);
        }
    }



    
}
