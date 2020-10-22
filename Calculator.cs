using UnityEngine;
using TMPro; //imported our UI elements script 


public class Calculator : MonoBehaviour //the public class Calculator is how we call this script into unity.

{
    #region fields 
    //A region allows me to tidy my code up by sectioning my various code such as methods and variables.

    public TextMeshProUGUI InputText; // Initializes our buttons for displaying what we want in our scripts.
    private int _result; // Initializes the result of two inputs as an interger.
    private int _input; // Initializes the input of the user as an interger.
    private int _input2; // Initializes the second input of the user as an integer.
    private string _operation; // Initializes the variable for our operaters as a string.
    public int _clear; // Initializes the clear function as an interger. 
    public AudioSource buttonSound; // Initializes the variable buttonSound as an audio source.
    private int _reset; // Initializes the reset function as an interger.

    // Public means the script is accessible by unity and private means it wont be.

    #endregion fields

    #region methods
    public void ClickNumber(int val) // Clicknumber is the function allowing us to apply this method to our unity buttons, making val an    interger. In other methods we have to convert the string to a val in order to express and use it.
    {
        Debug.Log(message: $" check val: {val}"); // This will print the values we press on our calculators buttons to the console in unity and we use val as it needs to .
        InputText.text = $""; // This will update the input field with the number the user presses on the calculator, while also creating a blank value so the null value dosent stack.                

        if (_operation == null)  // If the operator is equal to null c# goes to the if statement within it.
        {
            if (_input == 0) // For as long as the operator is not used we go through this if statement in which c# will input the first value and thereafter times the input by 10 and add the inputted value to make sure it stacks correctly on the calculator.
            {
                _input = val;
                InputText.text = val.ToString(); // Displaying first value.
            }
            else
            {
                _input = (_input * 10) + val; // Equation for adding to the current value of our input in order for it to stack on the calculator.
                InputText.text += _input.ToString(); // Displaying any additional values the user inputs.
            }
        }
        else // If the user uses an operator it will go to our else statement in which the same process above is repeated till they use the equals function. 
        {            
            if (_input2 == 0)
            {
                _input2 = val;
                InputText.text = val.ToString();
            }
            else
            {
                _input2 = (_input2 * 10) + val;
                InputText.text += _input2.ToString();
            }
        }             
    }
    public void ClickOperation(string val) // In our operator function we are converting the string to a value.
    {
        Debug.Log(message: $" ClickOperation val: {val}");
        _operation = val; // Assigns our operators as a value for functionality. 
        InputText.text = _operation.ToString(); // Prints our operator to our calculater as a string.
    }
    public void ClickEqual(string val) 
    {
        Debug.Log(message: $" ClickEqual val: {val}");
        
        if (_input != 0 && _input2 != 0 && !string.IsNullOrEmpty(_operation))
        // If input 1 and 2 are not equal to 0 and our operator string is empty then we will switch to our cases which has the solution for each result on our operators using the correct string operator. 
        {
            switch (_operation) // Switches to our variabale to call the strings for each operator.
            {
                case "+":

                    _result = _input + _input2;

                    break;

                case "-":

                    _result = _input - _input2;

                    break;

                case "*":

                    _result = _input * _input2;

                    break;

                case "/":

                    _result = _input / _input2;

                    break;
                              
            }

            
            InputText.SetText(_result.ToString()); // Will show our result on the calculator and convert it to a string.
            Reset(); // Calls the  Reset function after our result has been achieved to clear values and operators for the next sum.



        }




    }
    
    private void Reset() 
    {
        _input = 0; // Setting the first input back to 0
        _input2 = 0; //Setting the second input back to 0
        _operation = null; // Resetting the operation so that there is no operation being used. 
    }
 

    private void clearInput() 
    {        
        InputText.text = _clear.ToString(); // Clear function will display a 0 when the user utilizes our clear button. 
    } 

    void OnClick()
    {
        buttonSound.Play(); // Using the on click function we have set our button to play a sound when clicked.
    }

    #endregion methods 

}