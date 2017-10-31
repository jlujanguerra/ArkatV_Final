using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBloque : MonoBehaviour {

    public int VidaBloque;
    public int Puntos;
    private int NumerodeGolpes;
  
   

    // Use this for initialization
    void Start () {
        NumerodeGolpes = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bolita")
        {
            NumerodeGolpes++;

            if (NumerodeGolpes == VidaBloque)
            {
                GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

                player.SendMessage("Agregarpuntos", Puntos);

                Destroy(this.gameObject);

            }
        }


    }

  
        // Update is called once per frame
        void Update () {
		
	}
}
