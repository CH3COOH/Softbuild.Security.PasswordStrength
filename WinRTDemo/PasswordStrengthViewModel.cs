using Windows.UI;
using Windows.UI.Xaml.Media;

namespace WinRTDemo
{
    public class PasswordStrengthViewModel : WinRTDemo.Common.BindableBase
    {
        private Softbuild.Security.PasswordStrength passwordStrenght;

        public PasswordStrengthViewModel()
        {
            passwordStrenght = new Softbuild.Security.PasswordStrength();
            passwordStrenght.ValidComplexity = 0.8f;
            Update(string.Empty);
        }

        private SolidColorBrush foregroundColor;

        public SolidColorBrush ForegroundColor
        {
            get { return foregroundColor; }
            set { SetProperty(ref foregroundColor, value); }
        }

        private float complexity;

        public float Complexity
        {
            get { return complexity; }
            set { SetProperty(ref complexity, value); }
        }
        
        private string descriptionText;

        public string DescriptionText
        {
            get { return descriptionText; }
            set { SetProperty(ref descriptionText, value); }
        }


        public void Update(string password)
        {
            passwordStrenght.Password = password;
            var result = passwordStrenght.Validate();

            Complexity = result.Complexity;

            var c = (result.Valid) ? Colors.Green : Colors.Red;
            ForegroundColor = new SolidColorBrush(c);

            var displayValue = result.Complexity * 100;
            var displayValid = (result.Valid) ? @"YES" : @"NO";
            DescriptionText = string.Format("Complexity: {0} %, Valid: {1}", displayValue, displayValid);
        }

    }
}
