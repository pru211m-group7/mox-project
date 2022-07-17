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
        for (int i = 0; i < 15; i++)
        {
            if (transform.position.y <= -4.8f)
                transform.position = new Vector2(transform.position.x, 2.53f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.81f);
            yield return new WaitForSeconds(timeInterval);


        }
        randomValue = Random.Range(60, 100);
       

        for (int i = 0; i < randomValue; i++)
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
        if (transform.position.y >= -5f && transform.position.y <= -4.64f)
        {

            stoppedSlot = "Boom";
        }

        else if (transform.position.y >= -4.3f && transform.position.y <= -3.9f)

        {

            stoppedSlot = "King";
        }


        else if (transform.position.y >= -3.27f && transform.position.y <= -3.0f)
        {
            stoppedSlot = "Money";
        }


        else if (transform.position.y >= -2.65f && transform.position.y <= -2.2f)
        {
            stoppedSlot = "Book";
        }


        else if (transform.position.y >= -1.9 && transform.position.y <= -1.3f)
        {
            stoppedSlot = "Apple";
        }

        else if (transform.position.y >= -1.0 && transform.position.y <= -0.41f)
        {
            stoppedSlot = "Medicine";
        }

        else if (transform.position.y >= -0.31f && transform.position.y <= 0.36f)
        {
            stoppedSlot = "Leaf";
        }

        else if (transform.position.y >= 0.46f && transform.position.y <= 1.15f)
        {
            stoppedSlot = "Beef";
        }

        else if (transform.position.y >= 1.29f && transform.position.y <= 2.05f)
        {
            stoppedSlot = "Fish";
        }

        else if (transform.position.y >= 2.08f && transform.position.y <= 2.8f)
            stoppedSlot = "Mushroom";
        rowStopped = true;

    }
    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;

    }
}
