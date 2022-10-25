using Android.Webkit;
using Microsoft.Maui.Handlers;
using System.Diagnostics;

namespace MauiWebViewTest;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureMauiHandlers(handlers =>
			{
				handlers.AddHandler<Microsoft.Maui.Controls.WebView, ProblemHandler2>();
			});

		return builder.Build();
	}
}

internal class ProblemHandler1 : WebViewHandler
{

	protected override Android.Webkit.WebView CreatePlatformView()
	{
		var wv = base.CreatePlatformView();
		wv.SetWebViewClient(new CustomWebClient());

		return wv;
	}

}

internal class ProblemHandler2 : WebViewHandler
{

    protected override Android.Webkit.WebView CreatePlatformView()
    {
        var wv = new Android.Webkit.WebView(Android.App.Application.Context);
        wv.SetWebViewClient(new CustomWebClient());

        return wv;
    }

}

internal class CustomWebClient : WebViewClient
{

    public override WebResourceResponse ShouldInterceptRequest(Android.Webkit.WebView view, IWebResourceRequest request)
    {
        Debugger.Break();
        Debug.WriteLine(request.Url.ToString());

        return base.ShouldInterceptRequest(view, request);
    }

}