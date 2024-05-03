using Syncfusion.Maui.DataGrid.DataPager;
using Syncfusion.Maui.Inputs;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        Syncfusion.Maui.DataGrid.VisualContainer visualContainer;
        public MainPage()
        {
            InitializeComponent();
            visualContainer = dataGrid.GetVisualContainer();
        }

        private void DataGrid_Loaded(object? sender, EventArgs e)
        {
            dataGrid.HeightRequest = Math.Min(visualContainer.ExtendedHeight, 550);
        }

        private void DataPager_PageChanged(object? sender, PageChangedEventArgs e)
        {
            dataGrid.HeightRequest = Math.Min(visualContainer.ExtendedHeight,550);            
        }

        private void ComboBox_SelectionChanged(object? sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                dataPager.PageSize = (int)e.AddedItems[0];
            }
        }
    }

}
