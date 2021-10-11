using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace sem5_lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uploadButton.Click += UploadFileHandler;
            processTextButton.Click += ProcessTextHandler;
        }

        public void UploadFileHandler(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() ?? true)
            {
                inputTextBox.Text = File.ReadAllText(openFile.FileName);
            }
        }
        public void ProcessTextHandler(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() ?? true)
            {
                string outPutText = ProcessText(inputTextBox.Text);
                outputTextBox.Text = outPutText;

                File.WriteAllText(saveFile.FileName, outPutText);
            }
        }

        private string ProcessText(string text)
        {
            char[] sparators = new char[] { ' ', ',', '!', '.', '?', '\n' };
            string[] words = text.Split(sparators, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder("");
            foreach (string word in words)
            {
                if (word[0] == 'с' || word[0] == 'С')
                {
                    sb.Append(word);
                    sb.Append(" ");
                }
                else if (word[word.Length - 1] == 'с' || word[word.Length - 1] == 'С')
                {
                    sb.Append(word);
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }


    }
}
