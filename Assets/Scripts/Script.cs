using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Script : MonoBehaviour
{
    // Start is called before the first frame update
    float time, second;
    [SerializeField]
    public Image FillImage;
    void Start()
    {
        second = 5;
        Invoke("LoadGame", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 5)
        {
            time += Time.deltaTime;
            FillImage.fillAmount = time / second;
        }
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
