using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CambiarSkin : PAuseButton {

    public SpriteRenderer spriteJugador;
    public Sprite sprite;
    [SerializeField]
    public int precioSkin;

    

    public void Cambiar_Skin()
    {
        print("cambio los puntos");

        if (JugadorBarra.PuntosJugador >= precioSkin)
        {
            JugadorBarra.control.RestarPuntos(precioSkin);

            Debug.Log("D:");
            
            spriteJugador.sprite = sprite;
        }
        else
        {
            Debug.Log("Oye, no te alcanza para eso!");
        }
    }

   



    // Update is called once per frame
    void Update()
    {
        textPuntos.text = JugadorBarra.PuntosJugador.ToString();
    }
}
