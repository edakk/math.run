using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
 

    [SerializeField]
    GameObject questionBackImage;

    GameOverManager gameovermanager;
    public GameObject GameOverPanel;

    public bool repeatPanel = false;
 

   questionManager questionmanager;
    questionInputManager questioninputmanager;

    public int countCoroutine = 0;

    private void Awake()
    {
        questionmanager = Object.FindObjectOfType<questionManager>();
        questioninputmanager = Object.FindObjectOfType<questionInputManager>();
        gameovermanager = Object.FindObjectOfType<GameOverManager>();
    }


    private void Update()
    {
        

            if (repeatPanel == false)
            {

                if(countCoroutine >= 50)

             {
                countCoroutine = 0;
             }
            
               StartCoroutine(openPanel());
               countCoroutine++;
               repeatPanel = true;
            }
        
    }
    
    IEnumerator openPanel()


    {

        yield return new WaitForSecondsRealtime(6f);
        
        questionBackImage.GetComponent<RectTransform>().DOAnchorPosX(30, 1f);

        questionmanager.PrintQuestions();
        
        yield return new WaitForSecondsRealtime(4f);



        if (questioninputmanager.answer == true)

        {
            questionBackImage.GetComponent<RectTransform>().DOAnchorPosX(-1200, 1f);
            repeatPanel = false;
            questioninputmanager.answer = false;
        }

        else 

        {
           
           
            yield return new WaitForSecondsRealtime(.2f);
            GameOverManager.gameOver = true;
            
        }
       
    
    }
  
}
