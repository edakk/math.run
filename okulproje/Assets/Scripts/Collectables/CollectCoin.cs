using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{

    public AudioSource coinFX;
    LevelDistance leveldistance;
    private void Start()
    {
        leveldistance = FindObjectOfType<LevelDistance>();
    }



    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollectableController.coinCount += 1;
       if(CollectableController.coinCount % 5 == 0)
        {
            leveldistance.disRun += 10;
        }
        this.gameObject.SetActive(false);
    }
}
