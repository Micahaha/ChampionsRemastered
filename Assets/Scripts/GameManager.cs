using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private HealthBar healthBar;
    public GameObject swordObject;

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem healthSystem = new HealthSystem(100);
        healthBar.Setup(healthSystem);


    }

    // Update is called once per frame
    void Update()
    {
    }

   
}
