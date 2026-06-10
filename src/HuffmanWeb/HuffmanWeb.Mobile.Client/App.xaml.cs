namespace HuffmanWeb.Mobile.Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterGlobalExceptionHandlers();
            MainPage = new NavigationPage(new MainPage());
        }

        private static void RegisterGlobalExceptionHandlers()
        {
            AppDomain.CurrentDomain.UnhandledException += (_, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"[FATAL] Unhandled exception: {e.ExceptionObject}");
            };

            TaskScheduler.UnobservedTaskException += (_, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"[ERROR] Unobserved task exception: {e.Exception}");
                e.SetObserved();
            };
        }
    }
}
