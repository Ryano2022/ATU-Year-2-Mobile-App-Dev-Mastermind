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
    int[] _code, _guessedCode;
    int _rowIncrement, _colourNum;
    Random _random;
    List<BoxView> _boxviews, _BlackWhitePegs;

    public MainPage()
	{
		InitializeComponent();
        _random = new Random();
        _code = new int[4];
        _guessedCode = new int[4];
        _rowIncrement = 0;
        _colourNum = -1;
        GenerateHiddenCode();
        NewRow();
    }

    // Complete the save and restart button functionalities.
    private async void BtnRestart_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Restart", "Are you sure you want to restart your game?", "Yes", "No");
        if(answer == true)
        {
            foreach (BoxView BV in _boxviews)
            {
                BV.IsVisible = false;
            }

            foreach (BoxView BV in _BlackWhitePegs)
            {
                BV.IsVisible = false;
            }

            _boxviews.Clear();
            _BlackWhitePegs.Clear();

            _rowIncrement = 0;
            _colourNum = -1;

            BtnConfirm.IsVisible = true;
            LblCode.IsVisible = false;
            SLCode.IsVisible = false;

            GenerateHiddenCode();
            NewRow();
        }
    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
        /* I tried looking at your example code but I just couldn't figure this out.
         * I didnt get a class of you going through the example you put online since my class times were 
         * taken up by an exam for the last 2 classes I had. (First being Procedural Programming and the
         * second being the Mobile App Dev exam).
         * I hope this doesn't drop my grade too much.
        */

        bool answer = await DisplayAlert("Game File", "Would you like to save your game or load a previous save?", "Save", "Load");
        if (answer == true)
        {
            await DisplayAlert("Save", "Not Implemented", "OK");
        }
        else
        {
            await DisplayAlert("Load", "Not Implemented", "OK");
        }
    }

    // Confirm button at bottom to confirm their guess.
    private void BtnConfirm_Clicked(object sender, EventArgs e)
    {
        _guessedCode[0] = -1;
        _guessedCode[1] = -1;
        _guessedCode[2] = -1;
        _guessedCode[3] = -1;
        CodeGuess(_rowIncrement);
        BlackOrWhite();
        
        /* Below was used for testing.
        * 
        * Test0.Text = _guessedCode[0].ToString();
        * Test1.Text = _guessedCode[1].ToString();
        * Test2.Text = _guessedCode[2].ToString();
        * Test3.Text = _guessedCode[3].ToString();
        */

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
    private async void NewRow()
    {
        if (_boxviews == null) _boxviews = new List<BoxView>();

        for (int i = 0; i < _NUM_OF_COLS; i++) 
        {
            BoxView BV = new BoxView();
            BV.CornerRadius = 30;
            BV.SetValue(Grid.RowProperty, _rowIncrement);
            BV.SetValue(Grid.ColumnProperty, i);
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) => 
            {
                BV.Color = ColourCycler();
            };
            BV.GestureRecognizers.Add(tap);
            GridGame.Children.Add(BV);
            _boxviews.Add(BV);
        }
        
        if (_rowIncrement < (_NUM_OF_ROWS)) 
        {
            _rowIncrement++;
        }
        else
        {
            BtnConfirm.IsVisible = false;
            LblCode.IsVisible = true;
            SLCode.IsVisible = true;
            bool answer = await DisplayAlert("Loss", "You lost! :( Would you like to restart?", "Yes", "No");
            if (answer == true)
            {
                BtnRestart_Clicked(new object(), new EventArgs());
            }
        }

        
    }

    // Allow user to make a guess by tapping the circles until they have the colour they want.
    private Color ColourCycler()
    {
        _colourNum++;

        if (_colourNum > _NUM_OF_COLOURS)
        {
            _colourNum = -1;
        }

        if (_colourNum == 0)
        {
            return Colors.Red;
        }
        else if (_colourNum == 1)
        {
            return Colors.Yellow;
        }
        else if(_colourNum == 2)
        {
            return Colors.Green;
        }
        else if(_colourNum == 3)
        {
            return Colors.Blue;
        }
        else if(_colourNum == 4)
        {
            return Colors.Black;
        }
        else 
        {
            return Colors.White;
        }
    }

    // Guess the code. Quite long but unfortunately it's the only way I can think of doing it right now.
    private void CodeGuess(int rowNum)
    {
        int lowerNum = 0, upperNum = 0;

        // Setting the lower and upper numbers to select a certain part of the list.
        if (rowNum == 1)
        {
            lowerNum = 0;
            upperNum = 3;
        }
        else if (rowNum == 2)
        {
            lowerNum = 4;
            upperNum = 7;
        }
        else if (rowNum == 3)
        {
            lowerNum = 8;
            upperNum = 11;
        }
        else if (rowNum == 4)
        {
            lowerNum = 12;
            upperNum = 15;
        }
        else if (rowNum == 5)
        {
            lowerNum = 16;
            upperNum = 19;
        }
        else if (rowNum == 6)
        {
            lowerNum = 20;
            upperNum = 23;
        }
        else if (rowNum == 7)
        {
            lowerNum = 24;
            upperNum = 27;
        }
        else if (rowNum == 8)
        {
            lowerNum = 28;
            upperNum = 31;
        }
        else if (rowNum == 9)
        {
            lowerNum = 32;
            upperNum = 35;
        }    
        else if (rowNum == 10)
        {
            lowerNum = 36;
            upperNum = 39;
        }

        for(int i = lowerNum; i <= upperNum; i++)
        {
            if (_boxviews[i].Color == Colors.Red)
            {
                SetCodeNums(0);
            }
            else if (_boxviews[i].Color == Colors.Yellow)
            {
                SetCodeNums(1);
            }
            else if (_boxviews[i].Color == Colors.Green)
            {
                SetCodeNums(2);
            }
            else if (_boxviews[i].Color == Colors.Blue)
            {
                SetCodeNums(3);
            }
            else if (_boxviews[i].Color == Colors.Black)
            {
                SetCodeNums(4);
            }
            else if (_boxviews[i].Color == Colors.White)
            {
                SetCodeNums(5);
            }
        }
    }

    private void SetCodeNums(int num)
    {
        if (_guessedCode[0] == -1) _guessedCode[0] = num;
        else if (_guessedCode[1] == -1) _guessedCode[1] = num;
        else if (_guessedCode[2] == -1) _guessedCode[2] = num;
        else if (_guessedCode[3] == -1) _guessedCode[3] = num;
    }

    /* Compare the guess to the hidden code and place the black or white pegs.
    *  Black pegs = Correct colour in correct position.
    *  White pegs = Correct colour in wrong position.
    */
    private async void BlackOrWhite()
    {
        if (_BlackWhitePegs == null) _BlackWhitePegs = new List<BoxView>();
        int blackPegs = 0, whitePegs = 0;

        Grid BlackOrWhiteGrid = new Grid()
        {
            RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition()
            },
            ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
            }
        };

        BlackOrWhiteGrid.SetValue(Grid.RowProperty, _rowIncrement - 1);
        BlackOrWhiteGrid.SetValue(Grid.ColumnProperty, 4);
        BlackOrWhiteGrid.SetColumnSpan(BlackOrWhiteGrid, 2);
        GridGame.Children.Add(BlackOrWhiteGrid);

        if (_guessedCode.SequenceEqual(_code))
        {
            BtnConfirm.IsVisible = false;
            LblCode.IsVisible = true;
            SLCode.IsVisible = true;
            await DisplayAlert("Victory", "You've cracked the code! Congratulations", "OK");
        }
        else
        {
            if (_guessedCode[0] == _code[0]) blackPegs++;
            if (_guessedCode[1] == _code[1]) blackPegs++;
            if (_guessedCode[2] == _code[2]) blackPegs++;
            if (_guessedCode[3] == _code[3]) blackPegs++;

            if (_guessedCode[0] == _code[1] || _guessedCode[0] == _code[2] || _guessedCode[0] == _code[3]) whitePegs++;
            if (_guessedCode[1] == _code[0] || _guessedCode[1] == _code[2] || _guessedCode[1] == _code[3]) whitePegs++;
            if (_guessedCode[2] == _code[0] || _guessedCode[2] == _code[1] || _guessedCode[2] == _code[3]) whitePegs++;
            if (_guessedCode[3] == _code[0] || _guessedCode[3] == _code[1] || _guessedCode[3] == _code[2]) whitePegs++;

            if ((_guessedCode[0] == _code[0]) && (_guessedCode[0] == _code[1] || _guessedCode[0] == _code[2] || _guessedCode[0] == _code[3]))
            {
                if (_guessedCode[0] == _code[1]) whitePegs--;
                if (_guessedCode[0] == _code[2]) whitePegs--;
                if (_guessedCode[0] == _code[3]) whitePegs--;
            }
            if ((_guessedCode[1] == _code[1]) && (_guessedCode[1] == _code[0] || _guessedCode[1] == _code[2] || _guessedCode[1] == _code[3]))
            {
                if (_guessedCode[1] == _code[0]) whitePegs--;
                if (_guessedCode[1] == _code[2]) whitePegs--;
                if (_guessedCode[1] == _code[3]) whitePegs-- ;
            }
            if((_guessedCode[2] == _code[2]) && (_guessedCode[2] == _code[0] || _guessedCode[2] == _code[1] || _guessedCode[2] == _code[3]))
            {
                if (_guessedCode[2] == _code[0]) whitePegs--;
                if (_guessedCode[2] == _code[1]) whitePegs--;
                if (_guessedCode[2] == _code[3]) whitePegs--;
            }
            if ((_guessedCode[3] == _code[3]) && (_guessedCode[3] == _code[0] || _guessedCode[3] == _code[1] || _guessedCode[3] == _code[2]))
            {
                if (_guessedCode[3] == _code[0]) whitePegs--;
                if (_guessedCode[3] == _code[1]) whitePegs--;
                if (_guessedCode[3] == _code[2]) whitePegs--;
            }
            

            /* Below was used for testing.
            * 
            * Test4.Text = _code[0].ToString();
            * Test5.Text = _code[1].ToString();
            * Test6.Text = _code[2].ToString();
            * Test7.Text = _code[3].ToString();
            * Test8.Text = blackPegs.ToString();
            * Test9.Text = whitePegs.ToString();
            */

            for (int i = 0; i < 4; i++)
            {
                BoxView BV = new BoxView();
                if(blackPegs > 0)
                {
                    BV.Color = Colors.Black;
                    blackPegs--;
                }
                else if(blackPegs <= 0 && whitePegs > 0)
                {
                    BV.Color = Colors.White;
                    whitePegs--;
                }
                BV.CornerRadius = 30;
                BV.WidthRequest = 22;

                if (i == 0 || i == 1)
                {
                    BV.SetValue(Grid.RowProperty, 0);
                }
                else if (i == 2 || i == 3)
                {
                    BV.SetValue(Grid.RowProperty, 1);
                }

                if (i == 0 || i == 2)
                {
                    BV.SetValue(Grid.ColumnProperty, 0);
                }
                else if (i == 1 || i == 3)
                {
                    BV.SetValue(Grid.ColumnProperty, 1);
                }

                BlackOrWhiteGrid.Children.Add(BV);
                _BlackWhitePegs.Add(BV);
            }
        }
    }
}

