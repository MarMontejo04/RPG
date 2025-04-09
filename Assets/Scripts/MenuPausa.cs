using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public bool juegoPausado = false;
    [SerializeField] private AudioMixer audioMixer;
    
    public void Reanudar(){
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
    }
    public void Pausar(){
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
    }
    public void Salir(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
     public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

}
