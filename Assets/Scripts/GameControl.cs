using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    private AudioSource audioPlayer;

    [SerializeField]
    private GameObject prizeText;
    
    [SerializeField]
    private Image imageTitle;
    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private Transform handle;
    private int prizeValue;
    private bool resultChecked = false;
    private bool IstartProgram = false;

    /* GameControl()
     {
         prizeText.enabled = false;
     } */

    public void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
       
    }
    public void Update()
    {
        
        if (resultChecked == false)
        {
            
            prizeText.SetActive(false) ;
            
            resultChecked = true;
        }

        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped || !rows[3].rowStopped)
        {
            prizeValue = 0;
                if(prizeText.activeSelf == true)
                {
                    prizeText.SetActive(false);
                }
            IstartProgram = true;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped)
        {
            audioPlayer.Stop();
            Debug.Log("NN");
            if (IstartProgram == true)
            {
                Thread.Sleep(700);
                IstartProgram = false;
                prizeText.SetActive(true);
             //   prizeText.text = "Prize" + prizeValue;
                resultChecked = true;
            }
            
            
        }
       


    }
    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped)
        {
            StartCoroutine("PullHandle");
            audioPlayer.Stop();
        }
    }
    
    private IEnumerator PullHandle()
    {
        Debug.Log("Right");
        for(int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }
        audioPlayer.Play();
        HandlePulled();
        for(int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    private void CheckResults()
    {
/*        if (rows[0].stoppedSlot == "Diamond" && rows[1].stoppedSlot == "Diamond" && rows[2].stoppedSlot == "Diamond")
            prizeValue = 200;
        else if (rows[0].stoppedSlot == "Crown" && rows[1].stoppedSlot == "Crown" && rows[2].stoppedSlot == "Crown")
            prizeValue = 400;
        else if (rows[0].stoppedSlot == "Melon" && rows[1].stoppedSlot == "Melon" && rows[2].stoppedSlot == "Melon")
            prizeValue = 600;
        else if (rows[0].stoppedSlot == "Bar" && rows[1].stoppedSlot == "Bar" && rows[2].stoppedSlot == "Bar")
            prizeValue = 800;
        else if (rows[0].stoppedSlot == "Seven" && rows[1].stoppedSlot == "Seven" && rows[2].stoppedSlot == "Seven")
            prizeValue = 1500;
        else if (rows[0].stoppedSlot == "Cherry" && rows[1].stoppedSlot == "Cherry" && rows[2].stoppedSlot == "Cherry")
            prizeValue = 3000;
        else if (rows[0].stoppedSlot == "Lemon" && rows[1].stoppedSlot == "Lemon" && rows[2].stoppedSlot == "Lemon")
            prizeValue = 5000;*/
        resultChecked = true;
    }

}
