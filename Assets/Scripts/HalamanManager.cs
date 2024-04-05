using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit;

    void Start ()
    {
    }

    void Update ()
    {
        if (Input.GetKeyUp (KeyCode.Escape)) {
            if (isEscapeToExit) {
                Application.Quit ();
            } else {
                KembaliKeMenu ();
            }
        }
    }

    public void MulaiPermainan ()
    {
        SceneManager.LoadScene ("SampleScene");
    }

    public void KembaliKeMenu ()
    {
        SceneManager.LoadScene ("mainMenu");
    }
}
