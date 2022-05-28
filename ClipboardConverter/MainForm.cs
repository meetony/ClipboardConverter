namespace ClipboardConverter
{
    partial class MainForm : Form
    {
        public MainForm()
        {
            ShowInTaskbar = false;
            InitializeComponent();
            DisableConversion();
            RegisterClipboardViewer();
        }

        private void NofityIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) ConvvertClipboardOnTheFly();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        private void EnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableConversion();
        }

        private void DisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableConversion();
        }
    }
}