using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD_Movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movement;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal;
        float moveVertical;

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        movement.x = moveHorizontal;
        movement.y = moveVertical;
        
        //*** Core Algorithm ***//
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
