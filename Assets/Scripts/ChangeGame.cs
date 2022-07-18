using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{
   public void DroppingBox()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SLotMachine()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void CloseButon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        
    }
    public void Quiz()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }
    public void CollectButon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        
    }
}
