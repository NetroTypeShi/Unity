using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class comportamiento : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int winq = 0;
    [SerializeField] int winp = 0;
    [SerializeField] int q = 0;
    [SerializeField] int p = 0;
    [SerializeField] TMP_Text pressSpace;
    [SerializeField] TMP_Text WinUI;
    [SerializeField] TMP_Text pwinCounterUI;
    [SerializeField] TMP_Text qwinCounterUI;
    [SerializeField] TMP_Text qPressingsUI;
    [SerializeField] TMP_Text pwinDefinitive;
    [SerializeField] TMP_Text qwinDefinitive;
    [SerializeField] TMP_Text pPressingsUI;
    [SerializeField] int Winsize = 125;
    [SerializeField] int LoseSize = 70;
    [SerializeField] int DrawSize = 80;
    bool keyLock = false;

    void Start()
    {
        keyLock = true;
        print("comportamiento: " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {

        stopGame();

        if (keyLock == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))

                q = q + 1;

            if (Input.GetKeyDown(KeyCode.P))

                p = p + 1;
        }
        else
        {
            keyLock = true;
        }
        
        PrintValues();

        if (q == 10)
        {
            keyLock = true;

            winq = winq + 1;
            print("q wins");
            q = 0;
            p = 0;
            WinUI.text = "Q GANA";
            Invoke("HideWinUI", 3);
            print("q lleva " + winq + " victorias");
            qwinCounterUI.text = winq.ToString();
             
        }
        if (p == 10)
        {
            keyLock = true;
            winp = winp + 1;
            print("p wins");
            p = 0;
            q = 0;
            WinUI.text = "P GANA";
            print("p lleva " + winp + " victorias");
            Invoke("HideWinUI", 3);
            pwinCounterUI.text = winp.ToString();
            // ESPERAR 2 SEGONDO
        }

        if (winp == 5)
        {
            winp = 0;
            pwinDefinitive.text = "P Gano el juego".ToString();
            pressSpace.text = "Presiona Espacio para reiniciar".ToString();
            keyLock = true;
            stopGame();
        }
        // P gana el juego
        if (winq == 5)
        {
            winq = 0;
            qwinDefinitive.text = "Q Gano el juego".ToString();
            pressSpace.text = "Presiona Espacio para reiniciar".ToString();
            keyLock = true;
            stopGame();
        }
        // Q gana el juego




    }
    //para sumar los numeros al pulsar
    void PrintValues()
    {
        if (q < p)
        {
            pPressingsUI.fontSize = Winsize;
            qPressingsUI.fontSize = LoseSize;

        }
        if (q > p)
        {
            qPressingsUI.fontSize = Winsize;
            pPressingsUI.fontSize = LoseSize;
        }
        if (p == q)
        {
            qPressingsUI.fontSize = DrawSize;
            pPressingsUI.fontSize = DrawSize;
        } 
        
        // Para cambiar la fuente

        qPressingsUI.text = q.ToString();
        pPressingsUI.text = p.ToString();
        // Quitar p y q
    }
    void HideWinUI()
    {
        WinUI.text = "";
        keyLock = false;
    }
        // pa quitar en 2 seg
    void stopGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyLock = false;
            pressSpace.text = " ";
            qwinDefinitive.text = " ".ToString();
            pwinDefinitive.text = " ".ToString();
            WinUI.text = " ";
            pwinCounterUI.text = " ".ToString();
            qwinCounterUI.text = " ".ToString();
        }
    }
    //parar el juego

    
 
}
