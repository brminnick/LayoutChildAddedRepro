using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Graphics;

namespace LayoutChildAddedRepro
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await DisplayAlert("OnAppearing Fired", "Click OK to add a Green Box View", "OK");

			var greenBox = new BoxView { BackgroundColor = Colors.Green };
			GridLayout.SetRow(greenBox, 1);
			GridLayout.SetColumn(greenBox, 0);

			MainGrid.Add(greenBox);
		}

		async void HandleChildAdded(object sender, ElementEventArgs e)
		{
			await DisplayAlert("Child Added", $"Added a {e.Element.GetType().FullName}", "OK");
		}

		void OnCounterClicked(object sender, EventArgs e)
		{
			count++;
			CounterLabel.Text = $"Current count: {count}";

			SemanticScreenReader.Announce(CounterLabel.Text);
		}
	}
}
