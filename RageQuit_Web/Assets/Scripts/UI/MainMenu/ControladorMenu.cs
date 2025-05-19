using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControladorMenu : MonoBehaviour
{
    public GameObject PopUp;                   // Referencia al popup para ingresar nombre
    public TMP_InputField inputNombre;        // Campo de texto donde el usuario escribe su nombre
    public TMP_Text textoNombreVisible;       // Texto donde se muestra el nombre del usuario en pantalla

    // Se ejecuta una vez al iniciar la escena

    // Método que se llama al presionar el botón "Jugar"
    public void BotonJugar()
    {

            SceneManager.LoadScene("LevelSelectionScene");

    }

    // Método que confirma el nombre ingresado en el popup
}

