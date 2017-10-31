using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorBarra : MonoBehaviour
{
    public static JugadorBarra control;

    public float VelocidadJugadorBarra;
    public Vector3 PosicionJugadorBarra;
    public static int VidasJugador;
    public static int PuntosJugador;


    //Use this for initialization
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;

        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu 2"))
        {
            Destroy(this.gameObject);
        }

        else if (control != this)
        {
            Destroy(gameObject);
        }

        PosicionJugadorBarra = gameObject.transform.position;
        VelocidadJugadorBarra = 200;
        VidasJugador = 3;
        PuntosJugador = 0;

    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(VelocidadJugadorBarra, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-VelocidadJugadorBarra, 0);
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (VidasJugador == 0)
        {
            Destroy(this.gameObject);
            Application.LoadLevel("Menu");

        }

        Ganar();
    }

    void Agregarpuntos(int puntos)
    {
        PuntosJugador += puntos;
    }

    public void RestarPuntos (int puntos)
    {
        PuntosJugador -= puntos;
    }


    void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 3.0f, 200.0f, 200.0f), "Vidas: " + VidasJugador);
        GUI.Label(new Rect(5.0f, 20.0f, 200.0f, 200.0f), "Puntaje: " + PuntosJugador);
    }



    void QuitarVida()
    {
        VidasJugador--;
    }

    void Ganar()
    {
        if ((GameObject.FindGameObjectsWithTag("EnemySquare")).Length == 0)
        {

            SceneManager.LoadScene(SceneManager.sceneCount + 1);
        }


       
    }
}