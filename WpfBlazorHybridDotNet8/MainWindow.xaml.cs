using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AspNetCore.Components.WebView;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;
using WpfBlazorHybridDotNet8.Services;

namespace WpfBlazorHybridDotNet8
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly WpfInteractionService _wpfInteractionService;

		public MainWindow()
		{
			var services = new ServiceCollection();
			services.AddWpfBlazorWebView();
			services.AddFluentUIComponents();
			services.AddBlazorWebViewDeveloperTools();

			services.AddSingleton<WpfInteractionService>();
			services.AddSingleton<ShareDataToBlazorService>();
			Resources.Add("services", services.BuildServiceProvider());

			InitializeComponent();

			var serviceProvider = (IServiceProvider)Resources["services"];

			_wpfInteractionService = serviceProvider.GetRequiredService<WpfInteractionService>();
			_wpfInteractionService.OnMessageSent += HandleMessageFromBlazor;

			var _dataService = serviceProvider.GetRequiredService<ShareDataToBlazorService>();
			_dataService.SharedData = "Hello from WPF!";
		}

		private void HandleMessageFromBlazor(string message)
		{
			this.Close();
		}
	}
}