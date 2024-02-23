using DiabeCare.Models;
using Plugin.LocalNotification;
using System.Globalization;
using System;

namespace DiabeCare.Views;

public partial class NotificationPage : ContentPage
{
    #region Objects
    private ConceptProperties mConceptProperties;
    #endregion

    public NotificationPage(ConceptProperties mConceptProperties)
	{
		InitializeComponent();
        this.mConceptProperties = mConceptProperties;
	}

    #region Methods
    protected override void OnAppearing()
    {
        base.OnAppearing();

        for (int i = 01; i <= 24; i++)
        {
            var hour = $"{i}".PadLeft(2, '0');
            pkhour.Items.Add($"{hour}");
        }

        for (int i = 01; i <= 60; i++)
        {
            var Minute = $"{i}".PadLeft(2, '0');
            pkMinute.Items.Add($"{Minute}");
        }

        var month = DateTime.Now.Month;
        var year = DateTime.Now.Year;
        var day = DateTime.DaysInMonth(year,month);
        for (int i = 1; i <= day; i++)
        {
            var days = $"{i}".PadLeft(2, '0');
            pkDay.Items.Add($"{days}");
        }
        pkMonth.SelectedItem = new DateTime(year, month, 1).ToString("MMMM");
        pkDay.SelectedItem = day;
        pkhour.SelectedItem = DateTime.Now.ToString("HH");
        pkMinute.SelectedItem = DateTime.Now.ToString("mm");
    }
    #endregion

    private async void Back_Tapped(object sender, TappedEventArgs e)
    {
        await Utilities.Utility.BounceImage((Image)sender);
        await Navigation.PopAsync();
    }

    private void Down_Tapped(object sender, TappedEventArgs e)
    {

    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Utilities.Utility.BounceButton((Button)sender);
            var month = DateTime.ParseExact(txtMonth.Text, "MMMM", CultureInfo.CurrentCulture).Month.ToString();
            if (month.Length.ToString() == "1")
            {
                month = $"0{month}";
            }
            
            
            var day = txtDay.Text.Length.ToString();
           if (day=="1")
            {
               day = $"0{txtDay.Text}";
            }
            else
            {
                day = txtDay.Text;
            }
            var date = $"{day}/{month}/{DateTime.Now.Year}";
            var hour = txtHour.Text.Length.ToString();
            if (hour == "1")
            {
                hour = $"0{txtHour.Text}";
            }
            else
            {
                hour = txtHour.Text;
            }
            var minute = txtMinute.Text.Length.ToString();
            if (minute == "1")
            {
                minute = $"0{txtMinute.Text}";
            }
            else
            {
                minute = txtMinute.Text;
            }
            var time = $"{hour}:{minute}";
            var datetime = $"{date} {time}";
            var NotifyDateTime = DateTime.ParseExact(datetime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            NotificationRepeat notificationRepeat = new();
            var interval = 0;
            if (pkPeriod.SelectedIndex == 0)
            {
                notificationRepeat = NotificationRepeat.Daily;
                interval = 1;
            }
            else
            {
                notificationRepeat = NotificationRepeat.Weekly;
                interval = 7;
            }

            var request = new NotificationRequest
            {
                NotificationId = 1000,
                Title = "Medicine Reminder",
                Subtitle = $"{mConceptProperties.Synonym}",
                Description = $"{mConceptProperties.Name}",
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = NotifyDateTime,
                    RepeatType = notificationRepeat,
                    NotifyRepeatInterval = TimeSpan.FromDays(interval)
                }
            };
            _ = LocalNotificationCenter.Current.Show(request);
            await App.Current.MainPage.DisplayAlert("Success :)", "Medicine alert added.", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"BtnSave_Clicked - {ex.Message}", "OK");
        }
    }

    private void PkDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDay.Text = pkDay.SelectedItem.ToString();
    }

    private void PkMinute_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMinute.Text = pkMinute.SelectedItem.ToString();
    }

    private void Pkhour_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtHour.Text = pkhour.SelectedItem.ToString();
    }

    private void PkMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMonth.Text = pkMonth.SelectedItem.ToString();
    }
}