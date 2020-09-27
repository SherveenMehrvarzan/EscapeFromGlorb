using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource music;
    public bool mute;

    private void Start()
    {
        music = GetComponent<AudioSource>();
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            music.mute = mute;
            mute = !mute;
        }
    }
}
