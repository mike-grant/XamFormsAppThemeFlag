using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsAppThemeExperimental.Services;
using XamarinFormsAppThemeExperimental.Styles;
using XamarinFormsAppThemeExperimental.Views;

namespace XamarinFormsAppThemeExperimental
{
    public partial class App : Application
    {

        public App()
        {
            Device.SetFlags(new string[] { "AppTheme_Experimental" });

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
            
            SetTheme(Application.Current.RequestedTheme);
            
            Application.Current.RequestedThemeChanged += (s, a) => { SetTheme(a.RequestedTheme); };
        }

        private void SetTheme(OSAppTheme appTheme)
        {
            switch (appTheme)
            {
                case OSAppTheme.Dark:
                    Current.Resources = new DarkTheme();
                    break;
                case OSAppTheme.Light:
                    Current.Resources = new LightTheme();
                    break;
                case OSAppTheme.Unspecified:
                    Current.Resources = new LightTheme();
                    break;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
