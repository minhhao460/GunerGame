using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public static CameraMain Instance { get; private set; }
    public Vector3 KhoangCachCamera;
    public Vector3 GocXoayCamera;
    public float TocDoLiaCamera;
    private void Awake()
    {
            Instance = this;
    }

    void FixedUpdate()
    {
        PlayerController player = PlayerManager.Instance.Player;
        if (player != null)
        {
            Vector3 newPos = player.transform.position + KhoangCachCamera;
            Vector3 newPos2 = newPos;
            if (FindEnemy.Instance.HaveEnemy() && player.HaveGunInHand())
            {

                
                Vector3 P = player.transform.position;
                Vector3 E = FindEnemy.Instance.getPosEnemy();
                newPos2.x = E.x - P.x + newPos2.x;
                newPos2.z = E.z - P.z + newPos2.z;
            }
            Vector3 newpos1 = Vector3.Lerp(transform.position, (newPos + newPos2)/2, TocDoLiaCamera * Time.deltaTime);
            transform.position = newpos1;
            transform.rotation = Quaternion.Euler(GocXoayCamera.x, GocXoayCamera.y, GocXoayCamera.z);
        } else
        {
            Debug.Log("CameraMain không tìm thấy Player trong PlayerMangager Scirpts");
        }
        
    }

    public void setStart()
    {
        transform.position = PlayerManager.Instance.Player.transform.position;
    }

}
