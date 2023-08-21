using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy_side : MonoBehaviour
{
    public float speed = 10f;
    GameObject body;
    bool triggered = false;
    void Start()
    {
        body = gameObject.transform.GetChild(0).gameObject;
        body.SetActive(false);
    }
    void Update()
    {
        if(triggered)
        {
            body.SetActive(true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            triggered = true;
        }
    }
}
