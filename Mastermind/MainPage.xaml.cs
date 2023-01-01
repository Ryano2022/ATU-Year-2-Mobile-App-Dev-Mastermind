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
            int randomNum = _random.Next(1, 6);
            
            if (i == 0)
            {
                _code[i] = randomNum;
                if(randomNum == 0)
                {
                    BVCode0.Color = Colors.Red;
                }
                else if(randomNum == 1)
                {
                    BVCode0.Color = Colors.Yellow;
                }
                else if (randomNum == 2)
                {
                    BVCode0.Color = Colors.Green;
                }
                else if (randomNum == 3)
                {
                    BVCode0.Color = Colors.Blue;
                }
                else if (randomNum == 4)
                {
                    BVCode0.Color = Colors.Black;
                }
                else
                {
                    BVCode0.Color = Colors.White;
                }
            }
            else if(i == 1)
            {
                _code[i] = randomNum;
                if (randomNum == 0)
                {
                    BVCode1.Color = Colors.Red;
                }
                else if (randomNum == 1)
                {
                    BVCode1.Color = Colors.Yellow;
                }
                else if (randomNum == 2)
                {
                    BVCode1.Color = Colors.Green;
                }
                else if (randomNum == 3)
                {
                    BVCode1.Color = Colors.Blue;
                }
                else if (randomNum == 4)
                {
                    BVCode1.Color = Colors.Black;
                }
                else
                {
                    BVCode1.Color = Colors.White;
                }
            }
            else if(i == 2)
            {
                _code[i] = randomNum;
                if (randomNum == 0)
                {
                    BVCode2.Color = Colors.Red;
                }
                else if (randomNum == 1)
                {
                    BVCode2.Color = Colors.Yellow;
                }
                else if (randomNum == 2)
                {
                    BVCode2.Color = Colors.Green;
                }
                else if (randomNum == 3)
                {
                    BVCode2.Color = Colors.Blue;
                }
                else if (randomNum == 4)
                {
                    BVCode2.Color = Colors.Black;
                }
                else
                {
                    BVCode2.Color = Colors.White;
                }
            }
            else if(i == 3)
            {
                _code[i] = randomNum;
                if (randomNum == 0)
                {
                    BVCode3.Color = Colors.Red;
                }
                else if (randomNum == 1)
                {
                    BVCode3.Color = Colors.Yellow;
                }
                else if (randomNum == 2)
                {
                    BVCode3.Color = Colors.Green;
                }
                else if (randomNum == 3)
                {
                    BVCode3.Color = Colors.Blue;
                }
                else if (randomNum == 4)
                {
                    BVCode3.Color = Colors.Black;
                }
                else
                {
                    BVCode3.Color = Colors.White;
                }
            }
        }

        
    }

    private void NewRow()
    {
        for (int j = 0; j < 4; j++) {
            BoxView BV = new BoxView();
            GridGame.Children.Add(BV);
            BV.Color = Colors.Red;
            BV.CornerRadius = 30;
            BV.SetValue(Grid.RowProperty, _rowIncrement);
            BV.SetValue(Grid.ColumnProperty, j);
        }

        if (_rowIncrement < 9) 
        {
            _rowIncrement++;
        }
        else
        {
            BtnConfirm.IsEnabled = false;
        }
    }
}

