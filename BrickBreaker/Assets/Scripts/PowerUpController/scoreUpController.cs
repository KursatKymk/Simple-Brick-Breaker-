using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreUpController : MonoBehaviour
{
    public float speed;


    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
