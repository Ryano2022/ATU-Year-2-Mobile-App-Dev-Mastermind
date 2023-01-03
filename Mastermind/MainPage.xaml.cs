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
    const int _NUM_OF_ROWS = 10;
    const int _NUM_OF_COLS = 4;
    const int _NUM_OF_COLOURS = 5;
    int[] _code;
    int _rowIncrement, _colourNum;
    Random _random;
    List<BoxView> _boxviews;

    public MainPage()
	{
		InitializeComponent();
        _random = new Random();
        _code = new int[4];
        _rowIncrement = 0;
        _colourNum = 1;
        GenerateHiddenCode();
        NewRow();
    }

    // Complete the save and restart button functionalities.
    private void BtnRestart_Clicked(object sender, EventArgs e)
    {
        foreach (BoxView BV in _boxviews) 
        {
            BV.IsVisible = false;
        }

        _boxviews.Clear(); 

        _rowIncrement = 0;
        _colourNum = 1;

        BtnConfirm.IsVisible = true;
        LblCode.IsVisible = false;
        SLCode.IsVisible = false;

        GenerateHiddenCode();
        NewRow();
    }

    private void BtnSave_Clicked(object sender, EventArgs e)
    {
    }

    // Confirm button at bottom to confirm their guess.
    private void BtnConfirm_Clicked(object sender, EventArgs e)
    {
        NewRow();
        _colourNum = 1;
    }

    // Generate a 4 colour code. Colours can repeat.
    private void GenerateHiddenCode()
    {
        for (int i = 0; i < _code.Length; i++)
        {
            int randomNum = _random.Next(0, _NUM_OF_COLOURS);
            
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

    // 6 Different colours. (I'll pick Red, Yellow, Green, Blue, White and Black).
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

    // Move to the next row on the grid every time and add some boxviews.
    private void NewRow()
    {
        if (_boxviews == null) _boxviews = new List<BoxView>();

        for (int i = 0; i < _NUM_OF_COLS; i++) 
        {
            BoxView BV = new BoxView();
            BV.Color = Colors.Red;
            BV.CornerRadius = 30;
            BV.SetValue(Grid.RowProperty, _rowIncrement);
            BV.SetValue(Grid.ColumnProperty, i);
            
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => 
            {
                ColourCycler(s);
            };

            BV.GestureRecognizers.Add(tapGestureRecognizer);
            _boxviews.Add(BV);
            GridGame.Children.Add(BV);
        }
        

        if (_rowIncrement < (_NUM_OF_ROWS - 1)) 
        {
            _rowIncrement++;
        }
        else
        {
            BtnConfirm.IsVisible = false;
            LblCode.IsVisible = true;
            SLCode.IsVisible = true;
        }
    }

    // Allow user to make a guess by tapping the circles until they have the colour they want.
    private void ColourCycler(object sender)
    {
        BoxView BV = (BoxView)sender;
        
        if(_colourNum == 0)
        {
            BV.Color = Colors.Red;
        }
        else if (_colourNum == 1)
        {
            BV.Color = Colors.Yellow;
        }
        else if(_colourNum == 2)
        {
            BV.Color = Colors.Green;
        }
        else if(_colourNum == 3)
        {
            BV.Color = Colors.Blue;
        }
        else if(_colourNum == 4)
        {
            BV.Color = Colors.Black;
        }
        else
        {
            BV.Color = Colors.White;
        }

        _colourNum++; 

        if(_colourNum > _NUM_OF_COLOURS)
        {
            _colourNum = 0;
        }
    }
}

