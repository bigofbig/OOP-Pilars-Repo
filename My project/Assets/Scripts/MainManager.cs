using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField] Text guideText;
    public static MainManager mainManagerScript;
    [SerializeField] InputField inputNumberString;//Drag&Drop
    [SerializeField] InputField rabbitNumberString;//Drag&Drop
    [SerializeField] InputField eagleNumberString;//Drag&Drop
    [SerializeField] InputField foxNumberString;//Drag&Drop
    [SerializeField] InputField treeNumberString;//Drag&Drop
    string[] sentences = new string[5];
    public int eagleNumber { get { return m_EagleNumber; }
        set
        {
            if (value <= 5) { m_EagleNumber = value; TextMaker(""); }
            if (value > 5) { TextMaker(sentences[0]); }
            if (value < 0) { TextMaker(sentences[1]); }
        }
    }
    int m_EagleNumber;//ENCAPSULATION
    public int foxNumber { get { return m_FoxNumber;  }
        set
        {if (value <= 5) { m_FoxNumber = value; TextMaker(""); }
            if (value > 5) { TextMaker(sentences[0]); }
            if (value < 0) { TextMaker(sentences[1]); }

        }
    }
    int m_FoxNumber;//ENCAPSULATION
    public int treeNumber {
        get {return m_TreeNumber;}
        set
        {
            if (value <= 5) { m_TreeNumber = value; TextMaker(""); }
            if (value > 5) { TextMaker(sentences[0]); }
            if (value < 0) { TextMaker(sentences[1]); }
        }
            }
    int m_TreeNumber;//ENCAPSULATION
    public int rabitNumber { get { return m_RabitNumber;  }
        set {
            if (value <= 5) { m_RabitNumber = value; TextMaker(""); }
            if (value > 5) { TextMaker(sentences[0]); }
            if (value < 0) { TextMaker(sentences[1]); }
        } 
            
    }
    int m_RabitNumber;//ENCAPSULATION

    

    private void Awake()
    {

        Singleton();


        mainManagerScript = this;
        DontDestroyOnLoad(gameObject);


        
        sentences[0] = "Too many!! select between 1-5";
        sentences[1] = "Negative!! Really??";
        guideText.enabled = false;

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
        if (mainManagerScript != null)
        {
            Destroy(gameObject);
            return;
        }
    }//WILL IT WORK?
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void TextMaker(string sentence)
    {
        guideText.enabled = true;
        guideText.text = sentence;
        
        
    }
    
    

}
