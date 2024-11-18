using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAJuego : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip maringaconga; // Asigna el clip "SonidoInicio" desde el editor.

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void IrALaPantallaDeJuego()
    {
        // Verifica si es la primera vez que se entra a la escena "Principal".
        if (PlayerPrefs.GetInt("HaEntradoAPrincipal", 0) == 0)
        {
            // Reproduce el sonido si es la primera vez.
            ReproducirSonidoInicio();

            // Marca que ya se ha entrado a la escena "Principal".
            PlayerPrefs.SetInt("HaEntradoAPrincipal", 1);
            PlayerPrefs.Save();
        }

        // Carga la escena.
        SceneManager.LoadScene("Principal");
    }

    private void ReproducirSonidoInicio()
    {
        if (audioSource != null && maringaconga != null)
        {
            audioSource.PlayOneShot(maringaconga);
        }
    }
}

    // Resetea el estado si se desea permitir repetir el sonido.