using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas healthBar;
    public string healthText;
    public Player player;
    public GameObject GameOver;
    public GameObject youWin;
    private bool onGameOver;


    void Update()
    {
     
        GameOver.SetActive(false);
        youWin.SetActive(false);

       healthText = "health: " + player.healthSystem.GetHealth();
       healthBar.GetComponentInChildren<Text>().text = healthText;

       
       

        Debug.Log(player.healthSystem.GetHealth());

        if (player.healthSystem.GetHealth() == 0) 
        {
            onGameOver = true;
           
        }

        if (onGameOver) 
        {
            GameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }

        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) 
        {
            youWin.SetActive(true);
            GameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}


