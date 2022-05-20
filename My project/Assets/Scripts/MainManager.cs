using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static  bool  isReadyToStart = false;
    
    public static MainManager mainManagerScript;
    
    [SerializeField] InputField rabbitNumberString;
    [SerializeField] InputField eagleNumberString;
    [SerializeField] InputField foxNumberString;
    [SerializeField] InputField treeNumberString;
    
    public int eagleNumber { get { return m_EagleNumber; }
        set
        {
            if (value <= 5) { m_EagleNumber = value; isReadyToStart = true; }
            else { isReadyToStart = false; }
            
            
        }
    }
    int m_EagleNumber;//ENCAPSULATION
    public int foxNumber { get { return m_FoxNumber;  }
        set
        {if (value <= 5) { m_FoxNumber = value; isReadyToStart = true; }
            else { isReadyToStart = false; }


        }
    }
    int m_FoxNumber;//ENCAPSULATION
    public int treeNumber {
        get {return m_TreeNumber;}
        set
        {
            if (value <= 5) { m_TreeNumber = value; isReadyToStart = true; }
            else { isReadyToStart = false; }

        }
            }
    int m_TreeNumber;//ENCAPSULATION
    public int rabitNumber { get { return m_RabitNumber;  }
        set {
            if (value <= 5) { m_RabitNumber = value; isReadyToStart = true; }
            else { isReadyToStart = false; }

        } 
            
    }
    int m_RabitNumber;//ENCAPSULATION

    [SerializeField]InputValues inputValuesScript;

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            //ABSTRACTION
            InputFiledInitializer();
            //ABSTRACTION
            ResetAnimalsCount();



        }
    }
    private void Awake()
    {
        
        InputFiledInitializer();

        DataPersistent();





    }
    
    private void Update()
    {
        //ABSTRACTION
        ConvertInputsToInt();
    }

 
 ///////////////////////////////////
 
    void ConvertInputsToInt()
    {
        if (treeNumberString.text != "") { treeNumber = int.Parse(treeNumberString.text); }
        if (rabbitNumberString.text != "") { rabitNumber = int.Parse(rabbitNumberString.text); }
        if (eagleNumberString.text != "") { eagleNumber = int.Parse(eagleNumberString.text); }
        if (foxNumberString.text != "") { foxNumber = int.Parse(foxNumberString.text); }
    }

    void InputFiledInitializer()
    {
        inputValuesScript = FindObjectOfType<InputValues>();

        rabbitNumberString = inputValuesScript.rabbitInputString;
        eagleNumberString = inputValuesScript.eagleInputString;
        foxNumberString = inputValuesScript.foxInputString;
        treeNumberString = inputValuesScript.treeInputString;
    }
    void ResetAnimalsCount()
    {
        rabitNumber = 0;
        treeNumber = 0;
        eagleNumber = 0;
        foxNumber = 0;
    }

    void DataPersistent()
    {
        if (mainManagerScript != null)
        {
            Destroy(gameObject);
            return;

        }//singleton


        mainManagerScript = this;
        DontDestroyOnLoad(gameObject);


    }//DataPersistent between scenes
}
