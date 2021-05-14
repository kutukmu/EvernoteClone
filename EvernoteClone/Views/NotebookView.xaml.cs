using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EvernoteClone.Views
{
    /// <summary>
    /// Interaction logic for NotebookView.xaml
    /// </summary>
    public partial class NotebookView : Window
    {
        public NotebookView()
        {
            InitializeComponent();
            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            FontFamily_ComboBox.ItemsSource = fontFamilies;

            List<double> fontSizes = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 28, 48 };
            FontSize_ComboBox.ItemsSource = fontSizes;


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void Speech_Button_Click(object sender, RoutedEventArgs e)
        {
            string region = "eastus";
            string key = "590baf5f884d4527ba0112583c8fa1ff";
            var speechConfig = SpeechConfig.FromSubscription(key, region);
            using(var audioConfig = AudioConfig.FromDefaultMicrophoneInput())
            {
                using(var recognizer = new SpeechRecognizer(speechConfig, audioConfig))
                {
                    var result = await recognizer.RecognizeOnceAsync();
                    contentRichTextbox.Document.Blocks.Add(new Paragraph(new Run(result.Text)));
                }
            }
        }

        private void contentRichTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int range = (new TextRange(contentRichTextbox.Document.ContentStart, contentRichTextbox.Document.ContentEnd)).Text.Length;
            statusTextBlock.Text = $"Current Character Amount is {range}";
        }

        private void Bold_Button_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked = (sender as ToggleButton).IsChecked ?? false;
            if(isChecked)
            contentRichTextbox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            else
            contentRichTextbox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);

        }

        private void contentRichTextbox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var weigth = contentRichTextbox.Selection.GetPropertyValue(FontWeightProperty);
            Bold_Button.IsChecked = (weigth != DependencyProperty.UnsetValue) && weigth.Equals(FontWeights.Bold);

            FontFamily_ComboBox.SelectedItem = contentRichTextbox.Selection.GetPropertyValue(FontFamilyProperty);
            FontSize_ComboBox.Text = (contentRichTextbox.Selection.GetPropertyValue(FontSizeProperty)).ToString();
        }

        private void FontFamily_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FontFamily_ComboBox.SelectedItem != null)
            {
                contentRichTextbox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontFamily_ComboBox.SelectedItem);
            }

        }


        private void FontSize_ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            contentRichTextbox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSize_ComboBox.Text);
        }
    }
}
