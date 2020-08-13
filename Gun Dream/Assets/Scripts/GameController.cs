using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public GameObject CVG;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        CVG.SetActive(false);
    }

    public void GoToMAP(string name)
    {
        GameObject a = GameObject.FindGameObjectWithTag("CVMoDan");
        StartCoroutine(MoDan(a, name));
    }

    IEnumerator MoDan(GameObject Canvas, string a)
    {
        CVG.SetActive(true);
        float start = Time.time;
        CanvasGroup cv = CVG.GetComponent<CanvasGroup>();
        while (Time.time - start <= 1)
        {
            cv.alpha = (Time.time - start);
            yield return null;
        }
        cv.alpha = 1;
        SceneManager.LoadScene(a);
        yield return new WaitForSeconds(1f);
        while (Time.time - start <= 1)
        {
            cv.alpha = (1 - Time.time - start);
            yield return null;
        }
        cv.alpha = 0;
        CVG.SetActive(false);
    }

    public void ResetPlayer()
    {
        
    }

    public static bool SacXuat(float a)
    {
        return !(a < UnityEngine.Random.Range(0f, 1f));
    }

    public static Vector3 FixedPosByNavMesh(Vector3 pos)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(pos, out hit, 10, 1))
        {
            return hit.position;
        }
        else
        {
            Debug.LogWarning("Khong Tim thay SamplePosition");
            return pos;
        }
    }
}
