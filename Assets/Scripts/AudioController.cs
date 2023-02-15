using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider master, music, ambient, player;
    [SerializeField] TMP_Text masterText, musicText, ambientText, playerText;
    // Start is called before the first frame update
    void Start()
    {
        //Connecting our custom functions to the OnValueChanged Unity event for each slider;
        master.onValueChanged.AddListener(delegate { SetMasterSound(); });
        music.onValueChanged.AddListener(delegate { SetMasterSound(); });
        ambient.onValueChanged.AddListener(delegate { SetMasterSound(); });
        player.onValueChanged.AddListener(delegate { SetMasterSound(); });

        //Set the stored sound settings
        SetStartingValues();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterSound()
    {
        audioMixer.SetFloat("MasterVolume", master.value);//Connects the slider value to the audio mixer
        float percentage = (((-80.0f-master.value))/-80.0f)*100.0f;//Convert dB to percentage
        masterText.text = ((int)percentage).ToString();//Display percentage value       
    }

    public void SetMusicSound()
    {
        audioMixer.SetFloat("MusicVolume", music.value);
        float percentage = (((-80.0f - music.value)) / -80.0f) * 100.0f;
        musicText.text = ((int)percentage).ToString();

    }
    public void SetAmbientSound()
    {
        audioMixer.SetFloat("AmbientVolume", ambient.value);
        float percentage = (((-80.0f - ambient.value)) / -80.0f) * 100.0f;
        ambientText.text = ((int)percentage).ToString();

    }
    public void SetPlayerSound()
    {
        audioMixer.SetFloat("PlayerVolume", player.value);
        float percentage = (((-80.0f - player.value)) / -80.0f) * 100.0f;
        playerText.text = ((int)percentage).ToString();

    }

    void SetStartingValues()
    {
        float percentage, value;

        //Master Volume
        audioMixer.GetFloat("MasterVolume", out value);//Extracting the actual volume value
        master.value = value;//Apply it to the slide
        percentage = ((-80.0f-value)/-80.0f)*100.0f;//Covert it to a percentage
        masterText.text = ((int)percentage).ToString();//Display the percentage

        //Music Volume
        audioMixer.GetFloat("MusicVolume", out value);
        music.value = value;
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;
        musicText.text = ((int)percentage).ToString();
        
        //Ambient Volume
        audioMixer.GetFloat("AmbientVolume", out value);
        ambient.value = value;
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;
        ambientText.text = ((int)percentage).ToString();

        //Player Volume
        audioMixer.GetFloat("PlayerVolume", out value);
        player.value = value;
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;
        playerText.text = ((int)percentage).ToString();

    }

}
