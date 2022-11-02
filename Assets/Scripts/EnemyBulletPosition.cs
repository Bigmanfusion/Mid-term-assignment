using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPosition : MonoBehaviour
{
    public GameObject Blasterenemies;
    //public float time = 0;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("FireEnemyBullet", 0F);
        
    }

    // Update is called once per frame
    void Update()
    {
       // if (time > 0)
        //{
           // FireEnemyBullet();
           // time = 1;
        //}
        //else
            //time += Time.deltaTime;
    }

    void FireEnemyBullet()
    {

        GameObject playership = GameObject.Find("Player");

        if(playership != null)
        {

            //GameObject bullet = (GameObject)Instantiate(Blasterenemies, transform.position, Quaternion.identity);
            GameObject bullet = (GameObject)Instantiate(Blasterenemies);

            bullet.transform.position = transform.position;
           // bullet.transform.parent = playership.transform;

            Vector2 direction = playership.transform.localPosition - bullet.transform.localPosition;
            //Vector2 direction = Vector2.down;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
