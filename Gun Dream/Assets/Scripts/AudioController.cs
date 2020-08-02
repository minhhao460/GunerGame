using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource ThaySung;
    public AudioSource SungLucShoot;
    public static AudioController Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
            Instance = this;
    }

    public void Play_ThaySung()
    {
        ThaySung.Play();
    }

    public void Play_SungLucShoot()
    {
        SungLucShoot.Play();
    }
}
