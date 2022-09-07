using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class questionInputManager : MonoBehaviour
{
    [SerializeField]
    GameObject sorularbackimage;
    
 
  
    GameOverManager gameovermanager;
    questionManager questionmanager;
    GameManager gamemanager;

    public bool answer = false;
    public string trueAnswer;



    private void Awake()
    {
      
        questionmanager = Object.FindObjectOfType<questionManager>();
   
        gamemanager = Object.FindObjectOfType<GameManager>();
    }


    public void ButtonA()
    {
        
        

        if("A"==trueAnswer)
        {
         
            answer = true;
           
        }
        else
        {

            answer = false;
        }
      

    }
    public void ButtonB()
    {



        if ("B" == trueAnswer)
        {

           


            answer = true;
        }
        else
        {
            answer = false;
           
        }
        
    }
    public void ButtonC()
    {



        if ("C" == trueAnswer)
        {
           
            answer = true;
     
        }
        else
        {
            answer = false;
            

        }
       
    }
  
}


