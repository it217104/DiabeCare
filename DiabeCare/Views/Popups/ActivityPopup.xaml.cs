using DiabeCare.Models;
using Mopups.Services;

namespace DiabeCare.Views.Popups;

public partial class ActivityPopup
{
    #region Objects
    public EventHandler IsRefresh;
    private List<Exercise> exercises;
    #endregion

    #region Constructor
    public ActivityPopup(List<Exercise> exercises)
    {
        InitializeComponent();
        this.exercises = exercises;
    }
    #endregion

    #region Methods
    protected override void OnAppearing()
    {
        base.OnAppearing();
        lstActvity.ItemsSource = exercises.ToList();
    }
    #endregion

    #region Events
    private async void Close_Tapped(object sender, TappedEventArgs e)
    {
        await MopupService.Instance.PopAsync();
    }

    private async void ItemSelected_Tapped(object sender, TappedEventArgs e)
    {
        var obj = ((Label)sender).BindingContext as Exercise;
        IsRefresh?.Invoke(obj, EventArgs.Empty);
        await MopupService.Instance.PopAsync();
    } 
    #endregion
}