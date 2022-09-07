using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverEvents : MonoBehaviour
{
   public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
        CollectableController.coinCount = 0;

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
