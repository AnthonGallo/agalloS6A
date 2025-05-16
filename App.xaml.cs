using agalloS6A.Views;

namespace agalloS6A
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new vCrud());
        }
    }
}