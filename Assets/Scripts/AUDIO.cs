using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUDIO : MonoBehaviour
{
    public AudioSource ShortGun_Audio;
    public AudioSource ZombieMoarning_Audio;
    public AudioSource  Ak47_Audio;
    public static AUDIO audio_instance;


    // Start is called before the first frame update
    private void Awake()
    {
        audio_instance = this;

        if(audio_instance != null)
        {
            return;
        }
        audio_instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play_ShortGun_Audio()
    {
        ShortGun_Audio.Play();
    }
    public void Play_ZombieMoarning_Audio()
    {
        ZombieMoarning_Audio.Play();
    }
    public void Play_AK47_Sound()
    {
        Ak47_Audio.Play();
    }
}
