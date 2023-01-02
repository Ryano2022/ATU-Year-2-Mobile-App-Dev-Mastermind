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
    int[] _code;
    int _rowIncrement;

    public MainPage()
	{
		InitializeComponent();
        _random = new Random();
        _code = new int[4];
        _rowIncrement = 0;
        GenerateHiddenCode();
        NewRow();
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
        NewRow();
    }

    // Generate a 4 colour code. Colours can repeat.
    // 6 Different colours. (I'll pick Red, Yellow, Green, Blue, White and Black).
    private void GenerateHiddenCode()
    {
        for (int i = 0; i < _code.Length; i++)
        {
            int randomNum = _random.Next(0, 5);
            
            if (i == 0)
            {
                _code[i] = randomNum;
                AssignColour(randomNum, BVCode0);
                
            }
            else if(i == 1)
            {
                _code[i] = randomNum;
                AssignColour(randomNum, BVCode1);

            }
            else if(i == 2)
            {
                _code[i] = randomNum;
                AssignColour(randomNum, BVCode2);
            }
            else if(i == 3)
            {
                _code[i] = randomNum;
                AssignColour(randomNum, BVCode3);
            }
        }
    }

    private void AssignColour(int randomNum, BoxView BVCode)
    {
        if (randomNum == 0)
        {
            BVCode.Color = Colors.Red; 
        }
        else if (randomNum == 1)
        {
            BVCode.Color = Colors.Yellow;
        }
        else if (randomNum == 2)
        {
            BVCode.Color = Colors.Green;
        }
        else if (randomNum == 3)
        {
            BVCode.Color = Colors.Blue;
        }
        else if (randomNum == 4)
        {
            BVCode.Color = Colors.Black;
        }
        else
        {
            BVCode.Color = Colors.White;
        }
    }

    private void NewRow()
    {
        BoxView BV;
        for (int i = 0; i < 4; i++) {
            BV = new BoxView();
            GridGame.Children.Add(BV);
            BV.Color = Colors.Red;
            BV.CornerRadius = 30;
            BV.SetValue(Grid.RowProperty, _rowIncrement);
            BV.SetValue(Grid.ColumnProperty, i);
        }

        if (_rowIncrement < 9) 
        {
            _rowIncrement++;
        }
        else
        {
            BtnConfirm.IsEnabled = false;
            BtnConfirm.IsVisible = false;
            LblCode.IsVisible = true;
            SLCode.IsVisible = true;
        }
    }
}

