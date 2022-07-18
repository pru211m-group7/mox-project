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
    private GameObject textWin;
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

            textWin.SetActive(false);
          //  win.enabled = false;
            textLose.SetActive(false);

            resultChecked = true;
        }

        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped || !rows[3].rowStopped)
        {

            if (textLose.activeSelf == true)
            {
                textLose.SetActive(false);
            }
            /*if (win.enabled == true)
            {
                win.enabled = false;
            }*/
            if (textWin.activeSelf == true)
            {
                textWin.SetActive(false);
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
        int i = 0;
        for(int j=3; j >= i+1; j--)
        {
            if (rows[i].stoppedSlot == rows[j].stoppedSlot)
            {
                textWin.SetActive(true);
                textLose.SetActive(false);
                break;
            }

            if ((j == i+1) && (i < 3))
            {
                i++;
                j = 4;
            }
        }
    }

}
