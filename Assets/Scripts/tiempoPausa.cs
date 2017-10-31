using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempoPausa : MonoBehaviour {
    [SerializeField]GameObject tienda;
    float tiempoTienda;
	// Use this for initialization
	void Start () {
        tiempoTienda = 3f;
	} 

    // Update is called once per frame
    void Update() {
        tiempoTienda = tiempoTienda-Time.deltaTime;
        if (tiempoTienda <= 0)
        {
            tienda.SetActive(true);
        }
	}
}
