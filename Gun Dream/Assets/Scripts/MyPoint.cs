using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPoint : MonoBehaviour
{
    public static MyPoint Instance { get; private set; }
    [HideInInspector]
    public GetPoint[] listgetpoint;
    private void Awake()
    {
            Instance = this;
    }

    private void Start()
    {
        listgetpoint = FindObjectsOfType<GetPoint>();
        Debug.Log("Soluong GetPoint: " + listgetpoint.Length);
    }

    public Vector3 getOnePoint(float posY, Vector3 vtri, float maxDistance)
    {
        List<GetPoint> listcurrengetpoint = new List<GetPoint>();
        if (listgetpoint.Length == 0)
            return vtri;
        for (int i = 0; i < listgetpoint.Length; i++)
        {
            if (Vector3.Distance(vtri, listgetpoint[i].gameObject.transform.position) < maxDistance)
            {
                listcurrengetpoint.Add(listgetpoint[i]);
            }
        }
        if (listcurrengetpoint.Count == 0)
            return vtri;
        int random = Random.Range(0, listcurrengetpoint.Count);
        return listcurrengetpoint[random].getPoint(posY);
    }
}
