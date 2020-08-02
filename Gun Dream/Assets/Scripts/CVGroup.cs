using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class CVGroup : MonoBehaviour
{
    public static CVGroup Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
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
