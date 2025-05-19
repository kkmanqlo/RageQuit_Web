using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoorTutorial : MonoBehaviour
{
    // Este script se encarga de manejar la puerta de siguiente nivel en el juego.
    // Al entrar en la puerta, se actualiza el progreso del jugador en la base de datos
    // y se carga la siguiente escena o una escena específica.
    // La diferencia con el script original es que este no guarda estadísticas del nivel,
    // ya que no se requiere en el tutorial.  
    [Tooltip("¿Usar siguiente escena en el build index automáticamente?")]
    public bool autoLoadNextScene = true;

    [Tooltip("Si no es automático, nombra aquí la escena a cargar")]
    public string sceneToLoad;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated) return;

        CharacterMovement character = collision.GetComponent<CharacterMovement>();
        if (character != null)
        {
            activated = true;
            Invoke(nameof(LoadScene), 0.5f);
        }

    }

    private void LoadScene()
    {
        DOTween.KillAll();

        if (autoLoadNextScene)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.LogWarning("No hay más escenas en el build index.");
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("No se ha asignado el nombre de la escena a cargar.");
            }
        }
    }

}
