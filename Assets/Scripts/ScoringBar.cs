using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringBar : MonoBehaviour
{
    public static ScoringBar instance;
    private Slider slider;
    private new ParticleSystem particleSystem;
    public float FillSpeed = 1.5f;

    private float targetProgress = 0;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSystem = GameObject.Find("Bar Particles").GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }else if(slider.value == 6)
                {
                Popup popup = UIController.Instance.CreatePopup();
                AudioManager.instance.Stop("ThemeDroppingBox");
                popup.Init(UIController.Instance.MainCanvas);
                this.enabled = false;
            }
        }
        else 
        {
         
            particleSystem.Stop();

        }
    }

    public void IncrementScore (float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    public void Reset()
    {
        targetProgress = 0;
        slider.value = 0;
    }
}
