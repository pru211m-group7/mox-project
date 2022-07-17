using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomGift : MonoBehaviour
{
    private static int randomValue = 0;
    private static int OldrandomValue = 0;
    [SerializeField]
    private GameObject giftPanel;
    [SerializeField] private Image gift01;
    [SerializeField] private Image gift02;
    [SerializeField] private Image gift03;
    [SerializeField] private Image gift04;
    [SerializeField] private Image gift05;

    private List<Image> listImg = new List<Image>();
    private bool IsEnableImg = true;

    public void OnEnable()
    {
        IsEnableImg = true;
    }

    public void Update()
    {
       
        listImg.Add(gift01);
        listImg.Add(gift02);
        listImg.Add(gift03);
        listImg.Add(gift04);
        listImg.Add(gift05);

        if (IsEnableImg == true)
        {
            foreach (var item in listImg)
            {
                if (item.enabled)
                {
                    item.enabled = false;
                }
            }

            while (randomValue == OldrandomValue)
            {
                randomValue = Random.Range(0, 5);
            }

            OldrandomValue = randomValue;
            listImg[randomValue].enabled = true;
            IsEnableImg = false;
        }
        
    }
}
