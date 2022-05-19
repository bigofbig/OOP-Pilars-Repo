using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    bool isReadyToStart = false;
    
    public static MainManager mainManagerScript;
    [SerializeField] InputField inputNumberString;//Drag&Drop
    [SerializeField] InputField rabbitNumberString;//Drag&Drop
    [SerializeField] InputField eagleNumberString;//Drag&Drop
    [SerializeField] InputField foxNumberString;//Drag&Drop
    [SerializeField] InputField treeNumberString;//Drag&Drop
    
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

    

    private void Awake()
    {

        if (mainManagerScript != null)
        {
            Destroy(gameObject);
            return;
        }


        mainManagerScript = this;
        DontDestroyOnLoad(gameObject);


        
       
       
       

    }
    
    private void Update()
    {
        //ABSTRACTION
        ConvertInputsToInt();

        



    }

  
    void ConvertInputsToInt()
    {
        if (treeNumberString.text != "") { treeNumber = int.Parse(treeNumberString.text); }
        if (rabbitNumberString.text != "") { rabitNumber = int.Parse(rabbitNumberString.text); }
        if (eagleNumberString.text != "") { eagleNumber = int.Parse(eagleNumberString.text); }
        if (foxNumberString.text != "") { foxNumber = int.Parse(foxNumberString.text); }
    }
    void Singleton()
    {
       
    }//WILL IT WORK?
    public void StartGame()
    {
        if (isReadyToStart == true){ SceneManager.LoadScene(1); }
        
    }

  
    
    

}
