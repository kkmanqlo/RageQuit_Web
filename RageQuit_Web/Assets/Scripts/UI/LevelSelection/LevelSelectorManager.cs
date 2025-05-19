using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorManager : MonoBehaviour
{

    public void BotonTutorial()
    {

        SceneManager.LoadScene("Tutorial");
    }

    public void BotonLevel1()
    {

        SceneManager.LoadScene("Level 1");
    }

    public void BotonLevel2()
    {

        SceneManager.LoadScene("Level 2");
    }

        public void BotonLevel3()
    {

        SceneManager.LoadScene("Level 3");
    }

}
