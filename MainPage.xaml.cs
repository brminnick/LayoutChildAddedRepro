using System;
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

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var greenBox = new BoxView { BackgroundColor = Colors.Green };
			GridLayout.SetRow(greenBox, 1);
			GridLayout.SetColumn(greenBox, 0);

			MainGrid.Add(greenBox);
		}

		async void HandleChildAdded(object sender, ElementEventArgs e)
		{
			await DisplayAlert("Child Added", e.Element.GetType().FullName, "OK");
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			count++;
			CounterLabel.Text = $"Current count: {count}";

			SemanticScreenReader.Announce(CounterLabel.Text);
		}
	}
}
