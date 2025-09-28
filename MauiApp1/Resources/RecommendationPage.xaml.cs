namespace MauiApp1;

public partial class RecommendationPage : ContentPage
{
    public RecommendationPage(int score, string gender)
    {
        InitializeComponent();

        string recommendation;

        if (score >= 80)
            recommendation = gender == "Male"
                ? "Maintain routine; include resistance training 2–3×/week; ensure protein intake."
                : "Keep strong habits; add yoga/pilates; prioritize calcium + vitamin D.";
        else if (score >= 60)
            recommendation = gender == "Male"
                ? "Improve recovery with earlier bedtime; add light cardio; stay hydrated."
                : "Boost energy with breakfast; walk 15 min; focus on iron-rich foods.";
        else if (score >= 40)
            recommendation = gender == "Male"
                ? "Aim for +1 hr sleep; reduce caffeine; schedule light mobility."
                : "Increase sleep consistency; reduce screen time; try meditation.";
        else
            recommendation = gender == "Male"
                ? "Rest today; avoid hard workouts; hydrate; take gentle walk."
                : "Prioritize rest; nap if possible; only gentle yoga/stretching.";

        RecommendationLabel.Text = recommendation;
    }
}