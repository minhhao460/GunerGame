using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLuyenTap : MonoBehaviour
{
    public GameObject testPlayer;
    public GameObject Cua;
    public int MaxEnemy;
    public float DoLech;
    public Vector3 TrungTam;
    public LayerMask target;
    bool spawning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }

    void Check()
    {
        if (!spawning)
        {
            StartCoroutine(CheckToSpawn());
        }
    }

    IEnumerator CheckToSpawn()
    {
        spawning = true;
        while (testPlayer.GetComponent<SpawnAfterIn>().PlayerIn)
        {
            Collider[] enemy = Physics.OverlapSphere(TrungTam, DoLech, target);
            if (enemy.Length < 5)
            {
                Spawn();
            }
            yield return new WaitForSeconds(2);
        }
        spawning = false;
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(TrungTam.x + Random.Range(-DoLech, DoLech), 0, TrungTam.z + Random.Range(-DoLech, DoLech));
        GameObject cua = Instantiate(Cua, gameObject.transform);
        cua.transform.position = pos;
    }
}
