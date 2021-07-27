using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script : MonoBehaviour {
    
    public GameObject background;
    public GameObject Hewan;

    // Start is called before the first frame update
    void Start() {
        background.SetActive(true);
        Hewan.SetActive(false);
    }

    public void PerkembangbiakanButtonClicked()
    {
        Hewan.SetActive(true);
        background.SetActive(false);
    }
    public void NextButtonClicked()
    {
        Application.LoadLevel("Game");
    }
}
