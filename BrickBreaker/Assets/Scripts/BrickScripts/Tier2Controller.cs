using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier2Controller : MonoBehaviour
{
    [SerializeField]
    private Sprite brokenImage;

    [SerializeField]
    GameObject tier2effect;

    int count = 0;

    GameManager gameManager;

    [SerializeField]
    GameObject scoreUpPrefab;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        count = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            count++;

            if (count == 1)
            {

                GetComponent<SpriteRenderer>().sprite = brokenImage;
                gameManager.UpdateScore(5);

                int randomChaince = Random.Range(1, 101);

                if (randomChaince > 60)
                {
                    Instantiate(scoreUpPrefab, transform.position, transform.rotation);
                }

            }
            else if (count == 2)
            {

                Instantiate(tier2effect, transform.position, transform.rotation);
                gameManager.UpdateScore(10);

                int randomChaince = Random.Range(1, 101);

                if (randomChaince > 90)
                {
                    Instantiate(scoreUpPrefab, transform.position, transform.rotation);
                }

                Destroy(gameObject);

            }
        }
    }
}
