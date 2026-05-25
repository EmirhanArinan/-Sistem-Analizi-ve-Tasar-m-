namespace MobilSantiye
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Uygulama ilk açıldığında doğrudan LoginPage açılır
            MainPage = new LoginPage();
        }
    }
}
