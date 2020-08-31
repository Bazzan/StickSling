
using UnityEngine;

public class Hook : MonoBehaviour
{

    public Transform Hand;
    Rigidbody2D hookBody;
    DistanceJoint2D distanceJoint;

    Vector2 hitPosition;
    bool hit = false;

    public GrapplingHook grapplingHook;
    
    private void Awake()
    {
        hookBody = GetComponent<Rigidbody2D>();
        distanceJoint = GetComponent<DistanceJoint2D>();
        hookBody.isKinematic = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Box")){
            Debug.Log("hook connected");
            hookBody.velocity = Vector2.zero;
            hookBody.constraints = RigidbodyConstraints2D.FreezeAll;
            grapplingHook.ConnectJoint(transform.position);
            
            
            
        }
    }

    public void AddBulletForce(Vector2 force)
    {
        hookBody.AddForce(force, ForceMode2D.Impulse);
    }
    

    public void ResetHook()
    {
        hookBody.constraints = RigidbodyConstraints2D.None;
        hookBody.velocity = Vector2.zero;
        
        hit = false;
    }



}
