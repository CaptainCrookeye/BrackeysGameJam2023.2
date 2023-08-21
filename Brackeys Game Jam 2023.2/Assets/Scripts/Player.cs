using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float fall = 5f;
    public int health = 5;
    bool walking = false;
    bool left = false;
    bool right = true;
    void Update()
    {
        transform.Translate(Vector2.down * fall * Time.deltaTime);
        if (walking && right)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (walking && left)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            walking = true;
            right = true;
            left = false;
        }
        if(Input.GetKeyUp(KeyCode.D)) 
        {
            walking = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            walking = true;
            right = false;
            left = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            walking = false;
        }
        if (health==0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            health--;
            FindObjectOfType<Audio_manager>().play("hit");
            Debug.Log(health);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
