using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPointInRectangle : GetPoint
{
    public Transform TrumTam;
    public Transform X;
    public Transform Z;

    private Vector3 tam;
    private float halfX;
    private float halfZ;
    // Start is called before the first frame update
    void Start()
    {
        tam = TrumTam.position;
        halfX = Mathf.Abs(TrumTam.position.x - X.position.x);
        halfZ = Mathf.Abs(TrumTam.position.z - X.position.z);
    }

    public override Vector3 getPoint(float posY)
    {
        float hor = Random.Range(-halfX, halfX);
        float ver = Random.Range(-halfZ, halfZ);
        return new Vector3(tam.x + hor, posY, tam.z + ver);
    }
}
