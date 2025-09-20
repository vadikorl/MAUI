using System;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private string selectedGender = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnMaleTapped(object sender, EventArgs e)
        {
            selectedGender = "Male";
            MaleBorder.Stroke = Colors.Blue;
            FemaleBorder.Stroke = Colors.Gray;
        }

        private void OnFemaleTapped(object sender, EventArgs e)
        {
            selectedGender = "Female";
            FemaleBorder.Stroke = Colors.Pink;
            MaleBorder.Stroke = Colors.Gray;
        }

        private void OnSliderChanged(object sender, ValueChangedEventArgs e)
        {
            SleepValueLabel.Text = $"{SleepSlider.Value:F1} h";
            StressValueLabel.Text = $"{StressSlider.Value:F0}";
            ActivityValueLabel.Text = $"{ActivitySlider.Value:F0} min";
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            double sleepHours = SleepSlider.Value;
            double stressLevel = StressSlider.Value;
            double activityMinutes = ActivitySlider.Value;

            // Formula
            double rawScore = (sleepHours * 8) - (stressLevel * 5) + (activityMinutes * 0.5);

            // Clamp between 0 and 100
            if (rawScore < 0) rawScore = 0;
            if (rawScore > 100) rawScore = 100;

            int finalScore = (int)Math.Round(rawScore);

            ScoreLabel.Text = $"Score: {finalScore}";

            string status;
            string recommendation = "";

            if (finalScore >= 80)
            {
                status = "Excellent";
                recommendation = selectedGender == "Male"
                    ? "Maintain routine; include resistance training 2–3×/week; ensure protein intake."
                    : "Keep strong habits; add yoga/pilates; prioritize calcium + vitamin D.";
            }
            else if (finalScore >= 60)
            {
                status = "Good";
                recommendation = selectedGender == "Male"
                    ? "Improve recovery with earlier bedtime; add light cardio; stay hydrated."
                    : "Boost energy with breakfast; walk 15 min; focus on iron-rich foods.";
            }
            else if (finalScore >= 40)
            {
                status = "Fair";
                recommendation = selectedGender == "Male"
                    ? "Aim for +1 hr sleep; reduce caffeine; schedule light mobility."
                    : "Increase sleep consistency; reduce screen time; try meditation.";
            }
            else
            {
                status = "Poor";
                recommendation = selectedGender == "Male"
                    ? "Rest today; avoid hard workouts; hydrate; take gentle walk."
                    : "Prioritize rest; nap if possible; only gentle yoga/stretching.";
            }

            StatusLabel.Text = $"Status: {status}";
            RecommendationLabel.Text = recommendation;
        }
    }
}