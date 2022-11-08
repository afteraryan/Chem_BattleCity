using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
using System.Linq.Expressions;
using Unity.Collections;
using System.Data;

public class GameController:MonoBehaviour
{
    public static GameController instance;
    [SerializeField] TMP_Text atomicnumberText;
    [SerializeField] TMP_Text elementText;
    [SerializeField] GameObject electronObject;
    int AtomicNumber = 1;
    Dictionary<int, string> elementsDict = new Dictionary<int, string>();

    float xMin = -6.5f, xMax = 7.5f, yMin = -4.0f, yMax = 2.6f;
    Vector2 electronLocation;

    private void Awake()
    {
        if(instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        InitElements();
    }

    private void Start()
    {
        atomicnumberText.text = "Atomic Number: " + AtomicNumber.ToString();
    }

    public void GameOver()
    {
        
    }

    public void IncreaseScore()
    {
        if(AtomicNumber<30)
            AtomicNumber++;
        UpdateScore();
    }

    public void DecreaseScore()
    {
        if (AtomicNumber > 0)
            AtomicNumber--;
        UpdateScore();
    }

    private void UpdateScore()
    {
        atomicnumberText.text = "Atomic Number: " + AtomicNumber.ToString();
        elementText.text = elementsDict[AtomicNumber];
    }


    void InitElements()
    {
        elementsDict.Add(0, "GAME OVER");
        elementsDict.Add(1, "H");
        elementsDict.Add(2, "He");
        elementsDict.Add(3, "Li");
        elementsDict.Add(4, "Be");
        elementsDict.Add(5, "B");
        elementsDict.Add(6, "C");
        elementsDict.Add(7, "N");
        elementsDict.Add(8, "O");
        elementsDict.Add(9, "F");
        elementsDict.Add(10, "Ne");
        elementsDict.Add(11, "Na");
        elementsDict.Add(12, "Mg");
        elementsDict.Add(13, "Al");
        elementsDict.Add(14, "Si");
        elementsDict.Add(15, "P");
        elementsDict.Add(16, "S");
        elementsDict.Add(17, "Cl");
        elementsDict.Add(18, "Ar");
        elementsDict.Add(19, "K");
        elementsDict.Add(20, "Ca");
        elementsDict.Add(21, "Sc");
        elementsDict.Add(22, "Ti");
        elementsDict.Add(23, "V");
        elementsDict.Add(24, "Cr");
        elementsDict.Add(25, "Mn");
        elementsDict.Add(26, "Fe");
        elementsDict.Add(27, "Co");
        elementsDict.Add(28, "No");
        elementsDict.Add(29, "Cu");
        elementsDict.Add(30, "Zn");
    }
    
    public void SpawnElectron()
    {
        if(AtomicNumber < 30)
        {
            electronLocation.x = Random.Range(xMin, xMax);
            electronLocation.y = Random.Range(yMin, yMax);
            Instantiate(electronObject, electronLocation, transform.rotation);
        }
    }
}
