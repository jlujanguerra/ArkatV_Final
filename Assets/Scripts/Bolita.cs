using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    float velMax;
    Rigidbody2D rigi;

    public GameObject playerObject;
    Vector3 originalPosition;

    // Use this for initialization
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
        velMax = 150;

        originalPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (rigi.velocity.x > velMax)
        {
            rigi.velocity = new Vector2(velMax, rigi.velocity.y);
        }
        if (rigi.velocity.y > velMax)
        {
            rigi.velocity = new Vector2(rigi.velocity.x, velMax);
        }
        if (rigi.velocity.x < -velMax)
        {
            rigi.velocity = new Vector2(-velMax, rigi.velocity.y);
        }
        if (rigi.velocity.y < -velMax)
        {
            rigi.velocity = new Vector2(rigi.velocity.x, -velMax);
        }

        if  (transform.position.y < -165)
        {
            gameObject.transform.position = originalPosition;
            rigi.velocity = Vector3.zero;

            if (playerObject == null)
            {
                playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
                playerObject.SendMessage("QuitarVida");
            }

            else
            {
                playerObject.SendMessage("QuitarVida");
            }

        }


    }
}
