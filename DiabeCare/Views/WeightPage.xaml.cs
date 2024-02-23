using DiabeCare.Models;
using DiabeCare.Utilities;
using Newtonsoft.Json;

namespace DiabeCare.Views;

public partial class WeightPage : ContentPage
{
    #region Objects
    private double PrevWeight = 0;
    private double NewWeight = 0;
    private UserDetail mUserDetail = new();
    private List<UserDetail> mUserDetails = new();
    #endregion

    #region Constructor
    public WeightPage()
    {
        InitializeComponent();
    }
    #endregion

    #region Methods
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var users = Preferences.Get("Users", null);
        if (users.IsNotNullOrEmptyOrWhiteSpace())
        {
            mUserDetails = JsonConvert.DeserializeObject<List<UserDetail>>(users);
            if (mUserDetails != null && mUserDetails.Count > 0)
            {
                mUserDetail = mUserDetails.Where(x => x.Id == Utility.mUserDetail.Id).FirstOrDefault();
                PrevWeight = Convert.ToDouble(mUserDetail.Weight);
                lblCurWeight.Text = $"Your Current Weight : {mUserDetail.Weight}";
            }
        }
    }
    #endregion

    #region Events
    private async void Back_Tapped(object sender, TappedEventArgs e)
    {
        await Utilities.Utility.BounceImage((Image)sender);
        await Navigation.PopAsync();
    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (txtWeight.Text.IsNotNullOrEmptyOrWhiteSpace())
            {
                await Utilities.Utility.BounceButton((Button)sender);
                mUserDetails.Remove(mUserDetail);
                mUserDetail.Weight = txtWeight.Text;
                Utility.mUserDetail = mUserDetail;
                mUserDetails.Add(mUserDetail);
                string serializeList = JsonConvert.SerializeObject(mUserDetails);
                Preferences.Set("Users", serializeList);
                await App.Current.MainPage.DisplayAlert("Alert!", "Weight updated successfully.", "OK");
                PrevWeight = Convert.ToDouble(mUserDetail.Weight);
                lblCurWeight.Text = $"Your Current Weight : {mUserDetail.Weight}";
                txtWeight.Text = string.Empty;
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "First enter new weight.", "OK");
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"BtnSave_Clicked - {ex.Message}", "OK");
        }
    }

    private async void TxtWeight_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (txtWeight.Text.IsNotNullOrEmptyOrWhiteSpace())
            {
                double diff = PrevWeight - Convert.ToDouble(txtWeight.Text);
                if (diff > 0)
                {
                    lblLostGaine.Text = $"{diff} Kg Lost";
                }
                else if (diff < 0)
                {
                    lblLostGaine.Text = $"{Math.Abs(diff)} Kg Gained";
                }
                else
                {
                    lblLostGaine.Text = $"No weight lost/gained";
                }
            }
            else
            {
                lblLostGaine.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"TxtWeight_TextChanged - {ex.Message}", "OK");
        }
    } 
    #endregion
}