﻿namespace BukkMaraton2019GUI {
	public partial class App : Application {
		public App() {
			InitializeComponent();

			MainPage = new AppShell();
		}

		protected override Window CreateWindow(IActivationState activationState) {
			var window = base.CreateWindow(activationState);

			const int newWidth = 400;
			const int newHeight = 300;

			window.Width = newWidth;
			window.Height = newHeight;

			return window;
		}
	}
}