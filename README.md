# LayoutChildAddedRepro
A .NET MAUI RC1 reproduction sample for `Layout.ChildAdded`.
 
## Bug Description
The  `Layout.ChildAdded` event does not fire when an `IView` is added to a `Layout` like a `Grid` or a `StackLayout`.

```cs
protected override void OnAppearing()
{
  base.OnAppearing();

  var stackLayout = new StackLayout();
  stackLayout.ChildAdded += HandleChildAdded
    
  stackLayout.Children.Add(new BoxView()); // `ChildAdded` does not fire
}

// This Event Handler Does Not Execute because `ChildAdded` does not fire
async void HandleChildAdded(object sender, ElementEventArgs e) =>
 await DisplayAlert("Child Added", $"Added a {e.Element.GetType().FullName}", "OK");
```

## Reproduction Steps
0. [Install .NET MAUI](https://docs.microsoft.com/dotnet/maui/get-started/installation?WT.mc_id=mobile-0000-bramin)
1. Download/Clone this repo
2. In `MainPage.xaml`, confirm [`ChildAdded` is subscribed to `HandleChildAdded`](https://github.com/brminnick/LayoutChildAddedRepro/blob/f8447fb97dd1926395ff30821cd76948906f31c0/MainPage.xaml#L8)
3. In `MainPage.xaml.cs`, confirm [`OnAppearing` triggers `await DisplayAlert("OnAppearing Fired", "Click OK to add a Green Box View", "OK");`](https://github.com/brminnick/LayoutChildAddedRepro/blob/5ab4b08f25d7b4f920f751c78ec821e177dabb2c/MainPage.xaml.cs#L22)
4. In `MainPage.OnAppearing`, confirm a [green `BoxView` is added to the `Grid](https://github.com/brminnick/LayoutChildAddedRepro/blob/5ab4b08f25d7b4f920f751c78ec821e177dabb2c/MainPage.xaml.cs#L28)
5. Confirm [`HandleChildAdded` triggers `DisplayAlert`](https://github.com/brminnick/LayoutChildAddedRepro/blob/5ab4b08f25d7b4f920f751c78ec821e177dabb2c/MainPage.xaml.cs#L33)
6. In the terminal, navigate to the downloaded `LayoutChildAddedRepro` repo
7. In the terminal, run `LayoutChildAddedRepro.sln` by entering the following command for your specific simulator/device
   - iOS: `dotnet build -t:run -f:net6.0-ios`
   - Android: `dotnet build -t:run -f:net6.0-android`
   - MacCatalyst: `dotnet build -t:run -f:net6.0-maccatalyst`
9. In the simulator/device, confirm the `DisplayAlert` appears
<img width="250" alt="image" src="https://user-images.githubusercontent.com/13558917/140859648-4e4c3ce8-b50a-4d8e-b63b-d51b9c8802c8.png">

10. In the simulator, click **OK**
11. In the simulator, confirm a Green Box is added to `MainPage`
<img width="250" alt="image" src="https://user-images.githubusercontent.com/13558917/140859710-aaa65dbb-8814-4c91-83f2-eba4b2d84c1f.png">

12. In the simulator, confirm the second `DisplayAlert` does _not_ appear
   - If `ChildAdded` fires, a second `DisplayAlert` should appear, but `ChildAdded` does not fire

