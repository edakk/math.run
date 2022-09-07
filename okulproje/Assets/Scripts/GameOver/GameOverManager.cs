using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject GameOverPanel;
  
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            FindObjectOfType<AudioManager>().PlaySound("gameover");

            GameObject[] buttonsToDelete = GameObject.FindGameObjectsWithTag("butonusil");
            if (buttonsToDelete.Length >= 0)
            {
                for (int i = 0; i < buttonsToDelete.Length; i++)
                {
                    DestroyImmediate(buttonsToDelete[i]);
                }
            }
            
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
        
    }
}
