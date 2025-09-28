namespace MauiApp1;

public partial class ResultPage : ContentPage
{
    private string selectedGender;
    private int finalScore;

    public ResultPage(int score, string gender)
    {
        InitializeComponent();
        finalScore = score;
        selectedGender = gender;

        ScoreLabel.Text = $"Score: {score}";

        if (score >= 80) StatusLabel.Text = "Status: Excellent";
        else if (score >= 60) StatusLabel.Text = "Status: Good";
        else if (score >= 40) StatusLabel.Text = "Status: Fair";
        else StatusLabel.Text = "Status: Poor";
    }

    private async void OnSeeRecommendationsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecommendationPage(finalScore, selectedGender));
    }
}