using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{
   public void BoxGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SLotMachine()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
<<<<<<< HEAD
    public void CloseButon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
=======
    public void Quiz()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
>>>>>>> 15b457eab3d229cc2fd1d9ee07d33a8d5bed14a7
    }
}
