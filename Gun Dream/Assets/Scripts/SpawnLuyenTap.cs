using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnLuyenTap : MonoBehaviour
{
    public GameObject testPlayer;
    public GameObject[] Enemy;
    public int MaxEnemy;
    public float DoLech;
    public Transform TrungTam;
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
            Collider[] enemy = Physics.OverlapBox(TrungTam.position, new Vector3(DoLech, 10, DoLech), Quaternion.identity, target);
            if (enemy.Length < MaxEnemy)
            {
                Spawn();
            }
            yield return new WaitForSeconds(2);
        }
        spawning = false;
    }

    void Spawn()
    {
        Vector3 pos = GetComponent<GetPointInSquare>().getPoint(0.1f);
        pos = GameController.FixedPosByNavMesh(pos);
        int a = Random.Range(0, Enemy.Length);
        Instantiate(Enemy[a], pos, Quaternion.identity);
    }
}
