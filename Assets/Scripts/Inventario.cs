using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private bool muestraInventario;
    public GameObject goInventario;
    [SerializeField] private string[] valoresInventario;
    private int numBotiquines, numEngranes, numBrazos;
    Button boton;
    public  Sprite contenedor, fondo, botiquin, engrane, brazo;
    private GameObject Player;
   

    void Start()
    {
        muestraInventario = false;
        BorrarArreglo();
        numBotiquines = 0;
        numBrazos = 0;
        numEngranes = 0;
        Player = GameObject.Find("Player");
        contenedor = fondo;
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
                contenedor = botiquin;
                numBotiquines++;
                boton.GetComponentInChildren<Text>().text = "x" + numBotiquines.ToString();
                break;
            case "brazo":
                contenedor = brazo;
                numBrazos++;
                boton.GetComponentInChildren<Text>().text = "x" + numBrazos.ToString();
                break;
            case "engrane":
                contenedor = engrane;
                numEngranes++;
                boton.GetComponentInChildren<Text>().text = "x" + numEngranes.ToString();
                break;
        }
        boton.GetComponent<Image>().sprite = contenedor;
    }
     public void UsarItem(int pos)
    {
        bool itemUsado = false;
        if (ColeccionablePlayer.objAColeccionar == "botiquin")
        {
            if(VidasPlayer.vida < VidasPlayer.vidasINI){
            VidasPlayer.vida++;
            numBotiquines--;
            boton.GetComponentInChildren<Text>().text = "x" + numBotiquines.ToString();
            Player.GetComponent<VidasPlayer>().DibujaVida(VidasPlayer.vida);
            itemUsado = true; 
            }
           
        }
        else if (ColeccionablePlayer.objAColeccionar == "brazo")
        {
            if(EnergiaPlayer.energia < EnergiaPlayer.energiaMax){
            EnergiaPlayer.energia +=20;
            numBrazos--;
            boton.GetComponentInChildren<Text>().text = "x" + numBrazos.ToString();
            Player.GetComponent<EnergiaPlayer>().DibujaEnergia(EnergiaPlayer.energia);
            itemUsado = true; 
            }
        }
        if(itemUsado && (numBotiquines == 0 || numBrazos == 0)){
        valoresInventario[pos] = "";
        boton.GetComponentInChildren<Text>().text = "";
        GameObject.Find("Elemento (" + pos + ")").GetComponent<Button>().GetComponent<Image>().sprite = fondo;
        
        }else if(itemUsado){
            valoresInventario[pos] = "";
            GameObject.Find("Elemento (" + pos + ")").GetComponent<Button>().GetComponent<Image>().sprite = contenedor;
        }
        
    }

    private void BorrarArreglo(){
        for(int i = 0; i < valoresInventario.Length; i++){
            valoresInventario[i]="";
        }
    }

   

   
}
