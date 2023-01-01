namespace Mastermind;

/* Steps for myself.
 * 
 * Generate a 4 colour code. Colours can repeat. 
 * 6 Different colours. (I'll pick Red, Yellow, Green, Blue, White and Black).
 * Black pegs = Correct colour in correct position.
 * White pegs = Correct colour in wrong position.
 * Allow user to make a guess by tapping the circles until they have the colour they want.
 * Confirm button at bottom to confirm their guess.
 * Compare the guess to the hidden code and place the black or white pegs.
 * If they get the correct code, display an alert that they have won the game and display the code at the bottom of the screen.
 * Complete the save and restart button functionalities.
 */

// Majority of comments will be taken from the above set of steps.
public partial class MainPage : ContentPage
{
    Random _random;
    int[] _code = new int[4];

    public MainPage()
	{
		InitializeComponent();
        _random = new Random();
        GenerateHiddenCode();
    }

    // Complete the save and restart button functionalities.
    private void BtnRestart_Clicked(object sender, EventArgs e)
    {
    }

    private void BtnSave_Clicked(object sender, EventArgs e)
    {
    }

    private void BtnConfirm_Clicked(object sender, EventArgs e)
    {
    }

    // Generate a 4 colour code. Colours can repeat.
    // 6 Different colours. (I'll pick Red, Yellow, Green, Blue, White and Black).
    private void GenerateHiddenCode()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomNum = _random.Next(1, 6);
            
            if (i == 0)
            {
                _code[i] = randomNum;
                LblTest.Text = _code[0].ToString();
            }
            else if(i == 1)
            {
                _code[i] = randomNum;
                LblTest2.Text = _code[1].ToString();
            }
            else if(i == 2)
            {
                _code[i] = randomNum;
                LblTest3.Text = _code[2].ToString();
            }
            else if(i == 3)
            {
                _code[i] = randomNum;
                LblTest4.Text = _code[3].ToString();
            }
            
            
            
            
        }
    }
}

