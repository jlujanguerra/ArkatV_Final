using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    [SerializeField]
    GameObject tienda;

   

    public void Iniciar()
    {
        SceneManager.LoadScene("ArKat_V2_01");
    }

    public void AbrirTienda()
    {
        tienda.SetActive(true);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
