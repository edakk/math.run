using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public int disRun;
    public bool addingDis = false;

    public GameObject highDisplay;
    public int hiScoreCount;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Highest"))
        {
            hiScoreCount = PlayerPrefs.GetInt("Highest");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(addingDis==false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }
    IEnumerator AddingDis()
    {
        disRun += 1;
        disDisplay.GetComponent<Text>().text = "" + disRun;

        if(hiScoreCount < disRun)
        {
            hiScoreCount = disRun;
            highDisplay.GetComponent<Text>().text = "" + hiScoreCount;

            PlayerPrefs.SetInt("Highest", hiScoreCount);
        }
        highDisplay.GetComponent<Text>().text = "" + hiScoreCount;

        yield return new WaitForSeconds(0.25f);
        addingDis = false;
    }

    


}
