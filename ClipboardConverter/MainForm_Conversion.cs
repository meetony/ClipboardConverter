using System.Text;

namespace ClipboardConverter
{
    partial class MainForm
    {
        private bool _enabled;

        private void EnableConversion()
        {
            _enabled = true;
            enableToolStripMenuItem.Checked = true;
            disableToolStripMenuItem.Checked = false;
            notifyIcon.Icon = Properties.Resources.Icon_Enabled;
            notifyIcon.Text = Properties.Resources.Text_Enabled;
        }

        private void DisableConversion()
        {
            _enabled = false;
            enableToolStripMenuItem.Checked = false;
            disableToolStripMenuItem.Checked = true;
            notifyIcon.Icon = Properties.Resources.Icon_Disabled;
            notifyIcon.Text = Properties.Resources.Text_Disabled;
        }

        private void ConvvertClipboardOnTheFly()
        {
            ConvertClipboard();
            BlinkIcon();
        }

        private void BlinkIcon()
        {
            Icon prev = notifyIcon.Icon;
            notifyIcon.Icon = Properties.Resources.Icon_Enabled;
            Thread.Sleep(100);
            notifyIcon.Icon = prev;
        }

        private void ConvertClipboard()
        {
            if (Clipboard.ContainsText())
            {
                string src = Clipboard.GetText();
                string dst = ConvChars(src);

                if (src != dst) Clipboard.SetText(dst);
            }
        }

        private string ConvChars(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);

            foreach (char c in s)
            {
                char c2 = c;
                if (c >= '０' && c <= '９')
                    c2 = (char)(c - '０' + '0');
                else if (c >= 'Ａ' && c <= 'Ｚ')
                    c2 = (char)(c - 'Ａ' + 'A');
                else if (c >= 'ａ' && c <= 'ｚ')
                    c2 = (char)(c - 'ａ' + 'a');
                else
                    switch (c)
                    {
                        case ' ':
                            c2 = '_';
                            break;
                        case '＿':
                            c2 = '_';
                            break;
                        case '（':
                            c2 = '(';
                            break;
                        case '）':
                            c2 = ')';
                            break;
                        case '［':
                            c2 = '[';
                            break;
                        case '］':
                            c2 = ']';
                            break;
                        case '｛':
                            c2 = '{';
                            break;
                        case '｝':
                            c2 = '}';
                            break;
                        case '・':
                            c2 = '･';
                            break;
                    }
                sb.Append(c2);
            }
            return sb.ToString();
        }
    }    
}
