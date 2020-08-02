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
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
