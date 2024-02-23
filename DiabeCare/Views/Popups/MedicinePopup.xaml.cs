using DiabeCare.Models;
using Mopups.Services;

namespace DiabeCare.Views.Popups;

public partial class MedicinePopup
{
	#region Objects
	public EventHandler IsRefresh;
	private List<ConceptProperties> ConceptProperties;
    #endregion

    #region Constructor
    public MedicinePopup(List<ConceptProperties> ConceptProperties)
	{
		InitializeComponent();
		this.ConceptProperties = ConceptProperties;
	}
    #endregion

    #region Method
    protected override void OnAppearing()
    {
        base.OnAppearing();
        lstMedicine.ItemsSource = ConceptProperties;
    }
    #endregion

    #region Events
    private async void Close_Tapped(object sender, TappedEventArgs e)
	{
		await MopupService.Instance.PopAsync();
	}
    #endregion

    private async void ItemSelected_Tapped(object sender, TappedEventArgs e)
    {
        var obj = ((Label)sender).BindingContext as ConceptProperties;
        IsRefresh?.Invoke(obj, EventArgs.Empty);
        await MopupService.Instance.PopAsync();
    }
}