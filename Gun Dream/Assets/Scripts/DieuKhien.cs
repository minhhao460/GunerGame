using UnityEngine;

public class DieuKhien : MonoBehaviour
{
    private Joystick joystick;

    private Vector3 velocity;
    Vector3 m_moveMent;
    Quaternion m_Rotation;
    PlayerController player;
    Rigidbody rig;
    Animator m_Animator;
    bool iswalk = false;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        player = PlayerManager.Instance.Player;
        rig = player.GetComponent<Rigidbody>();
        m_Animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = joystick.Horizontal;
        float ver = joystick.Vertical;

        m_moveMent.Set(hor, 0f, ver);
        m_moveMent.Normalize();


        // Di Chuyen
        iswalk = !Mathf.Approximately(hor, 0f) || !Mathf.Approximately(ver, 0f);
        if (iswalk)
        {
            rig.isKinematic = false;
            setVelocity(m_moveMent);
            if (FindEnemy.Instance.HaveEnemy() && player.HaveGunInHand())
            {
                setRotation(FindEnemy.Instance.getHuongEnemy());
            }
            else
            { 
                setRotation(m_moveMent);
            }
        }
        else
        {
            setVelocity(Vector3.zero);
            rig.isKinematic = true;
            if (FindEnemy.Instance.HaveEnemy() && player.HaveGunInHand())
            {
                setRotation(FindEnemy.Instance.getHuongEnemy());
            }
        }
        player.setAnimationMove(iswalk);
    }
    private void FixedUpdate()
    {
        rig.MovePosition(rig.transform.position + velocity * Time.fixedDeltaTime);
    }

    void setVelocity(Vector3 a)
    {
        velocity = (a * player.getMoveSpeed());
    }

    void setRotation(Vector3 a)
    {
        if (a == Vector3.zero)
            return;
        m_Rotation = Quaternion.LookRotation(a);
        player.transform.rotation = m_Rotation;
    }

    public Quaternion getHuong()
    {
        return player.transform.rotation;
    }

    public void setPlayer()
    {
        player = PlayerManager.Instance.Player;
    }
}
