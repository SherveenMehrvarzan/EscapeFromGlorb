using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerMovement : MonoBehaviour
{
    private CharacterController c;
    public float moveSpeed = 2f;
    public float rotSpeed = 1f;
    private Character character;
    public Transform tracks;
    public Transform top;

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

    private void LateUpdate()
    {
        if (character.activePlayer) RotateTop();
    }

    void Move()
    {
        Vector3 currentSpeed = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), 1) * moveSpeed;
        c.SimpleMove(currentSpeed);
    }

    void RotateTop()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        top.rotation = Quaternion.Euler(new Vector3(0f, -angle - 90, 0f));
    }

    void Rotate()
    {
        float targetY = tracks.rotation.eulerAngles.y;
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
        tracks.rotation = Quaternion.Lerp(tracks.rotation, Quaternion.Euler(0, targetY, 0), rotSpeed);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
