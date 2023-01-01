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

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void BtnRestart_Clicked(object sender, EventArgs e)
    {

    }

    private void BtnSave_Clicked(object sender, EventArgs e)
    {

    }
}

