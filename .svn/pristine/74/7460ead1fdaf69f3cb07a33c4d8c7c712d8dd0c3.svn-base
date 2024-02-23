using DiabeCare.Models;
using DiabeCare.Utilities;
using Newtonsoft.Json;

namespace DiabeCare.Views;

public partial class GlucosePage : ContentPage
{
    #region Objects
    private List<GlucoseData> mGlucoseDatas = new();
    #endregion

    #region Constructor
    public GlucosePage()
    {
        InitializeComponent();
    }
    #endregion

    #region Methods
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var glucoseList = Preferences.Get("GlucoseList", string.Empty);
        if (glucoseList.IsNotNullOrEmptyOrWhiteSpace())
        {
            mGlucoseDatas = JsonConvert.DeserializeObject<List<GlucoseData>>(glucoseList);
        }
    }
    #endregion

    #region Events
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
            if (txtGlucoseLevel.Text.IsNullOrEmptyOrWhiteSpace())
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "Enter your glucose level first.", "OK");
            }
            else if (pkMeasure.SelectedIndex == -1)
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "Select measurement type.", "OK");
            }
            else
            {
                GlucoseData glucoseData = new()
                {
                    DiabetesType = Utility.mUserDetail.DiabetesType,
                    GlucoseLevel = txtGlucoseLevel.Text,
                    GlucoseDate = DateTime.Now.ToString("dd/MM/yyyy")
                };
                mGlucoseDatas.Add(glucoseData);
                string serializeList = JsonConvert.SerializeObject(mGlucoseDatas);
                Preferences.Set("GlucoseList", serializeList);
                await App.Current.MainPage.DisplayAlert("Success :)", "Glucose saved successfully.", "OK");
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"BtnSave_Clicked - {ex.Message}", "OK");
        }
    }

    private async void PkMeasure_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            double Glucose = 0;
            if (txtGlucoseLevel.Text.IsNullOrEmptyOrWhiteSpace())
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "Enter your glucose level first.", "OK");
                pkMeasure.SelectedIndex = -1;
                return;
            }
            else
            {
                Glucose = Convert.ToDouble(txtGlucoseLevel.Text);
            }

            if (pkMeasure.SelectedIndex == 0)
            {
                lblMeasureType.Text = pkMeasure.SelectedItem.ToString();
                if (Utility.mUserDetail.DiabetesType == 0 & Glucose > 100)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are high. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 0 & Glucose < 60)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are low. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 1 & Glucose > 126)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are high. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 1 & Glucose < 70)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are low. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 2 & Glucose > 126)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are high. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 2 & Glucose < 70)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are low. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 3 & Glucose > 125)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are high. Please contact your personal doctor.", "OK");
                }
            }
            else if (pkMeasure.SelectedIndex == 1)
            {
                lblMeasureType.Text = pkMeasure.SelectedItem.ToString();
                if (Utility.mUserDetail.DiabetesType == 0 & Glucose > 140)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are high. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 1 & Glucose > 162)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are high. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 1 & Glucose < 90)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are low. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 2 & Glucose > 154)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are high. Please contact your personal doctor.", "OK");
                }
                else if (Utility.mUserDetail.DiabetesType == 3 & Glucose > 200)
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Glucose levels are high. Please contact your personal doctor.", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"PkMeasure_SelectedIndexChanged - {ex.Message}", "OK");
        }
    }
    #endregion
}