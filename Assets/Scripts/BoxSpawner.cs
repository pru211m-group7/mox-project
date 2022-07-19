using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box_Prefab;
    public void SpawnBox()
    {
        GameObject box_Obj = Instantiate(box_Prefab);
        GameObject gameOver = GameObject.FindGameObjectWithTag("GameOver");
        gameOver.transform.position = new Vector3(0, gameOver.transform.position.y + 1f, 0);
        Vector3 temp = transform.position;
        temp.z = 0f;

        box_Obj.transform.position = temp;
    }
}
