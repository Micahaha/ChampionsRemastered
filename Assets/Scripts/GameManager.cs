using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public GameObject swordObject;
    HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem(100);
        healthBar.Setup(healthSystem);


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(healthSystem.GetHealthPercent());
    }

   
}
