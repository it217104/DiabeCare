using DiabeCare.Models;
using Mopups.Services;
//using Xamarin.Google.Crypto.Tink.Proto;

namespace DiabeCare.Views.Popups;

public partial class FoodPopup
{
    #region Objects
    public event EventHandler IsRefresh;
    private bool IsCommon = false;
    private List<InstantCommon> mCommon;
    private List<Branded> mBranded;
    #endregion

    #region Constructor
    public FoodPopup(List<InstantCommon> mCommon)
    {
        InitializeComponent();
        this.mCommon = mCommon;
        IsCommon = true;
    }

    public FoodPopup(List<Branded> mBranded)
    {
        InitializeComponent();
        this.mBranded = mBranded;
        IsCommon = false;
    }
    #endregion

    #region Methods
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (IsCommon)
        {
            lstFood.ItemsSource = mCommon;
        }
        else
        {
            lstFood.ItemsSource = mBranded;
        }
    }
    #endregion

    #region Events
    private async void Close_Tapped(object sender, TappedEventArgs e)
    {
        await MopupService.Instance.PopAsync();
    }

    private async void ItemSelected_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            if (IsCommon)
            {
                var obj = ((Label)sender).BindingContext as InstantCommon;
                IsRefresh?.Invoke(obj, EventArgs.Empty);
                await MopupService.Instance.PopAsync();
            }
            else
            {
                var obj = ((Label)sender).BindingContext as Branded;
                IsRefresh?.Invoke(obj, EventArgs.Empty);
                await MopupService.Instance.PopAsync();
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Alert!", $"ItemSelected_Tapped - {ex.Message}", "OK");
        }
    } 
    #endregion
}