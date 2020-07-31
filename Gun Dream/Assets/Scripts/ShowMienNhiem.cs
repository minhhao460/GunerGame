using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ShowMienNhiem : MonoBehaviour
{
    public TextMesh textM;
    private Camera cam;
    public void Set(Vector3 vtri, string text, Color color)
    {
        gameObject.transform.position = vtri;
        textM.text = text;
        textM.color = color;
    }
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        gameObject.transform.LookAt(gameObject.transform.position + cam.transform.forward);
    }

    void DesTroyThis()
    {
        Destroy(gameObject);
    }
}
