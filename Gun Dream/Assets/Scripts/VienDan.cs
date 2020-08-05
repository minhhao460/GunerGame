using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VienDan : MonoBehaviour
{
    
    public LayerMask DoiTuong;
    public float TimeToDestroy;
    public GameObject TargetDestroy;
    public BulletManager.TypeDan Type;
    public GameObject No;

    private int damage;
    private float speed;
    private Shooter shooter;
    private DieuKhien dk;

    void Start()
    {
        dk = FindObjectOfType<DieuKhien>();
        shooter = PlayerManager.Instance.Player.GetComponent<PlayerController>().SungHienTai.GetComponent<Shooter>();
        Destroy(TargetDestroy, TimeToDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
        }

    }

    private void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDistance);
        CheckColiisions(moveDistance);
    }

    public void setSpeed(float a)
    {
        speed = a;
    }

    void CheckColiisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, moveDistance, DoiTuong))
        {
            OnHitEnemy(hit);
        }
    }

    void OnHitEnemy(RaycastHit hit)
    {
        Enemy enemy = hit.collider.GetComponent<GetEnemyComponent>().EnemyTarget;
        if (enemy != null && enemy.Keeper != LivingOB.TypeLiving.Player)
        {
            enemy.NhanDam(Type, damage);
            Destroy(gameObject);
            GameObject a = Instantiate(No);
            a.transform.position = hit.point;
            Destroy(a, 0.2f);
        } else
        {
            if (enemy == null)
            {
                Debug.LogWarning("Component Enemy không tồn tại");
            }
        }
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    public void setHuong(Vector3 huong)
    {
        transform.forward = huong.normalized;
    }
}
