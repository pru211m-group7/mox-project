using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;

    public void Start()
    {
        
        rowStopped = true;
     //   audioPlayer = GetComponent<AudioSource>();
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
            
            stoppedSlot = "Boom";        
        }

        else if (transform.position.y == -4.01f)

        {
            
            stoppedSlot = "King";         
        }
        

        else if (transform.position.y == -3.27f)
        {         
            stoppedSlot = "Money";
        }
        

        else if (transform.position.y == -2.41f)
        {
            stoppedSlot = "Book";
        }
       

        else if (transform.position.y == -1.61f)
        {
            stoppedSlot = "Apple";
        }

        else if (transform.position.y == -0.81f)
        {
            stoppedSlot = "Medicine";
        }

        else if (transform.position.y == 0.03f)
        {
            stoppedSlot = "Leaf";
        }

        else if (transform.position.y == 0.83f)
        {
            stoppedSlot = "Beef";
        }

        else if (transform.position.y == 1.65f)
        {
            stoppedSlot = "Fish";
        }

        else if (transform.position.y == 2.41f)
            stoppedSlot = "Mushroom";
        rowStopped = true;
        
    }
    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;

    }
}
