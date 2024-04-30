# How to customize the height of the datagrid based on row count using the SfDataPager in MAUI DataGrid?
The [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid) supports customizing its height based on the row count using DataPager.

##### XAML
The datagrid, combo box, and sfdatapager are placed inside a grid layout. We have provided the code snippet for reference.
```Xml
<Grid RowDefinitions="Auto,Auto">
    <sfDataGrid:SfDataGrid x:Name="dataGrid" 
                            Grid.Row="0" 
                            HeightRequest="550"
                            ColumnWidthMode="Auto" 
                            MinimumHeightRequest="0"
                            GridLinesVisibility="Both"
                            HeaderGridLinesVisibility="Both"
                            ItemsSource="{Binding Source={x:Reference dataPager}, Path=PagedSource}">
    </sfDataGrid:SfDataGrid>
    <StackLayout Margin="10,0" Grid.Row="1"
                Orientation="Horizontal"
                VerticalOptions="Start">
        <sfComboBox:SfComboBox  x:Name="comboBox">
            <sfComboBox:SfComboBox.ItemsSource>
                <x:Array Type="{x:Type x:Int32}">
                    <x:Int32>5</x:Int32>
                    <x:Int32>10</x:Int32>
                    <x:Int32>15</x:Int32>
                    <x:Int32>20</x:Int32>
                </x:Array>
            </sfComboBox:SfComboBox.ItemsSource>

            <sfComboBox:SfComboBox.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <Label Text="{Binding}" 
                            VerticalTextAlignment="Center" 
                            Padding="10"
                            FontSize="16"/>
                    </ViewCell>
                </DataTemplate>
            </sfComboBox:SfComboBox.ItemTemplate>
        </sfComboBox:SfComboBox>

        <sfDataPager:SfDataPager   x:Name="dataPager" WidthRequest="600"
                                ButtonFontSize="12"
                                ButtonSize="24"
                                HorizontalOptions="EndAndExpand"
                                PageSize="5"
                                Source="{Binding Employees}"
                                VerticalOptions="Start" />
    </StackLayout>
</Grid>
```
##### C#
We can obtain the visualcontainer property from the datagrid by utilizing the `GetVisualContainer()` method.
```C#
Syncfusion.Maui.DataGrid.VisualContainer visualContainer;
public MainPage()
{
    InitializeComponent();
    visualContainer = dataGrid.GetVisualContainer();
}
```
We can determine the total height of the rows by utilizing the `ExtendedHeight` property of the visualcontainer.By comparing the ExtendedHeight and the height of the datagrid, we can set the minimum value as the datagrid height.

```C#
dataGrid.HeightRequest = Math.Min(visualContainer.ExtendedHeight, 550);
```
> **_NOTE:_** This example can only be utilized for a datagrid with a fixed height.


The height of the datagrid can be customized during the initial loading using the Loaded Event.

```C#
private void DataGrid_Loaded(object? sender, EventArgs e)
{
    dataGrid.HeightRequest = Math.Min(visualContainer.ExtendedHeight, 550);
}
```

The height of the datagrid can be customized when the page changes by utilizing the `PageChanged` Event.
```C#
private void DataPager_PageChanged(object? sender, PageChangedEventArgs e)
{
    dataGrid.HeightRequest = Math.Min(visualContainer.ExtendedHeight, 550);
}
```
We can utlize the `SelectionChanged` event of combo box to set the page size for the DataPager.
```C#
private void ComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
{
    if (e.AddedItems != null)
    {
        dataPager.PageSize = (int)e.AddedItems[0];
    }
}
```

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-customize-the-datagrid-height-based-on-row-count-using-the-SfDataPager-in-MAUI-DataGrid)

Take a moment to pursue this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples.
Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid(SfDataGrid).

### Conclusion
I hope you enjoyed learning about how to customize the height of the datagrid based on row count using the SfDataPager in MAUI DataGrid.

You can refer to our [.NET MAUI DataGrid's feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to know about its other groundbreaking feature representations. You can also explore our .NET MAUI DataGrid Documentation to understand how to present and manipulate data.
For current customers, you can check out our .NET MAUI components from the [License and Downloads](https://www.syncfusion.com/account/downloads) page. If you are new to Syncfusion, you can try our 30-day free trial to check out our .NET MAUI DataGrid and other .NET MAUI components.
If you have any queries or require clarifications, please let us know in comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/account/login?ReturnUrl=%2Faccount%2Fconnect%2Fauthorize%2Fcallback%3Fclient_id%3Dc54e52f3eb3cde0c3f20474f1bc179ed%26redirect_uri%3Dhttps%253A%252F%252Fsupport.syncfusion.com%252Fagent%252Flogincallback%26response_type%3Dcode%26scope%3Dopenid%2520profile%2520agent.api%2520integration.api%2520offline_access%2520kb.api%26state%3D8db41f98953a4d9ba40407b150ad4cf2%26code_challenge%3DvwHoT64z2h21eP_A9g7JWtr3vp3iPrvSjfh5hN5C7IE%26code_challenge_method%3DS256%26response_mode%3Dquery) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid). We are always happy to assist you!