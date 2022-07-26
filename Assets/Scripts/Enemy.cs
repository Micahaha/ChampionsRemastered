using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Enemy hurt");
        }
    }
}
