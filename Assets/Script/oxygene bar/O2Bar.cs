using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2Bar : MonoBehaviour
{
    public Slider O2Slider;
    bool O2one;
    public bool isInO2Zone = false;
    int maxO2 =100;
    int currentO2;
    float regenRate = 1.0f;  // Vitesse de régénération de l'O2 (modifiable selon vos besoins)
    float drainRate = 1.0f;  // Vitesse de consommation de l'O2 (modifiable selon vos besoins)
    private bool isDecreasingO2 = false;
    private bool isIncreasingO2 = false;

    void Start()
    {
        //O2Slider = GetComponent<Slider>();
        SetMaxO2(maxO2);  // Assurez-vous de définir la valeur maximale de l'O2
    }

    void Update()
    {
       /* if (isInO2Zone)
        {
            // Augmenter l'O2 progressivement en fonction de la vitesse de régénération
            currentO2 = Mathf.Clamp(currentO2 + Mathf.RoundToInt(regenRate * Time.deltaTime), 0, maxO2);
        }
        else
        {
            // Diminuer l'O2 progressivement en fonction de la vitesse de consommation
            //currentO2 = Mathf.Clamp(currentO2 - Mathf.RoundToInt(drainRate * Time.deltaTime), 0, maxO2);
            //currentO2 -= 1;
            StartCoroutine(LowerO2());
        }
        //currentO2 = Mathf.Clamp(currentO2 - Mathf.RoundToInt(drainRate * Time.deltaTime), 0, maxO2);
        SetO2(currentO2);  // Mettre à jour la valeur de l'O2 sur le slider
        Debug.Log(isInO2Zone);
        Debug.Log(currentO2);*/
    }
    private void FixedUpdate()
    {


        if (isInO2Zone)
        {
            if (!isIncreasingO2)
            {
                StartCoroutine(IncreaseO2());
            }
        }
        else
        {
            // Diminuer l'O2 progressivement en fonction de la vitesse de consommation
            //currentO2 = Mathf.Clamp(currentO2 - Mathf.RoundToInt(drainRate * Time.deltaTime), 0, maxO2);
            //currentO2 -= 1;
            if (!isDecreasingO2)
            {
                StartCoroutine(DecreaseO2());
            }
        }
        //currentO2 = Mathf.Clamp(currentO2 - Mathf.RoundToInt(drainRate * Time.deltaTime), 0, maxO2);
        SetO2(currentO2);  // Mettre à jour la valeur de l'O2 sur le slider
        Debug.Log(isInO2Zone);
        Debug.Log(currentO2);
    }

    public void SetMaxO2(int maxO2)
    {
        this.maxO2 = maxO2;
        O2Slider.maxValue = maxO2;
        O2Slider.value = maxO2;
        currentO2 = maxO2;
    }

    public void SetO2(int O2)
    {
        O2Slider.value = O2;
    }

    // Appelée lorsque le joueur entre dans la zone d'O2
    public void EnterO2Zone()
    {
        isInO2Zone = true;
    }

    // Appelée lorsque le joueur quitte la zone d'O2
    public void ExitO2Zone()
    {
        isInO2Zone = false;
    }
    IEnumerator DecreaseO2()
    {
        isDecreasingO2 = true;
        yield return new WaitForSeconds(1.0f);
        currentO2 -= 1;
        isDecreasingO2 = false;
    }

    IEnumerator IncreaseO2()
    {
        isIncreasingO2 = true;
        yield return new WaitForSeconds(0.1f);
        currentO2 += 1;
        isIncreasingO2 = false;
    }
}
