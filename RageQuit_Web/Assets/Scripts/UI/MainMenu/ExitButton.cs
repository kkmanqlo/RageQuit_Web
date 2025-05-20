using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // Este script se encarga de manejar el botón de salir del juego en el menú principal.
    public void Exit()
    {
        SceneManager.LoadScene("MenuPrincipal");
        DOTween.KillAll();
    }
}
