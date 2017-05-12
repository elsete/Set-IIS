using SetIIS.Model;
using SetIIS.Util;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SetIIS
{
    public partial class frmSetIIS : Form
    {
        #region Private Properties

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private Config _Config;
        private Config Config
        {
            get
            {
                if (null == this._Config)
                {
                    this._Config = new Config();
                    this._Config = Config.Load();
                }

                return this._Config;
            }
        }

        #endregion

        #region Constructor

        public frmSetIIS()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        #region Form

        private void frmSetIIS_Load(object sender, EventArgs e)
        {
            this.setFormPosition();
            this.formPopulate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        #endregion

        #region Button

        private void btnSet_Click(object sender, EventArgs e)
        {
            this.setIIS();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.close();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.openConfig();
        }

        #endregion

        #region Context Menu

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openConfig();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.close(true);
        }

        #endregion

        #region NotyfIcon

        private void niSetIIS_Click(object sender, EventArgs e)
        {
            this.show();
        }

        private void niSetIIS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.show();
        }

        #endregion

        #endregion

        #region Private Methods

        private void close(bool bClose = false)
        {
            if (bClose)
            {
                this.Close();
            }
            else {
                this.Hide();
            }
        }

        private void show()
        {
            this.Show();
            this.Focus();
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
        }

        private void openConfig()
        {
            frmConfig frm = new frmConfig();
            frm.TopMost = true;
            frm.ShowDialog();

            this._Config = null;
            this.formPopulate();
        }

        private void setFormPosition()
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            int left = workingArea.Width - this.Width;
            int top = workingArea.Height - this.Height;

            this.Location = new Point(left, top);
            this.show();
        }

        private void formPopulate()
        {
            this.setBranches();
            this.setDefaultValues();
        }

        private void setBranches()
        {
            this.cbBranch.Items.Clear();
            this.cbBranch.Items.AddRange(this.Config.Branches.Select(branch => branch.Name).ToList<string>().OrderBy(branch=>branch).ToArray());
        }

        private void setDefaultValues()
        {
            if (!string.IsNullOrEmpty(this.Config.LastBranchSelected))
            {
                int iIndex = this.cbBranch.Items.IndexOf(this.Config.LastBranchSelected);
                if (iIndex > -1)
                {
                    this.cbBranch.SelectedIndex = iIndex;
                }
            }
        }

        private void setIIS()
        {
            Branch oBranch = this.cbBranch.SelectedIndex >= 0
                ? this.Config.GetBranch(this.cbBranch.Items[this.cbBranch.SelectedIndex].ToString()) 
                : null;

            this.Config.LastBranchSelected = oBranch.Name;
            string sResult = IIS.SaveChanges(Config);

            if (string.IsNullOrEmpty(sResult))
            {
                this.Config.Save();
                
                MessageBox.Show(string.Concat("Terminado.", this.Config.Reset ? " Se va a reiniciar el IIS." : string.Empty));
                if (this.Config.Reset)
                {
                    IIS.Reset();
                }

                this.close();
            }
            else {
                MessageBox.Show(sResult);
            }
        }

        #endregion
    }
}