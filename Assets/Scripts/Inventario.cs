using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private bool muestraInventario;
    public GameObject goInventario;
    [SerializeField] private string[] valoresInventario;
    private int numBotiquines, numBrazos;
    Button boton;
    public  Sprite fondo, botiquin, brazo;
    private GameObject Player;
   

    void Start()
    {
        muestraInventario = false;
        BorrarArreglo();
        numBotiquines = 0;
        numBrazos = 0;
        Player = GameObject.Find("Player");
    }

    public void StatusInventario(){
        if(muestraInventario){
            muestraInventario = false;
            goInventario.SetActive(false);
            Time.timeScale = 1;
        }else{
            muestraInventario = true;
            goInventario.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void EscribeEnArreglo(){
        if(VerificarEnArreglo() == -1){
            for(int i = 0; i < valoresInventario.Length; i++){
                if(valoresInventario[i] == ""){
                    valoresInventario[i] = ColeccionablePlayer.objAColeccionar;
                    DibujaElementos(i);
                    break;
                }
            }
        }else{
            DibujaElementos(VerificarEnArreglo());
        }
    }

    private int VerificarEnArreglo(){
        int pos = -1;
        for(int i = 0; i < valoresInventario.Length; i++){
            if(valoresInventario[i] == ColeccionablePlayer.objAColeccionar){
                pos=i;
                break;
            }
        }
        return pos;
    }

    public void DibujaElementos(int pos){
        StatusInventario();
        boton = GameObject.Find("Elemento ("+pos+")").GetComponent<Button>();
        switch(ColeccionablePlayer.objAColeccionar){
            case "botiquin":
                boton.GetComponent<Image>().sprite = botiquin;
                numBotiquines++;
                boton.GetComponentInChildren<Text>().text = "x" + numBotiquines.ToString();
                break;
            case "brazo":
                boton.GetComponent<Image>().sprite = brazo;
                numBrazos++;
                boton.GetComponentInChildren<Text>().text = "x" + numBrazos.ToString();
                break;
        }
    }
     public void UsarItem(int pos)
    {
        boton = GameObject.Find("Elemento ("+pos+")").GetComponent<Button>();
        switch(ColeccionablePlayer.objAColeccionar){
            case "botiquin":
                if(numBotiquines > 0 && VidasPlayer.vida < VidasPlayer.vidasINI){
                        VidasPlayer.vida++;
                        numBotiquines--;
                        boton.GetComponentInChildren<Text>().text = "x" + numBotiquines.ToString();
                        Player.GetComponent<VidasPlayer>().DibujaVida(VidasPlayer.vida);
                        
                }else if(numBotiquines == 0){
                    valoresInventario[pos]="";
                    boton.GetComponent<Image>().sprite = fondo;
                    boton.GetComponentInChildren<Text>().text = "";
                }
                break;
            case "brazo":
                if(numBrazos > 0 && EnergiaPlayer.energia < EnergiaPlayer.energiaMax){
                        EnergiaPlayer.energia+=20;
                        numBrazos--;
                        boton.GetComponentInChildren<Text>().text = "x" + numBrazos.ToString();
                        Player.GetComponent<EnergiaPlayer>().DibujaEnergia(EnergiaPlayer.energia);
                
                }else if(numBrazos == 0){
                    valoresInventario[pos]="";
                    boton.GetComponent<Image>().sprite = fondo;
                    boton.GetComponentInChildren<Text>().text = "";
                } 
                break;    
        }
    }
       

    private void BorrarArreglo(){
        for(int i = 0; i < valoresInventario.Length; i++){
            valoresInventario[i]="";
        }
    }

   }