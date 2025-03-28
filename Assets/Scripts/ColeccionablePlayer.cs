using UnityEngine;

public class ColeccionablePlayer : MonoBehaviour
{
    private GameObject player;
    public static string objAColeccionar;
    private Inventario inventario;
   
    void Start()
    {
        player = GameObject.Find("Player");
        objAColeccionar = "";
        inventario = FindObjectOfType<Inventario>();
    }
     private void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "botiquin"){
            AplicaCambio(obj);
        }
        if(obj.tag == "engrane"){
            AplicaCambio(obj);
        }
        if(obj.tag == "brazo"){
            AplicaCambio(obj);
        }
    }

    private void AplicaCambio(Collider2D obj){
        objAColeccionar = obj.tag;
        inventario.EscribeEnArreglo();
        Destroy(obj.gameObject);
        }
   
}
