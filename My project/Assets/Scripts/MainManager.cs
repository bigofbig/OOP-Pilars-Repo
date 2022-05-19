using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager mainManagerScript;
    [SerializeField] InputField inputNumberString;//Drag&Drop
    [SerializeField] InputField rabbitNumberString;//Drag&Drop
    [SerializeField] InputField eagleNumberString;//Drag&Drop
    [SerializeField] InputField foxNumberString;//Drag&Drop
    [SerializeField] InputField treeNumberString;//Drag&Drop
   
    [SerializeField]public int eagleNumber;
    int m_EagleNumber;
    [SerializeField]public int foxNumber;
    int m_FoxNumber;
    [SerializeField]public int treeNumber;
    int m_TreeNumber;
    [SerializeField]public int rabitNumber { get { return m_RabitNumber; }
        set {
            if (value <= 5) { m_RabitNumber = value; }
            if (value > 5) { print("Too many!!"); }
            if (value < 0) { print("Negative? really??"); }
        } 
            
    }
    int m_RabitNumber;

    private void Awake()
    {
        

        if(mainManagerScript != null)
        {
            Destroy(gameObject);
            return;
        }//singleton

        mainManagerScript = this;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Update()
    {
     
        rabitNumber=int.Parse(rabbitNumberString.text);
        eagleNumber=int.Parse(eagleNumberString.text);
        foxNumber=int.Parse(foxNumberString.text);
        treeNumber=int.Parse(treeNumberString.text);

        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

   
}
