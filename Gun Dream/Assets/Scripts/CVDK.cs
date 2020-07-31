using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class CVDK : MonoBehaviour
{
    public static CVDK Instance { get; private set;}
    public GameObject GetSungButton;
    // Start is called before the first frame update
    void Awake()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
