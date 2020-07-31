using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    public LayerMask enemy;
    public LayerMask Wall;
    public static FindEnemy Instance { get; private set; }
    public float viewRadius;

    private Vector3 HuongEnemy;
    private Vector3 posEnemy;
    bool haveEnemy;
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
    private void Update()
    {
        Find();
    }

    public void Find()
    {
        GameObject player = PlayerManager.Instance.Player;
        PlayerController playerControl = player.GetComponent<PlayerController>();
        if (player != null)
        {
            Collider[] collider = Physics.OverlapSphere(player.transform.position, viewRadius, enemy);
            if (collider.Length > 0)
            {
                float khoangcachgannhat = viewRadius;
                int k = -1;
                for (int i = 0; i < collider.Length; i++)
                {
                    Transform target = collider[i].transform;
                    Transform targetShoot = collider[i].GetComponent<Enemy>().posShoot.transform;
                    Vector3 huongQuay = (target.position - player.transform.position).normalized;
                    Vector3 huongLook = (targetShoot.position - playerControl.Eye.transform.position).normalized;
                    float khoangcach = Vector3.Distance(playerControl.Eye.transform.position, targetShoot.transform.position);
                    Debug.DrawRay(playerControl.Eye.transform.position, huongLook * khoangcach, Color.red);

                    if (!Physics.Raycast(playerControl.Eye.transform.position, huongLook, khoangcach, Wall))
                    {
                        Debug.Log("Tim duoc ne");
                        if (khoangcach < khoangcachgannhat)
                        {
                            khoangcachgannhat = khoangcach;
                            k = i;
                            HuongEnemy = huongQuay.normalized;
                            posEnemy = target.GetComponent<Enemy>().posShoot.transform.position;
                        }
                    }
                }
                if (k >= 0)
                {
                    haveEnemy = true;
                }
                else
                {
                    haveEnemy = false;
                }
            }
            else
            {
                haveEnemy = false;
            }
        }
    }

    public bool HaveEnemy()
    {
        return haveEnemy;
    }

    public Vector3 getHuongEnemy()
    {
        return HuongEnemy;
    }

    public Vector3 getPosEnemy()
    {
        return posEnemy;
    }
}
