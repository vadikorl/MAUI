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

        private async void OnGoToResultClicked(object sender, EventArgs e)
        {
            double sleepHours = SleepSlider.Value;
            double stressLevel = StressSlider.Value;
            double activityMinutes = ActivitySlider.Value;

            // Formula for score
            double rawScore = (sleepHours * 8) - (stressLevel * 5) + (activityMinutes * 0.5);

            // Clamp between 0 and 100
            if (rawScore < 0) rawScore = 0;
            if (rawScore > 100) rawScore = 100;

            int finalScore = (int)Math.Round(rawScore);

            // Navigate to Result Page
            await Navigation.PushAsync(new ResultPage(finalScore, selectedGender));
        }
    }
}