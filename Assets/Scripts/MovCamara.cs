using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera camara;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "portal1") //Entrada a la aldea (escenario 2)
        {
            Vector3 posicionCamara = new Vector3(0, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(0.05f, -3.2f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal2") //Regreso a escenario 1
        {
            Vector3 posicionCamara = new Vector3(0, -11, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(0.05f, -7.77f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal3") // Entrada escenario 8
        {
            Vector3 posicionCamara = new Vector3(20, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(12.73f, -0.97f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal4") // Entrada escenario 6
        {
            Vector3 posicionCamara = new Vector3(0, 11, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(5.15f, 7.85f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal5") //Entrada a fabrica (escenario 3)
        {
            Vector3 posicionCamara = new Vector3(-20, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-12.86f, -0.09f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal6") // Regreso a la aldea (escenario 2)
        {
            Vector3 posicionCamara = new Vector3(0, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-7.2f, 0.11f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal7") //Entrada escenario 5
        {
            Vector3 posicionCamara = new Vector3(-20, 11,-10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17.37f, 7.92f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal8") // Entrada ecenario 4
        {
            Vector3 posicionCamara = new Vector3(-20, -11, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17.07f, -7.99f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal9") //Regreso escenario 3
        {
            Vector3 posicionCamara = new Vector3(-20, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17, -3.2f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal10") // Regreso escenario 3
        {
            Vector3 posicionCamara = new Vector3(-20, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-17.47f, 3, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal11") // Entrada escenario 6
        {
            Vector3 posicionCamara = new Vector3(0, 11, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-7.09f, 10.05f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal12") // Regreso escenario 5
        {
            Vector3 posicionCamara = new Vector3(-20, 11, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(-12.84f, 9.89f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal13") // Regreso escenario 2
        {
            Vector3 posicionCamara = new Vector3(0, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(4.96f, 3.15f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal14") // Entrada escenario 7
        {
            Vector3 posicionCamara = new Vector3(20, 11, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(12.78f, 14, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal15") // Regreso escenario 6
        {
            Vector3 posicionCamara = new Vector3(0, 11, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(7.35f, 13.9f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal16") // Entrada escenario 8
        {
            Vector3 posicionCamara = new Vector3(20, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(17.98f, 3.01f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal17") // Regreso escenario 7
        {
            Vector3 posicionCamara = new Vector3(20, 11, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(18.01f, 7.87f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal18") // Regreso escenario 2
        {
            Vector3 posicionCamara = new Vector3(0, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(7.01f, -1.02f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal19") // Entrada escenario 9
        {
            Vector3 posicionCamara = new Vector3(20, -11, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(20.53f, -8.04f, 0);
            this.transform.position = posicionPlayer;

        }

        if (obj.gameObject.tag == "portal20") // Regreso escenario 8
        {
            Vector3 posicionCamara = new Vector3(20, 0, -10);
            camara.transform.position = posicionCamara;
            Vector3 posicionPlayer = new Vector3(20.56f, -3.07f, 0);
            this.transform.position = posicionPlayer;

        }
    }
}
