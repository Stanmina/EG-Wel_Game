using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public Vector3 spawn;
    public GameObject player;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    float timeF;
    public int death = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] heartArray = { heart1, heart2, heart3 };

        if (collision.gameObject.CompareTag("Void") || collision.gameObject.CompareTag("Walrus"))
        {
            death++;
            for (int i = 0; i < death; i++)
            {
                Destroy(heartArray[i]);
                if (death == 3)
                {
                    player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    player.gameObject.GetComponent<PlayerMovement>().enabled = false;
                    GameOverScreen.Setup(FindObjectOfType<ScoreManager>().score);
                    print(timeF);
                }
            }
            player.transform.SetPositionAndRotation(spawn, Quaternion.identity);
            GetComponent<PlayerMovement>().facingRight = true;
            FindObjectOfType<AudioManager>().Play("Death");
            timeF = Time.realtimeSinceStartup;
        }
    }
}
