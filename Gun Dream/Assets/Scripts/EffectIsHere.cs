using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class EffectIsHere : MonoBehaviour
{
    public static EffectIsHere Instance { get; private set; }

    public GameObject Freeze;
    public GameObject Stun;
    public GameObject Fire;
    public GameObject Poision;
    public FloatingText ShowDamage;
    public ShowHealth ShowHealth;
    public ShowMienNhiem ShowMienNhiem;

    public Color Health_Color_Default;
    public Color Health_Color_Stun;
    public Color Health_Color_Fire;
    public Color Health_Color_Poision;
    public Color Health_Color_Freeze;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
