using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Edit_text__work_with_string_
{
    public partial class Editor : Form
    {
        private bool _firstStage;
        private readonly string _introductoryWords_path = $"{Environment.CurrentDirectory}\\IntroductoryWordsList .json";
        private string[] _introductoryWords;
        public Editor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonDisabled(bRestart);
            _firstStage = true;
            try
            {
                var fileData = File.ReadAllText(_introductoryWords_path);
                _introductoryWords = JsonConvert.DeserializeObject<string[]>(fileData);
            }
            catch (Exception error) 
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                if (_introductoryWords == null) 
                    Close();
            }
        }

        async private void bFix_Click(object sender, EventArgs e)
        {
            if (_firstStage)
            {
                if (textBox.TextLength == 0)
                    MessageBox.Show("There are no text!");
                else
                {
                    string text = textBox.Text;

                    text = CheckAllIntrodactoryWords(text);
                    text = SpacesChecker(text);

                    textBox.Text = text;

                    ButtonDisabled(bFix);
                    bFix.Text = "Corrected";

                    await Task.Delay(2000);
                    
                    ButtonEnabled(bFix);
                    bFix.Text = "Copy";

                    _firstStage = false;
                }
            }
            else
            {
                Clipboard.SetDataObject(textBox.Text);
                bFix.Text = "Saved";
                ButtonDisabled(bFix);
                ButtonEnabled(bRestart);
            }
        }
        private void bRestart_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            bFix.Text = "Fix text";

            ButtonEnabled(bFix);
            ButtonDisabled(bRestart);
        }
        string CheckAllIntrodactoryWords(string text)
        {
            foreach (var introductoryWord in _introductoryWords)
                text = CheckForComma(text, introductoryWord);
            return text;
        }
        string CheckForComma(string text, string introdactoryWord)
        {
            int index = -1;
            do
            {
                index = text.ToLower().IndexOf(introdactoryWord, index + 1);
                if (index == -1)
                    return text;

                if (text[index + introdactoryWord.Length] != ',')
                    text = text.Insert(index + introdactoryWord.Length, ",");
            }
            while (true);
        }        
        string SpacesChecker(string text)
        {
            if (text[text.Length - 1] == '.')
                text = text.Remove(text.Length - 1, 1);

            int index = -1;
            do
            {
                index = text.IndexOfAny(".,".ToCharArray(), index + 1);

                if(index == -1)
                    return text + ".";

                if (text[index + 1] != ' ')
                    text = text.Insert(index + 1, " ");

                if (text[index - 1] == ' ')
                    text = text.Remove(index - 1, 1);
            }
            while (true);
        }

        void ButtonDisabled(Button button)
        {
            button.Enabled = false;
            button.FlatAppearance.BorderColor = Color.LightSeaGreen;
        }
        void ButtonEnabled(Button button)
        {
            button.Enabled = true;
            button.FlatAppearance.BorderColor = Color.DarkCyan;
        }
    }
}
