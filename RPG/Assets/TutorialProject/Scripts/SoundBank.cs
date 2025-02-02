using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    public static SoundBank instance { get; private set; }
    public AudioClip stepAudio;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
           Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }
}
