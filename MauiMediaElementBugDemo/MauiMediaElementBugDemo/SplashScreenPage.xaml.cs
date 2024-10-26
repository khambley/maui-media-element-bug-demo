using CommunityToolkit.Maui.Views;

namespace MauiMediaElementBugDemo;

public partial class SplashScreenPage : ContentPage
{
	public SplashScreenPage()
	{
		InitializeComponent();
        mediaElement2.IsVisible = false;
        getStartedButton.IsVisible = false;

        PlaySplashVideo();

        if (VersionTracking.Default.IsFirstLaunchEver)
        {
            PlayOnboardingVideo();
        }
        spinner.IsRunning = false;
        spinner.IsVisible = false;
    }
    private void PlaySplashVideo()
    {
        mediaElement.Source = MediaSource.FromResource("Videos/splashanimation.mp4");
    }

    private void PlayOnboardingVideo()
    {
        mediaElement2.Source = MediaSource.FromResource("Videos/onboardingvideo1.mp4");
    }

    private async void OnMediaEnded(object sender, EventArgs e)
    {
        if (VersionTracking.Default.IsFirstLaunchEver)
        {
            mediaElement.IsVisible = false;
            mediaElement2.Play();
            mediaElement2.IsVisible = true;
            getStartedButton.IsVisible = true;
        }
        else
        {
            Application.Current.MainPage = new AppShell();
        }

    }

    void mediaElement2_MediaEnded(System.Object sender, System.EventArgs e)
    {
        //Application.Current.MainPage = new AppShell();
    }
    void Handle_Clicked(object sender, System.EventArgs e)
    {
        spinner.IsRunning = true;
        spinner.IsVisible = true;

        Application.Current.MainPage = new AppShell();

        spinner.IsRunning = false;
        spinner.IsVisible = false;

        //if (Device.RuntimePlatform == Device.iOS)
        //{
        //    Application.Current.MainPage = new PushNotificationsPage();
        //}
    }
}
