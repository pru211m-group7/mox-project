using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;

    private void Start()
    {
        rowStopped = true;
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
        timeInterval = 0.25f;
        for(int i = 0; i <30; i++)
        {
            if (transform.position.y <= -2.9f)
                transform.position = new Vector2(transform.position.x, 2.35f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.8f);
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
            if (transform.position.y <= -2.9f)
                transform.position = new Vector2(transform.position.x, 2.35f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.8f);
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.1f))
                timeInterval = 0.2f;
            if (i > Mathf.RoundToInt(randomValue * 1.25f))
                timeInterval = 0.25f;
            yield return new WaitForSeconds(timeInterval);
        }
        if (transform.position.y == -2.9f)
            stoppedSlot = "Diamond";
        else if (transform.position.y == -2.1f)
            stoppedSlot = "Crown";
        else if (transform.position.y == -1.3f)
            stoppedSlot = "Melon";
        else if (transform.position.y == -0.6f)
            stoppedSlot = "Bar";
        else if (transform.position.y == 0.1f)
            stoppedSlot = "Seven";
        else if (transform.position.y == 0.9f)
            stoppedSlot = "Cherry";
        else if (transform.position.y == 1.6f)
            stoppedSlot = "Lemon";
        else if (transform.position.y == 2.3f)
            stoppedSlot = "Dia";
        rowStopped = true;
    }
    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }
}
