using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class PAuseButton : MonoBehaviour {
    bool hayPausa;
    public Canvas menuPausa;
    public GameObject tienda;
    public Text textPuntos;
    

    public void OnGUI()
    {
        if (GUI.Button(new Rect(100, 220, 100, 30), "Guardar"))
        {
            Guardar();
        }

        if (GUI.Button(new Rect(100, 270, 100, 30), "Cargar"))
        {
            Cargar();
        }
        
    }



    public void BotonTienda()
    {
        tienda.gameObject.SetActive(true);
    }

    public void BotonSalirTienda()
    {
        tienda.gameObject.SetActive(false);
    }

    

    public void BotonPausa()
    {
        if (!hayPausa)
        {
            Time.timeScale = 0;
            hayPausa = true;
            menuPausa.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            hayPausa = false;
            menuPausa.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        hayPausa = false;
        
    }

    void Update()
    {
        textPuntos.text = JugadorBarra.PuntosJugador.ToString();
    }

    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        DatosJugador Datos = new DatosJugador();
        Datos.PuntosJugadorG = JugadorBarra.PuntosJugador;
        Datos.VidasJugadorG = JugadorBarra.VidasJugador;
        Datos.NivelActual = SceneManager.GetActiveScene().buildIndex;

        bf.Serialize(file, Datos);
        file.Close();
    }
  

    public void Cargar()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
            DatosJugador Datos = (DatosJugador)bf.Deserialize(file);
            file.Close();

            JugadorBarra.PuntosJugador = Datos.PuntosJugadorG;
            JugadorBarra.VidasJugador = Datos.VidasJugadorG;

            SceneManager.LoadScene(Datos.NivelActual);


        }

    }
}

[System.Serializable]
class DatosJugador
{
    public int PuntosJugadorG;
    public int VidasJugadorG;
    public int NivelActual;
}




   

