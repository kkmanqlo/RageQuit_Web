using UnityEngine;
using UnityEngine.SceneManagement;
public class VolverButtonLevel : MonoBehaviour
{
    // Este script se encarga de manejar el botón de volver a la escena anterior en la selección de niveles.
    public void VolverAEscenaAnterior()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Cambia "MenuPrincipal" por el nombre de tu escena principal
    }
}
