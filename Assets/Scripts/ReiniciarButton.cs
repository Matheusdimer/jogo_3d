using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarButton : MonoBehaviour
{
    public void Reiniciar()
    {
        Debug.Log("testee");
        SceneManager.LoadScene("Scenes/Game");
    }
}
