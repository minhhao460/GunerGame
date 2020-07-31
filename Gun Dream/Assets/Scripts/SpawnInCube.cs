using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnInCube : MonoBehaviour
{
    public enum TypeGet {Random }
    public Vector3 Tam;
    public float RadiusX;
    public float RadiusZ;
    public float MatDat;
    public Vector3 getPosition(TypeGet type)
    {
        float posY = Tam.y;
        if (type == TypeGet.Random)
        {
            return new Vector3(Tam.x + Random.Range(Tam.x - RadiusX, Tam.x + RadiusX), posY, Tam.x + Random.Range(Tam.z - RadiusZ, Tam.z + RadiusZ));
        }
        return Vector3.zero;
    }

    public void Set(Vector3 tam, float RadiusX, float RadiusZ)
    {
        Tam = tam;

    }

}
