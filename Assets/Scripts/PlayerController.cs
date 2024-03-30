using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public float rotationspeed = 10;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(-v, 0, h);
        if(directionVector.magnitude > Mathf.Abs(0.05f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * 10 * rotationspeed); 
        }
        

        anim.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        rb.velocity = Vector3.ClampMagnitude(directionVector, 1) * speed;
    }
}
