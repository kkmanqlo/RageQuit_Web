using UnityEngine;
using System.Collections.Generic;

public class LevelStatsManager : MonoBehaviour
{
    // Instancia Singleton para acceso global
    public static LevelStatsManager Instance { get; private set; }

    // Contador de muertes en el nivel actual
    private int muertes;
    // ID del progreso actual (slot/progreso del jugador)
    private int idProgreso;
    // Ruta a la base de datos SQLite
    private string dbPath;

    // Tiempo acumulado en el nivel actual, en segundos
    private float tiempoAcumuladoEnNivel = 0f;

    // HashSet para controlar qué escenas ya tuvieron reinicio de estadísticas
    private static HashSet<string> escenasReiniciadas = new HashSet<string>();

    // Obtiene el ID del nivel basado en el nombre de la escena actual

    // Propiedad pública para obtener el tiempo acumulado actual
    public float TiempoActual => tiempoAcumuladoEnNivel;

    // Propiedad pública para obtener las muertes actuales
    public int MuertesActuales => muertes;

    void Awake()
    {
        if (Instance == null)
        {
            // Si no existe instancia, asignar esta y no destruir al cambiar escena
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Inicializar la ruta de la base de datos
            dbPath = "URI=file:" + Application.persistentDataPath + "/RageQuitDB.db";
        }
        else
        {
            // Si ya existe instancia, destruir esta para evitar duplicados
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Sumar el deltaTime a tiempo acumulado para medir duración del nivel
        tiempoAcumuladoEnNivel += Time.deltaTime;
    }

    // Inicializa las estadísticas para un nuevo intento de nivel
    public void Inicializar()
    {
        // Obtener idProgreso del GameSession actual
        // Reiniciar muertes y tiempo acumulado
        muertes = 0;
        tiempoAcumuladoEnNivel = 0f;
        Debug.Log($"Inicializando LevelStatsManager. idProgreso: {idProgreso}");
    }

    // Método estático para limpiar el estado de reinicio para una escena dada
    public static void PrepararCargaDeNivel(string nombreEscena)
    {
        // Permite reiniciar estadísticas de nuevo cuando se cargue la escena
        escenasReiniciadas.Remove(nombreEscena);
    }

    // Reinicia las estadísticas de muertes y tiempo solo una vez por escena cargada
    public void ReiniciarEstadisticas()
    {
        string escenaActual = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Si ya se reiniciaron antes, no hacer nada para evitar reinicios múltiples
        if (escenasReiniciadas.Contains(escenaActual))
        {
            Debug.Log("Ya se reiniciaron las estadísticas para esta escena.");
            return;
        }

        // Reiniciar muertes y tiempo acumulado a cero
        muertes = 0;
        tiempoAcumuladoEnNivel = 0f;
        // Marcar la escena como reiniciada
        escenasReiniciadas.Add(escenaActual);
        Debug.Log("Estadísticas reiniciadas.");
    }

    // Incrementa contador de muertes y guarda la actualización en base de datos
    
}

