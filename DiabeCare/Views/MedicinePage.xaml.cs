using DiabeCare.APIs;
using DiabeCare.Models;
using DiabeCare.Utilities;
using Mopups.Services;
using Newtonsoft.Json;
using Plugin.LocalNotification;

namespace DiabeCare.Views;

public partial class MedicinePage : ContentPage
{
    #region Objects
    private DrugGroup DrugGroup;
    private ConceptProperties mConceptProperties;
    private List<ConceptProperties> ConceptProperties = new();
    private List<MedicineData> mMedicineDatas = new();
    #endregion

    #region Constructor
    public MedicinePage()
    {
        InitializeComponent();
    }
    #endregion

    #region Methods
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var medicineList = Preferences.Get("MedicineList", string.Empty);
        if (medicineList.IsNotNullOrEmptyOrWhiteSpace())
        {
            mMedicineDatas = JsonConvert.DeserializeObject<List<MedicineData>>(medicineList);
        }
    }
    #endregion


    #region Events
    private async void Back_Tapped(object sender, TappedEventArgs e)
    {
        await Utilities.Utility.BounceImage((Image)sender);
        await Navigation.PopAsync();
    }

    private async void Search_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            if (txtSearchMedicine.Text.IsNotNullOrEmptyOrWhiteSpace())
            {
                aiLoader.IsRunning = aiLoader.IsVisible = true;
                await Task.Delay(500);
                DrugGroup = await new MedicineAPI().GetMedicine(txtSearchMedicine.Text);
                if (DrugGroup != null && DrugGroup.ConceptGroup.Count > 0)
                {
                    foreach (var group in DrugGroup.ConceptGroup)
                    {
                        if (group != null && group.ConceptProperties != null && group.ConceptProperties.Count > 0)
                        {
                            foreach (var cp in group.ConceptProperties)
                            {
                                ConceptProperties.Add(cp);
                            }
                        }
                    }
                }

                if (ConceptProperties.Count > 0)
                {
                    var mp = new Popups.MedicinePopup(ConceptProperties);
                    mp.IsRefresh += ((sender, EventArgs) =>
                    {
                        if (sender is ConceptProperties properties &&
                        properties != null)
                        {
                            mConceptProperties = properties;
                            txtMedicine.Text = properties.Synonym;
                        }
                    });
                    await MopupService.Instance.PushAsync(mp);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "Enter medicine first.", "OK");
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", ex.Message, "OK");
        }
        finally
        {
            aiLoader.IsRunning = aiLoader.IsVisible = false;
            txtSearchMedicine.Text = string.Empty;
        }
    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Utilities.Utility.BounceButton((Button)sender);
            if (txtMedicine.Text.IsNullOrEmptyOrWhiteSpace())
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "Enter medicine first.", "OK");
            }
            //else if (txtFrquency.Text.IsNullOrEmptyOrWhiteSpace())
            //{
            //    await App.Current.MainPage.DisplayAlert("Alert!", "Enter frequency.", "OK");
            //}
            //else if (pkPeriod.SelectedIndex == -1)
            //{
            //    await App.Current.MainPage.DisplayAlert("Alert!", "Select period type.", "OK");
            //}
            else
            {
                MedicineData medicineData = new()
                {
                    MedicineName = txtMedicine.Text
                };
                mMedicineDatas.Add(medicineData);
                string serializeList = JsonConvert.SerializeObject(mMedicineDatas);
                Preferences.Set("MedicineList", serializeList);
                await App.Current.MainPage.DisplayAlert("Success :)", "Medicine saved successfully.", "OK");
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"BtnSave_Clicked - {ex.Message}", "OK");
        }
    }

    private async void Notification_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            if (txtMedicine.Text.IsNullOrEmptyOrWhiteSpace())
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "Enter medicine first.", "OK");
            }
            //else if (txtFrquency.Text.IsNullOrEmptyOrWhiteSpace())
            //{
            //    await App.Current.MainPage.DisplayAlert("Alert!", "Enter frequency.", "OK");
            //}
            //else if (pkPeriod.SelectedIndex == -1)
            //{
            //    await App.Current.MainPage.DisplayAlert("Alert!", "Select period type.", "OK");
            //}
            else
            {
                await Navigation.PushAsync(new NotificationPage(mConceptProperties));
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"Notification_Tapped - {ex.Message}", "OK");
        }
    }

    private void Down_Tapped(object sender, TappedEventArgs e)
    {
        //pkPeriod.Focus();
    } 
    #endregion
}