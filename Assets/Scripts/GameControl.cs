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
    private GameObject textLose;
    [SerializeField]
    private Text win;
    [SerializeField]
    private Image imageTitle;
    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private Transform handle;
    //   private int prizeValue;
    private bool resultChecked = false;
    private bool IstartProgram = false;

    /* GameControl()
     {
         textLose.enabled = false;
     } */

    public void Start()
    {
        audioPlayer = GetComponent<AudioSource>();

    }
    public void Update()
    {

        if (resultChecked == false)
        {


            win.enabled = false;
            textLose.SetActive(false);

            resultChecked = true;
        }

        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped || !rows[3].rowStopped)
        {

            if (textLose.activeSelf == true)
            {
                textLose.SetActive(false);
            }
            if (win.enabled == true)
            {
                win.enabled = false;
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
                textLose.SetActive(true);
                CheckResults();
                resultChecked = true;
                IstartProgram = false;
            }
        }
        /*        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && !resultChecked)
                {
                    audioPlayer.Stop();
                    CheckResults();
                    win.enabled = true;
                }*/
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
        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }
        audioPlayer.Play();
        HandlePulled();
        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }

    }
    private void CheckResults()
    {
        //***********************BOOM*****************************//
        if (rows[0].stoppedSlot == "Boom" && rows[1].stoppedSlot == "Boom" || rows[2].stoppedSlot == "Boom" && rows[3].stoppedSlot == "Boom")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Boom" && rows[2].stoppedSlot == "Boom" || rows[1].stoppedSlot == "Boom" && rows[3].stoppedSlot == "Boom")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Boom" && rows[3].stoppedSlot == "Boom" || rows[1].stoppedSlot == "Boom" && rows[2].stoppedSlot == "Boom")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        //***********************KING****************************//
        if (rows[0].stoppedSlot == "King" && rows[1].stoppedSlot == "King" || rows[2].stoppedSlot == "King" && rows[3].stoppedSlot == "King")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "King" && rows[2].stoppedSlot == "King" || rows[1].stoppedSlot == "King" && rows[3].stoppedSlot == "King")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "King" && rows[3].stoppedSlot == "King" || rows[1].stoppedSlot == "King" && rows[2].stoppedSlot == "King")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        //***********************BOOK****************************//
        if (rows[0].stoppedSlot == "Book" && rows[1].stoppedSlot == "Book" || rows[2].stoppedSlot == "Book" && rows[3].stoppedSlot == "Book")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Book" && rows[2].stoppedSlot == "Book" || rows[1].stoppedSlot == "Book" && rows[3].stoppedSlot == "Book")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Book" && rows[3].stoppedSlot == "Book" || rows[1].stoppedSlot == "Book" && rows[2].stoppedSlot == "Book")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }

        //***********************MONEY****************************//
        if (rows[0].stoppedSlot == "Money" && rows[1].stoppedSlot == "Money" || rows[2].stoppedSlot == "Money" && rows[3].stoppedSlot == "Money")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Money" && rows[2].stoppedSlot == "Money" || rows[1].stoppedSlot == "Money" && rows[3].stoppedSlot == "Money")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Money" && rows[3].stoppedSlot == "Money" || rows[1].stoppedSlot == "Money" && rows[2].stoppedSlot == "Money")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        //***********************APPLE****************************//
        if (rows[0].stoppedSlot == "Apple" && rows[1].stoppedSlot == "Apple" || rows[2].stoppedSlot == "Apple" && rows[3].stoppedSlot == "Apple")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Apple" && rows[2].stoppedSlot == "Apple" || rows[1].stoppedSlot == "Apple" && rows[3].stoppedSlot == "Apple")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Apple" && rows[3].stoppedSlot == "Apple" || rows[1].stoppedSlot == "Apple" && rows[2].stoppedSlot == "Apple")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        //***********************MEDICINE****************************//
        if (rows[0].stoppedSlot == "Medicine" && rows[1].stoppedSlot == "Medicine" || rows[2].stoppedSlot == "Medicine" && rows[3].stoppedSlot == "Medicine")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Medicine" && rows[2].stoppedSlot == "Medicine" || rows[1].stoppedSlot == "Medicine" && rows[3].stoppedSlot == "Medicine")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }
        else if (rows[0].stoppedSlot == "Medicine" && rows[3].stoppedSlot == "Medicine" || rows[1].stoppedSlot == "Medicine" && rows[2].stoppedSlot == "Medicine")
        {
            win.enabled = true;
            textLose.SetActive(false);
        }

        //resultChecked = true;
    }

}
