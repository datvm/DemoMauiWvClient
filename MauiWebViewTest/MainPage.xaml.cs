using Microsoft.Maui.Handlers;
using System.Diagnostics;

namespace MauiWebViewTest;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

        WebViewHandler.Mapper.AppendToMapping("MyHandler", (handler, view) =>
        {
#if ANDROID
			var xWv = handler.PlatformView;

			// For ProblemHandler2, this is needed to actually navigate:
			xWv.LoadUrl("https://www.google.com/");
#endif
        });

        this.wv.Source = "https://www.google.com/";
	}

}

