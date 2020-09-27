using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 4f;
    public float rotSpeed = 1f;
    public CapsuleCollider capsule;
    public float ascendHeightScale =1.5f;
    public float ascendTimeScale = 0.5f;
    private bool ascended = false;
    private float originalFloatHeight;
    private Character character;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        character = gameObject.GetComponent<Character>();
       originalFloatHeight  = capsule.height;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (character.activePlayer && character.canMove)
        {
            Rotate();
            Move();
            if (Input.GetButtonDown("Jump")) ascended = !ascended;

            float targetHeight;
            if (ascended) targetHeight = originalFloatHeight * ascendHeightScale;
            else targetHeight = originalFloatHeight;
            capsule.height = Mathf.Lerp(capsule.height, targetHeight, Time.deltaTime * ascendTimeScale);
        }  
    }

    void Move()
    {
        Vector3 currentSpeed = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")),1) * moveSpeed;
        rb.velocity = new Vector3(currentSpeed.x, rb.velocity.y,currentSpeed.z);
    }

    void Rotate()
    {
        float targetY = transform.rotation.eulerAngles.y;
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 1)
        {
            targetY = 0;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 0) {
            targetY = 90;
        }
        else if(Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == -1) {
            targetY = 135;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == -1)
        {
            targetY = 180;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == -1)
        {
            targetY = 225;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 0)
        {
            targetY = 270;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 1)
        {
            targetY = 315;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 1)
        {
            targetY = 45;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, targetY, 0), rotSpeed);
    }
}
