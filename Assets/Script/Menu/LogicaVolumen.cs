using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour

{
    public Slider slide;
    public float sliderValue;
    public Image ImageMute;

    // Start is called before the first frame update
    void Start()
    {
        slide.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slide.value;
        RevisaeSiestoyMute();


    }

    public void ChangeSlider(float valor) 
    { 
        slide.value=valor;
        PlayerPrefs.SetFloat("volumenAudio", slide.value);
        AudioListener.volume = slide.value;
        RevisaeSiestoyMute();

    }
    public void RevisaeSiestoyMute()
    {
        if (sliderValue == 0)
        {
            ImageMute.enabled = true;
        }

        else 
        { 
            ImageMute.enabled = false;
        }
    }
}
