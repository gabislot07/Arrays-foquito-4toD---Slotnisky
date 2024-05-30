using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoquitoScript : MonoBehaviour
{
    [SerializeField] GameObject[] colors;
    public int currentLightIndex =-1;

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
        }
        DeactivateAllLights(); //desactiva todas las luces
        colors[currentLightIndex].SetActive(true); //activa una sola luz, que es el elem,ento que corresponde en la array de colors
    }

    public void ActivatePreviousLight() //HACE LO MISMO QUE LA ANTERIOR PERO PARA ATRAS
    {
        currentLightIndex--;
        if (currentLightIndex < 0)
        {
            currentLightIndex = colors.Length - 1;
        }
        DeactivateAllLights();
        colors[currentLightIndex].SetActive(true);
    }

    void DeactivateAllLights()
    {
        foreach (GameObject g in colors)
        {
            g.SetActive(false);
        }
    }

    public void ActivateRepeating(float t)
    {
        CancelInvoke();
        InvokeRepeating(nameof(ActivateNextLight),0,t);
    }
}
