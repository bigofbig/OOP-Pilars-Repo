using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    int inputNumber;
    [SerializeField] InputField inputNumberString;//Drag&Drop
    [SerializeField] InputField rabbitNumberString;//Drag&Drop
    [SerializeField] InputField eagleNumberString;//Drag&Drop
    [SerializeField] InputField foxNumberString;//Drag&Drop
    [SerializeField] InputField treeNumberString;//Drag&Drop
    [SerializeField]int rabitNumber;
    [SerializeField]int eagleNumber;
    [SerializeField]int foxNumber;
    [SerializeField]int treeNumber;

    private void Start()
    {
        
    }
    private void Update()
    {
        inputNumber = int.Parse(inputNumberString.text);
        rabitNumber=int.Parse(rabbitNumberString.text);
        eagleNumber=int.Parse(eagleNumberString.text);
        foxNumber=int.Parse(foxNumberString.text);
        treeNumber=int.Parse(treeNumberString.text);
    }
}
