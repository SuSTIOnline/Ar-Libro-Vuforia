using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    private Animator animator;
    public static bool hayRegalo = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (hayRegalo == true)
        {
            animator.Play("DestelloBlanco");
            hayRegalo = false;
        }
    }

    public void CambiarDeEscena()
    {
        SceneManager.LoadScene("TheGift");
    }


    public void IrAEscenaAlbum()
    {
        SceneManager.LoadScene("AlbumScene");
    }
}
