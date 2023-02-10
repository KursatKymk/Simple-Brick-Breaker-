using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float leftTarget, rightTarget;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (gameManager.gameOver)
        {
            return;
        }
        
        float h = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * h * Time.deltaTime * speed);

        //paddle sınırlandırma
        Vector2 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, leftTarget, rightTarget);
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "liveupball")
        {
            gameManager.UpdateLives(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "scoreupball")
        {
            gameManager.UpdateScore(5);
            Destroy(other.gameObject);
        }
    }
}
