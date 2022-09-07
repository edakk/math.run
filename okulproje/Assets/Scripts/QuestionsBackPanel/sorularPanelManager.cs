using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sorularPanelManager : MonoBehaviour
{


    [SerializeField]
    GameObject soruPaneli;

    [SerializeField]
    GameObject questionBackImage;


    GameManager gamemanager;
    questionManager questionmanager;

    private void Awake()
    {
        gamemanager = Object.FindObjectOfType<GameManager>();
        questionmanager = Object.FindObjectOfType<questionManager>();

    }




    void Update()
    {
        if (questionBackImage.transform.localPosition == new Vector3(30, 145, -57))

        {
          
          Time.timeScale = 0;


        }
   

        
    }
}


