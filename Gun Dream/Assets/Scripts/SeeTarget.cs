using UnityEngine;

public class SeeTarget : MonoBehaviour
{
    public LayerMask Targets;
    public LayerMask Obstacle;
    public float viewRadius;
    public bool Obstacled;
    public bool HaveTarget;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame

    void Find()
    {
        Collider[] finded = Physics.OverlapSphere(gameObject.transform.position, viewRadius);

    }
}
