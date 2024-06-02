using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoquitoScript : MonoBehaviour
{
    [SerializeField] GameObject[] colors;
    private int currentLightIndex = -1;
    private int cuentaCiclo = 0; //lleva el ciclo de encendido de luces
    private const int CicloMax = 3; // variable constante ya que representa la canridad maxima de ciclos de encendido de luces
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateNextLight()
    {
        currentLightIndex++; //suma 1 a la variable=0
        if (currentLightIndex >= colors.Length) // si es = o mayor a colors lenght (canridad de colores de un array), luego esta variable vuelve a 0 para que no tire error.
        {
            currentLightIndex = 0;
            cuentaCiclo++;
            if (cuentaCiclo >= CicloMax)
            {
                Destroy(gameObject); //destrye el foquito que produce los ciclos de  luces
                return; // Salir de la función para evitar la activación de la luz
            }
        }

        DeactivateAllLights(); //desactiva todas las luces
        colors[currentLightIndex].SetActive(true);  //activa una sola luz, que es el elem,ento que corresponde en la array de colors
    }

    void DeactivateAllLights() //HACE LO MISMO QUE LA ANTERIOR PERO PARA ATRAS_
    {
        foreach (GameObject g in colors)
        {
            g.SetActive(false);
        }
    }

    public void ActivateRepeating(float t)
    {
        CancelInvoke();
        InvokeRepeating(nameof(ActivateNextLight), 0, t);
    }
}
