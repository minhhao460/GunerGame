using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GetPointInSquare : GetPoint
{
    public enum Type { X, Z};
    public Type type;
    public Transform TrungTam;
    public Transform Distance;

    private Vector3 tam;
    private float halflenght;
    public override Vector3 getPoint(float posY)
    {
        float hor = Random.Range(-halflenght, halflenght);
        float ver = Random.Range(-halflenght, halflenght);
        return new Vector3(tam.x + hor, posY, tam.z + ver);
    }

    // Start is called before the first frame update
    void Start()
    {
        tam = TrungTam.position;
        switch (type)
        {
            case (Type.X):
                halflenght = Mathf.Abs(TrungTam.position.x - Distance.position.x);
                break;
            case (Type.Z):
                halflenght = Mathf.Abs(TrungTam.position.z - Distance.position.z);
                break;
        }
    }
}
