using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GoToCamera()
    {
        SceneManager.LoadScene("CameraScene");
    }

    public void GoToAlbum()
    {
        SceneManager.LoadScene("AlbumScene");
    }
}
