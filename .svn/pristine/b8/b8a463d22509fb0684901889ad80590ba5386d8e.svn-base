using DiabeCare.Models;
using DiabeCare.Utilities;
using Newtonsoft.Json;

namespace DiabeCare.Views;

public partial class Login : ContentPage
{
    #region Objects
    private List<UserDetail> mUserDetails = new();
    #endregion

    #region Constructor
    public Login()
    {
        InitializeComponent();
    }
    #endregion

    #region Methods
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var username = Preferences.Get("username", string.Empty);
        var password = Preferences.Get("password", string.Empty);
        var isremember = Preferences.Get("isremember", false);
        if (isremember)
        {
            txtUsername.Text = username;
            txtPassword.Text = password;
            cbRemember.IsChecked = true;
        }
        else
        {
            txtUsername.Text = 
            txtPassword.Text = string.Empty;
            cbRemember.IsChecked = false;
        }
        var users = Preferences.Get("Users", null);
        if (users.IsNotNullOrEmptyOrWhiteSpace())
        {
            mUserDetails = JsonConvert.DeserializeObject<List<UserDetail>>(users);
        }
    }
    #endregion

    #region Events
    private async void Signup_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            await Utilities.Utility.BounceHorizontalSL((HorizontalStackLayout)sender);
            await Navigation.PushAsync(new Signup());
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"Signup - {ex.Message}", "OK");
        }
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Utilities.Utility.BounceButton((Button)sender);
            if (txtUsername.Text.IsNullOrEmptyOrWhiteSpace())
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "Username is required.", "OK");
            }
            else if (txtPassword.Text.IsNullOrEmptyOrWhiteSpace())
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "Password is required.", "OK");
            }
            else
            {
                var curUser = mUserDetails.Where(x => x.Username == txtUsername.Text &&
                x.Password == txtPassword.Text).FirstOrDefault();
                if (curUser != null)
                {
                    if (cbRemember.IsChecked)
                    {
                        Preferences.Set("username", txtUsername.Text);
                        Preferences.Set("password", txtPassword.Text);
                        Preferences.Set("isremember", true);
                    }
                    else
                    {
                        Preferences.Remove("username");
                        Preferences.Remove("password");
                        Preferences.Remove("isremember");
                    }
                    Utility.mUserDetail = curUser;
                    await App.Current.MainPage.DisplayAlert("Success :)", "User login successfully.", "OK");
                    App.Current.MainPage = new NavigationPage(new Home());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Invalid Username or Password.", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"BtnLogin - {ex.Message}", "OK");
        }
    }
    #endregion
}