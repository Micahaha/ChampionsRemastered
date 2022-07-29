using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HealthSystem _healthSystem;
    public Text healthBarPercent;

    public void Setup(HealthSystem heatlhSystem) 
    {
        _healthSystem = heatlhSystem;
    }

    private void Start()
    {
        
        healthBarPercent.text += _healthSystem.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
