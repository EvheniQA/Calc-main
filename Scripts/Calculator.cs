using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Calculator : MonoBehaviour
{
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private Text expresionText;

    private string[] _operands = {"+", "-", "^", "*", "/"};

    private bool _isFirstValue = false;
    private bool _isSecondValue = false;
    private bool _isPoint = false;

    private string _result;
    private string _value_1;
    private string _value_2;

    private string _operand;
    

    private string EnterKey;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //DebugLoger();
    }


    public void IsKeyPressed()
    {
        EnterKey = Key.key;
        FindOperand();
        if (!_isFirstValue)
        {
            if (EnterKey != "/" && EnterKey != "*" && EnterKey != "+" 
                && EnterKey != "-" && EnterKey != "=" && EnterKey != "^")
            {
               
                _value_1 = EnterPoint(_value_1);
                resultText.text = "" + _value_1;
            }
        }
        if (_isSecondValue) 
        {
            if (EnterKey != "/" && EnterKey != "*" && EnterKey != "+" 
                && EnterKey != "-" && EnterKey != "=" && EnterKey != "^" )
            {
                
                _value_2 = EnterPoint(_value_2);
                UIWrite();
            }
            Answer(_operand);
        }
    }

    private void Answer(string operand) 
    {
        if (EnterKey == "=" && _operand == operand)
        {
            expresionText.text = _value_1 + operand + _value_2;
            switch (operand)
            {
                case "+":
                    _result = (float.Parse(_value_1) + float.Parse(_value_2)).ToString();
                    break;
                case "-":
                    _result = (float.Parse(_value_1) - float.Parse(_value_2)).ToString();
                    break;
                case "/":
                    _result = (float.Parse(_value_1) / float.Parse(_value_2)).ToString();
                    break;
                case "*":
                    _result = (float.Parse(_value_1) * float.Parse(_value_2)).ToString();
                    break;
                case "^":
                    _result = (Math.Pow(float.Parse(_value_1), float.Parse(_value_2))).ToString();
                    break;
            }
            _isPoint = false;
            Debug.Log(_result);
            NullResult();
        }
    }

    private void NullResult() 
    {
        resultText.text = _result;
        _value_2 = null;
        _value_1 = _result;
    }

    private void UIWrite() 
    {
        expresionText.text = _value_1 + " " + _operand;
        resultText.text = "" + _value_2;
    }

    private void FindOperand()
    {
        for (int i = 0; i < _operands.Length; i++) 
        {
            isOperandFinded(_operands[i]);
        }
    }

    private void isOperandFinded(string operand) 
    {
        if (EnterKey == operand && _value_1 != null)
        {
            _operand = operand;
            _isFirstValue = true;
            _isSecondValue = true;
        }
        expresionText.text = _operand;
    }

    private void AllClear()
    {
        if (EnterKey == "AC")
        {
            _value_2 = null;
            _value_1 = null;
            _operand = null;

            _isFirstValue = false;
            _isSecondValue = false;
            _isPoint = false;

            expresionText.text = "";
            resultText.text = "";
        }
    }

    private string EnterPoint(string value) 
    {
        print(EnterKey == "," && !_isPoint);
        print(EnterKey);


        if (EnterKey == "," && !_isPoint)
        {
            print("");
            if (value != null)
            {
                value += ",";
            }
            else
            {
                value += "0,";
            }
            _isPoint = true;
        }
        else
        {
            if (EnterKey == ",") 
            {
                EnterKey = "";
            }
            value += EnterKey;
        }
        return value;
    }


    private void DebugLoger() 
    {
        Debug.Log("value1 = " + _value_1 + "\n " +
            "value2 = " + _value_2 + "\n " +
            "operand  = " + _operand + "\n " +
            "isFirstValue = " + _isFirstValue + "\n " +
            "isSecondValue = " + _isSecondValue);
    }



}
