using System;
using System.IO;
using System.Windows.Forms;

namespace DesktopNotepad
{
    public partial class MainForm : Form
    {
        private string notesPath = Path.Combine(Application.StartupPath, "notes.txt"); // 数据保存路径（与程序同目录）

        public MainForm()
        {
            InitializeComponent();
            LoadNotes(); // 启动时加载历史记录
        }

        private void LoadNotes()
        {
            if (File.Exists(notesPath))
            {
                txtContent.Text = File.ReadAllText(notesPath);
            }
        }

        private void SaveNotes()
        {
            File.WriteAllText(notesPath, txtContent.Text);
        }

        // 窗体关闭时自动保存
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveNotes();
            base.OnFormClosing(e);
        }

        // 以下为WinForms设计器自动生成的代码（无需手动修改）
        #region Windows Form Designer generated code
        private TextBox txtContent;

        private void InitializeComponent()
        {
            this.txtContent = new TextBox();
            this.SuspendLayout();
            
            // txtContent 控件设置
            this.txtContent.Dock = DockStyle.Fill;
            this.txtContent.Multiline = true;
            this.txtContent.ScrollBars = ScrollBars.Vertical;
            this.txtContent.Font = new System.Drawing.Font("微软雅黑", 10.5F);

            // 窗体设置
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.txtContent);
            this.Text = "桌面便笺";
            this.StartPosition = FormStartPosition.CenterScreen; // 启动时居中显示
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}