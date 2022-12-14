using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject GameManager;

    public GameObject Blasterplayer;
    public GameObject BulletPosition01;
    public GameObject DeathAnimationplayer;

    public Text LivesUIText;

    const int MaxLives = 3;
    int lives; 

    public float speed;

    public void Init()
    {
        lives = MaxLives;

        LivesUIText.text = lives.ToString ();

        gameObject.SetActive (true);    
 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {

            GameObject bullet01 = (GameObject)Instantiate (Blasterplayer);
            bullet01.transform.position = BulletPosition01.transform.position;
        }


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move (direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos  = transform.position;

        pos += direction * speed * Time.deltaTime; 

        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);

        transform.position = pos;
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "Enemy") || (col.tag == "Blasterenemies"))
        {

            PlayExplosion();

            lives--;

            LivesUIText.text = lives.ToString();

            if (lives <= 0)
            {

                //GameManager.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManager.Gameover);
            

                gameObject.SetActive(false);
            }

        }
    }


    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(DeathAnimationplayer);


        explosion.transform.position = transform.position;

    }
}
