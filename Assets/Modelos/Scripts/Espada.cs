using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadMinima = 0.1f;
    private Vector3 ultimaPosicionMouse;
    private Collider2D col;
    private AudioSource audioSource;

    public AudioClip sonidoEspada; // Asigna el clip de sonido "espada" desde el editor.

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool seMueve = SeMueveElMouse();
        col.enabled = seMueve;
        if (seMueve)
        {
            ReproducirSonidoEspada(); // Se asegura de reproducir el sonido cada vez que hay movimiento.
        }
        AsociarEspadaAlMouse();
    }

    private void AsociarEspadaAlMouse()
    {
        var mousePosicion = Input.mousePosition;
        mousePosicion.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePosicion);
    }

    private bool SeMueveElMouse()
    {
        Vector3 posicionMouseActual = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float desplazamiento = (ultimaPosicionMouse - posicionMouseActual).magnitude;
        ultimaPosicionMouse = posicionMouseActual;

        return desplazamiento > velocidadMinima;
    }

    private void ReproducirSonidoEspada()
    {
        if (audioSource != null && sonidoEspada != null)
        {
            if (!audioSource.isPlaying) // Esto previene superposiciones no deseadas.
            {
                audioSource.PlayOneShot(sonidoEspada);
            }
        }
    }
}