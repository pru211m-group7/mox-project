using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuideScript : MonoBehaviour
{
    [SerializeField] GameObject rewardCanvas;
    [SerializeField] Button openButton;
    [SerializeField] Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        openButton.onClick.RemoveAllListeners();
        openButton.onClick.AddListener(OpenButtonClick);

        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(CloseButtonClick);
    }
    void OpenButtonClick()
    {
        rewardCanvas.SetActive(true);
    }
   void CloseButtonClick()
    {
        rewardCanvas.SetActive(false);
    }
   

}
