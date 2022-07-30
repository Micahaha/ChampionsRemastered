using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas healthBar;
    public string healthText;
    public Player player;

    void Update()
    {
       healthText = "health: " + player.healthSystem.GetHealth();
       healthBar.GetComponentInChildren<Text>().text = healthText;



        Debug.Log(player.healthSystem.GetHealth());

        if (player.healthSystem.GetHealth() == 0) 
        {
            Debug.Log("Gameover");
            Destroy(player.gameObject);
        }

    }

   
}
