using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
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
                    FixText(ref text);

                    textBox.Text = text;

                    ButtonDisabled(bFix);
                    bFix.Text = "Corrected";

                    await Task.Delay(1500);
                    
                    ButtonEnabled(bFix);
                    ButtonEnabled(bRestart);

                    bFix.Text = "Copy";

                    _firstStage = false;
                }
            }
            else
            {
                Clipboard.SetDataObject(textBox.Text);
                bFix.Text = "Saved";
                ButtonDisabled(bFix);
            }
        }
        private void bRestart_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            bFix.Text = "Fix text";

            ButtonEnabled(bFix);
            ButtonDisabled(bRestart);
            _firstStage = true;
        }

        void FixText(ref string text)
        {
            CheckAllIntrodactoryWords(ref text);
            SpacesChecker(ref text);
            ReplayceAbbreviations(ref text);
        }
        void CheckAllIntrodactoryWords(ref string text)
        {
            foreach (var introductoryWord in _introductoryWords)
                CheckForComma(ref text, introductoryWord);
        }
        void CheckForComma(ref string text, string introdactoryWord)
        {
            int index = -1;
            do
            {
                index = text.ToLower().IndexOf(introdactoryWord, index + 1);
                if (index == -1)
                    break;

                if (text[index + introdactoryWord.Length] != ',')
                    text = text.Insert(index + introdactoryWord.Length, ",");
            }
            while (true);
        }        
        void SpacesChecker(ref string text)
        {
            text = text.Trim();
            if (text[text.Length - 1] == '.')
                text = text.Remove(text.Length - 1, 1);

            int index = -1;
            do
            {
                index = text.IndexOfAny(".,".ToCharArray(), index + 1);

                if(index == -1)
                {
                    text += ".";
                    break;
                }

                if (text[index + 1] != ' ')
                    text = text.Insert(index + 1, " ");

                if (text[index - 1] == ' ')
                    text = text.Remove(index - 1, 1);
            }
            while (true);
        }
        void ReplayceAbbreviations(ref string text)
        {
            text = text.ToLower().Replace("brb", "be right back");
            text = text.ToLower().Replace("lol", "laugh out loud");
            text = text.ToLower().Replace("btw", "by the way");
            text = text.ToLower().Replace("idk", "I don't know");
            text = text.ToLower().Replace("ttyl", "talk to you later");
            text = text.ToLower().Replace("lmk", "let me know");
            text = text.ToLower().Replace("nvm", "nevermind");
            text = text.ToLower().Replace("imo", "in my opinion");
            text = text.ToLower().Replace("imho", "in my humble opinion");
            text = text.ToLower().Replace("tbo", "to be honest");
            text = text.ToLower().Replace("thx", "thanks");
            text = text.ToLower().Replace("jk", "just kidding");
            text = text.ToLower().Replace("bc", "because");
            text = text.ToLower().Replace("wbu", "what about you");
            text = text.ToLower().Replace("sry", "sorry"); 
            text = text.ToLower().Replace("asap", "as soon as possible");

            text = text.ToLower().Replace(" k ", " okay ");
            text = text.ToLower().Replace(" u ", " you ");
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
