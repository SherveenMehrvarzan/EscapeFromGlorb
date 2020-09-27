using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPlayerMovement : MonoBehaviour
{
    private CharacterController c;
    public float moveSpeed = 2f;
    public float rotSpeed = 1f;
    private Character character;

    // Start is called before the first frame update
    void Start()
    {
        c = gameObject.GetComponent<CharacterController>();
        character = gameObject.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.activePlayer && character.canMove)
        {
            Rotate();
            Move();
        }
    }

    void Move()
    {
        Vector3 currentSpeed = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), 1) * moveSpeed;
        c.SimpleMove(currentSpeed);
    }

    void Rotate()
    {
        float targetY = transform.rotation.eulerAngles.y;
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 1)
        {
            targetY = 0;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 0)
        {
            targetY = 90;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == -1)
        {
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
