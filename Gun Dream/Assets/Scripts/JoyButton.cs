using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    protected bool pressed;
    GameObject player;

    private Vector3 startScale;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        transform.localScale = startScale * 0.8f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        transform.localScale = startScale;
    }

    private void Start()
    {
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            PlayerManager.Instance.Player.GetComponent<PlayerController>().Shoot();
        }
    }
}
