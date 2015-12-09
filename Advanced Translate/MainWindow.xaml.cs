using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Yam.Microsoft.Translator;

namespace Advanced_Translator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(LanguageNameToCode("thai"));
            using (Translator translator = new Translator("Apichai_Test_01", "docY9hYqU0+GgKVGzFiUSBRo5p5280i1KPAmAIlH0oE=", "", "th"))
            {
                var report = translator.Translate(@"Microsoft Translator");
                MessageBox.Show(report);
            }
            
        }

        public string LanguageNameToCode(string languageName)
        {
            try
            {
                var index = Array.FindIndex(LanguageName, item => string.Equals(item, languageName, StringComparison.CurrentCultureIgnoreCase));
                return LanguageCode[index];
            }
            catch (Exception)
            {
                return "";
            }
        }


        public static string[] LanguageCode = new[]
        {
            "ar", "bs", "bg", "ca", "zh", "zh", "hr", "cs", "da", "nl", "en", "et", "fi", "fr", "de", "el", "ht", "he",
            "hi", "mww", "hu", "id", "it", "ja", "tlh", "tlh", "ko", "lv", "lt", "ms", "mt", "no", "fa", "pl", "pt",
            "otq", "ro", "ru", "sr", "sr", "sk", "sl", "es", "sv", "th", "tr", "uk", "ur", "vi", "cy", "yua"
        };

        public static string[] LanguageName = new[]
        {
            "Arabic", "Bosnian", "Bulgarian", "Catalan", "Chinese Simplified", "Chinese Traditional", "Croatian", "Czech",
            "Danish", "Dutch", "English", "Estonian", "Finnish", "French", "German", "Greek", "Haitian Creole", "Hebrew",
            "Hindi", "Hmong Daw", "Hungarian", "Indonesian", "Italian", "Japanese", "Klingon", "Klingon", "Korean",
            "Latvian", "Lithuanian", "Malay", "Maltese", "Norwegian", "Persian", "Polish", "Portuguese",
            "Querétaro Otomi", "Romanian", "Russian", "Serbian", "Serbian", "Slovak", "Slovenian", "Spanish", "Swedish",
            "Thai", "Turkish", "Ukrainian", "Urdu", "Vietnamese", "Welsh", "Yucatec Maya"
        };



        
    }
}
