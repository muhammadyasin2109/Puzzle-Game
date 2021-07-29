using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject background;
    public GameObject about;

    // Start is called before the first frame update
    void Start() {
        background.SetActive(true);
        about.SetActive(false);
    }

    public void playButtonClicked()
    {
        Application.LoadLevel("LevelSelection");
    }
    public void aboutButtonClicked()
    {
        about.SetActive(true);
        background.SetActive(false);
    }
    public void backButtonClicked()
    {
        background.SetActive(true);
        about.SetActive(false);
    }
}
