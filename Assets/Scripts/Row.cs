using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;
    public AudioSource audioPlayer;

    public bool rowStopped;
    public string stoppedSlot;

    public void Start()
    {
        
        rowStopped = true;
        audioPlayer = GetComponent<AudioSource>();
        GameControl.HandlePulled += StartRotating;

    }

    private void StartRotating()
    {

        stoppedSlot = "";
        StartCoroutine("Rotate");
    }
    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.05f;
        for(int i = 0; i <15; i++)
        {
            if (transform.position.y <= -4.8f)
                transform.position = new Vector2(transform.position.x, 2.53f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.81f);
            yield return new WaitForSeconds(timeInterval);
            

        }
         randomValue = Random.Range(60, 100);
       // randomValue += 3 - (randomValue % 3);
        switch (randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }

        for (int i = 0; i<randomValue; i++)
        {
            if (transform.position.y <= -4.8f)
                transform.position = new Vector2(transform.position.x, 2.53f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.81f);
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.08f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.09f;
            if (i > Mathf.RoundToInt(randomValue * 0.1f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 1.25f))
                timeInterval = 0.1f;
            yield return new WaitForSeconds(timeInterval);
            
        }
        if (transform.position.y == -4.89f)
        {
            
            stoppedSlot = "Diamond";
            audioPlayer.Play();
        }

        else if (transform.position.y == -4.01f)

        {
            
            stoppedSlot = "Crown";
            audioPlayer.Play();
        }
        

        else if (transform.position.y == -3.27f)
        {
            audioPlayer.Play();
            stoppedSlot = "Melonnnn";
        }
        

        else if (transform.position.y == -2.41f)
        {
            audioPlayer.Play();
            stoppedSlot = "Crown";
        }
       

        else if (transform.position.y == -1.61f)
        {
            audioPlayer.Play();
            stoppedSlot = "Melon";
        }
      //  stoppedSlot = "Melon";

        else if (transform.position.y == -0.81f)
        {
            audioPlayer.Play();
            stoppedSlot = "Bar";
        }
      //  stoppedSlot = "Bar";

        else if (transform.position.y == 0.03f)
        {
            audioPlayer.Play();
            stoppedSlot = "Seven";
        }
      //  stoppedSlot = "Seven";

        else if (transform.position.y == 0.83f)
        {
            audioPlayer.Play();
            stoppedSlot = "Cherry";
        }
     //   stoppedSlot = "Cherry";

        else if (transform.position.y == 1.65f)
        {
            audioPlayer.Play();
            stoppedSlot = "Lemon";
        }
      //  stoppedSlot = "Lemon";

        else if (transform.position.y == 2.41f)
            stoppedSlot = "Dia";
        rowStopped = true;
        
    }
    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;

    }
}
