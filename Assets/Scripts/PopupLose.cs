using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupLose : MonoBehaviour
{
    [SerializeField] Button _button1;
    [SerializeField] Button _button2;
    [SerializeField] Text _button1Text;
    [SerializeField] Text _button2Text;
    [SerializeField] Text _popupText;



    public void Init(Transform canvas,string popupText)
    {
        _popupText.text = popupText;
        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;
        _button2.onClick.AddListener(() =>
        {
            GameObject.Destroy(this.gameObject);
            GameplayController.instance.RestartGame();
        });
        _button1.onClick.AddListener(() =>
        {
            BackGroudMenu();
        });
    }
    public void BackGroudMenu()
    {
        SceneManager.LoadScene("BackGroudMenu");
    }
}
