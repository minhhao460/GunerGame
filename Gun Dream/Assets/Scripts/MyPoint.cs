using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPoint : MonoBehaviour
{
    public MyPoint Instance { get; private set; }
    public List<GetPoint> listgetpoint;

    public void add(GetPoint get)
    {
        listgetpoint.Add(get);
    }


    public void getOnePoint(Vector3 vtri, float maxDistance)
    {
        List<GetPoint> listcurrengetpoint = null;
        for (int i = 0; i < listgetpoint.Count; i++)
        {
            if (Vector3.Distance(vtri, listgetpoint[i].gameObject.transform.position) < maxDistance)
            {
                listcurrengetpoint.Add(listgetpoint[i]);
            }
        }

    }
}
