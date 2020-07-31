using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public TextMesh textM;
    private Camera cam;
    void DesTroyThis()
    {
        Destroy(gameObject);
    }
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        gameObject.transform.LookAt(gameObject.transform.position + cam.transform.forward);
    }
    public void Set(Vector3 localpos, string Text, Color color)
    {
        transform.position = localpos ;
        textM.text = "-" + Text;
        textM.color = color;
    }
}
