using System.Collections;
using UnityEngine;

public class IntroMoveBird : MonoBehaviour
{
    public Rigidbody2D birdRigidbody2d;

    [Header("===Non Random Fields===")]
    public int speed = 5;
    public int distance = 5;

    [Header("===Random===")]
    public bool useRandomSpeed;
    public bool useRandomDistance;

    [Header("===Random Speed Values===")]
    public int randomSpeedMin = 3;
    public int randomSpeedMax = 11;

    [Header("===Random Distance Values===")]
    public int randomDistanceMin = 1;
    public int randomDistanceMax = 6;

    int direction;
    Vector2 startPos;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = birdRigidbody2d.position;
        direction = Random.Range(1, 3);

        if (useRandomSpeed)
        {
            speed = Random.Range(randomSpeedMin, randomSpeedMax);

            if (direction == 1)
                birdRigidbody2d.velocity = new Vector2(speed, 0);
            else
            {
                birdRigidbody2d.velocity = new Vector2(-speed, 0);
                Flip();
            }
        }
        else
            birdRigidbody2d.velocity = new Vector2(speed, 0);
        if (useRandomDistance)
            distance = Random.Range(randomDistanceMin, randomDistanceMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (birdRigidbody2d.position.x < startPos.x - distance && !facingRight)
        {
            birdRigidbody2d.velocity = new Vector2(speed, 0);
            Flip();
        }
        if (birdRigidbody2d.position.x > startPos.x + distance && facingRight)
        {
            birdRigidbody2d.velocity = new Vector2(-speed, 0);
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponentInChildren<Canvas>().GetComponent<Canvas>().enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponentInChildren<Canvas>().GetComponent<Canvas>().enabled = false;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        gameObject.GetComponent<SpriteRenderer>().flipX = !facingRight;
    }

    IEnumerator BirdText()
    {
        yield return new WaitForSecondsRealtime(5);
        gameObject.GetComponentInChildren<Canvas>().GetComponent<Canvas>().enabled = false;
    }
}
