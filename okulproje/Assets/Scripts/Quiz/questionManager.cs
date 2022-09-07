using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using DG.Tweening;

using UnityEngine.UI;
public class questionManager : MonoBehaviour
{
    [SerializeField]
    List<questionItem> questionList;

    [SerializeField]
    TMP_Text questionTxt;

    [SerializeField]
    GameObject answerPrefab;

    [SerializeField]
    Transform answerContainer;


    GameManager gamemanager;

   
    int answerCount;

    string[] options = { "A", "B", "C" };


    questionInputManager questioninputmanager;
    public int whichQuestion;

    private void Awake()
    {
    
        gamemanager = Object.FindObjectOfType<GameManager>();

        questioninputmanager = Object.FindObjectOfType<questionInputManager>();
      
    }






    private void Start()
    {
      

        questionList = questionList.OrderBy(i => Random.value).ToList();

    }




    public void PrintQuestions()
    {
             whichQuestion = gamemanager.countCoroutine;
             answerCount = 0;
             questionTxt.text = questionList[whichQuestion].soru;


            questionTxt.GetComponent<CanvasGroup>().alpha = 0f;
            questionTxt.GetComponent<RectTransform>().localScale = Vector3.zero; //animasyonla acmak için

        CreateAnswers();

    }

    void CreateAnswers()

    { 
    
      GameObject[] buttonsToDelete = GameObject.FindGameObjectsWithTag("cevapTag");
        if(buttonsToDelete.Length>=0)
        {
            for(int i=0; i< buttonsToDelete.Length;i++)
            {
                DestroyImmediate(buttonsToDelete[i]);
            }
        }

    
        for (int i = 0; i < 3; i++)
        {
            GameObject cevapObje = Instantiate(answerPrefab);

            cevapObje.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = options[i];

            cevapObje.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = questionList[whichQuestion].cevaplar[i].ToString();
            cevapObje.transform.SetParent(answerContainer);

            cevapObje.GetComponent<Transform>().localScale = Vector3.zero;

        }

     
        
        questioninputmanager.trueAnswer = questionList[whichQuestion].dogruCevap;


        whichQuestion++;

      PrintAnswers();
      
      
    }

    
 
  void PrintAnswers()
    {


        questionTxt.GetComponent<CanvasGroup>().DOFade(1, .1f);

        questionTxt.GetComponent<RectTransform>().DOScale(1, .1f);

   
        while(answerCount<3)
        {
   
         answerContainer.GetChild(answerCount).DOScale(1,.2f);
      
            answerCount++;
        }

       whichQuestion++;

    }    

}
