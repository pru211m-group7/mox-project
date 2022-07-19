using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIController Instance;
    public Transform MainCanvas;
    void Start()
    {
        if(Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
public Popup CreatePopup()
    {
        GameObject popUpGo = Instantiate(Resources.Load("UI/Popup") as GameObject);
        return popUpGo.GetComponent<Popup>();
    }

public PopupLose CreatePopupLose()
{
    GameObject popUpGo = Instantiate(Resources.Load("UI/PopupLose") as GameObject);
    return popUpGo.GetComponent<PopupLose>();
}
}
