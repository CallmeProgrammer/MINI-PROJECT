using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass_Break : MonoBehaviour
{

    [Header("Normal glass object")]
    public GameObject Normal_glass;

    [Header("Broken glass objects")]
    public GameObject Broken_glass;

    //public static Glass_Break Glass_instance;
    // Start is called befor   e the first frame update
    //public void Awake()
    //{
    //    if(Glass_instance != null)
    //    {
    //        return;
    //    }
    //    Glass_instance = this;
    //}

    public void Start()
    {
        //Setting the normal looking glass in active state at starting of game.
        Normal_glass.SetActive(true);

        //Setting the broken glass in disabled state at starting of game.
        Broken_glass.SetActive(false);

    }
 
    public void break_glass()
    {
        Debug.Log("GLASS BREAKING");

        //Destroying normal glass when ray hits it
        Destroy(Normal_glass);

        //when ray hits narmal glass it destroys and enables the Brokenglass which creates a breaking effect.
        Broken_glass.SetActive(true);
        //AUDIO.audio_instance.Play_GlassBreak_audio();
        Destroy(Broken_glass, 5f);
    }
   


}

