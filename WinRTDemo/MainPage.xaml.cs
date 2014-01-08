using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WinRTDemo.Common;

namespace WinRTDemo
{
    public sealed partial class MainPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private PasswordStrengthViewModel passwordStrengthViewModel = new PasswordStrengthViewModel();

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            DefaultViewModel["PasswordStrength"] = passwordStrengthViewModel;
        }

        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper の登録

        /// このセクションに示したメソッドは、NavigationHelper がページの
        /// ナビゲーション メソッドに応答できるようにするためにのみ使用します。
        /// 
        /// ページ固有のロジックは、
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// および <see cref="GridCS.Common.NavigationHelper.SaveState"/> のイベント ハンドラーに配置する必要があります。
        /// LoadState メソッドでは、前のセッションで保存されたページの状態に加え、
        /// ナビゲーション パラメーターを使用できます。

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
            {
                return;
            }

            passwordStrengthViewModel.Update(textBox.Text);
        }
    }
}
