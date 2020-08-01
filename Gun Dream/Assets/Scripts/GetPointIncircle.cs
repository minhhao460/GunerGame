using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPointIncircle : GetPoint
{
    public Transform TrungTam;
    public Transform Vien;

    private Vector3 tam;
    private float radius;
    public override Vector3 getPoint(float posY)
    {
        Vector3 offset = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius)).normalized * radius;
        return new Vector3(tam.x + offset.x, posY, tam.z + offset.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        tam = TrungTam.position;
        radius = Vector3.Distance(TrungTam.position, Vien.position);
    }
}
