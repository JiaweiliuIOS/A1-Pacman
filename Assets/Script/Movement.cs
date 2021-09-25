using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 move = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        move = transform.position;
    }

    void FixedUpdate() {
        Vector2 go = Vector2.MoveTowards(transform.position, move, speed);
        GetComponent<Rigidbody2D>().MovePosition(go);

        if ((Vector2)transform.position == move){
            if (Input.GetKey(KeyCode.RightArrow) && effect(Vector2.right))
                move == (Vector2)transform.position + Vector2.right;

            if (Input.GetKey(KeyCode.LeftArrow) && effect(Vector2.left))
                move == (Vector2)transform.position + Vector2.left;
            
            if (Input.GetKey(KeyCode.UPArrow) && effect(Vector2.up))
                move == (Vector2)transform.position + Vector2.up;
            
            if (Input.GetKey(KeyCode.DownArrow) && effect(Vector2.down))
                move == (Vector2)transform.position + Vector2.down;
        }
    }

    bool effect(Vector2 dir){
        Vector2 address = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(address + dir, address);
        return (hit.collider == GetComponent<collider2D>());
    }
    // Update is called once per frame
    void Update()
    {

    }
}
