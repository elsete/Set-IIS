using Microsoft.Web.Administration;
using SetIIS.Model;
using SetIIS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SetIIS
{
    public partial class frmConfig : Form
    {
        #region Private Properties

        private List<Microsoft.Web.Administration.Application> _LstApplication;
        private bool _IsLoading;

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
        public frmConfig()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        #region Form

        private void frmConfig_Load(object sender, EventArgs e)
        {
            this.formPopulate();
        }

        #endregion

        #region ComboBox

        private void cbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._IsLoading = true;

            this.setSitesInBranch();
            this.setSiteValues();

            this._IsLoading = false;
        }

        #endregion

        #region CheckListBox

        private void clbSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._IsLoading = true;

            this.setSiteValues();

            this._IsLoading = false;
        }

        private void clbSites_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this._IsLoading = true;

            this.setSiteChecked(clbSites.Items[e.Index].ToString(), e.NewValue == CheckState.Checked);

            this._IsLoading = false;
        }

        private void clbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._IsLoading = true;

            this.setBranchValues();

            this._IsLoading = false;
        }

        #endregion

        #region Button

        private void btnSet_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;

            try
            {
                sMessage = this.Config.Save();
            }
            catch (Exception Ex)
            {
                sMessage = Ex.Message;
            }
            finally {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    MessageBox.Show(sMessage);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBranchDelete_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            bool bResult = false;

            try
            {
                bResult = string.IsNullOrEmpty(this.deleteBranch());
                sMessage = bResult ? "Rama eliminada correctamente" : string.Empty;
            }
            catch (Exception Ex)
            {
                sMessage = Ex.Message;
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    MessageBox.Show(sMessage);
                }

                if (bResult)
                {
                    this.formPopulate();
                }
            }
        }

        private void btnBranchInsert_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            bool bResult = false;

            try
            {
                sMessage = this.updateBranch(true);
                bResult = string.IsNullOrEmpty(sMessage);
                sMessage = bResult ? "Rama insertada correctamente" : sMessage;
            }
            catch (Exception Ex)
            {
                sMessage = Ex.Message;
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    MessageBox.Show(sMessage);
                }

                if (bResult)
                {
                    this.formPopulate();
                }
            }
        }

        private void btnBranchUpdate_Click(object sender, EventArgs e)
        {
            string sMessage = string.Empty;
            bool bResult = false;

            try
            {
                sMessage = this.updateBranch();
                bResult = string.IsNullOrEmpty(sMessage);
                sMessage = bResult ? "Rama actualizada correctamente" : sMessage;
            }
            catch (Exception Ex)
            {
                sMessage = Ex.Message;
            }
            finally {
                if (!string.IsNullOrWhiteSpace(sMessage))
                {
                    MessageBox.Show(sMessage);
                }

                if (bResult)
                {
                    this.formPopulate();
                }
            }
        }

        private void btnRefreshSites_Click(object sender, EventArgs e)
        {
            this._IsLoading = true;

            this.refreshSites();

            this._IsLoading = false;
        }

        #endregion

        #region TextBox

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (!this._IsLoading)
            {
                this.setSiteValues(true);
            }
        }

        #endregion

        #region CheckBox

        private void chkReset_CheckedChanged(object sender, EventArgs e)
        {
            this.Config.Reset = this.chkReset.Checked;
        }

        #endregion

        #endregion

        #region Private Methods

        private void formPopulate()
        {
            this._IsLoading = true;

            this.lblName.Text = string.Empty;
            this.txtPath.Text = string.Empty;
            this.txtBranch.Text = string.Empty;

            this.chkReset.Checked = this.Config.Reset;
            this.setCBBranch();
            this.setCLBBranches();
            this.loadIISSites();

            this._IsLoading = false;
        }

        private void setCBBranch()
        {
            this.cbBranch.Items.Clear();
            this.cbBranch.Items.AddRange(this.Config.Branches.Select(branch => branch.Name).ToList<string>().OrderBy(branch=>branch).ToArray());
        }

        private void setCLBBranches()
        {
            this.clbBranch.Items.Clear();
            this.clbBranch.Items.AddRange(Config.Branches.Select(branch => branch.Name).ToList<string>().OrderBy(branch=>branch).ToArray());
        }

        private void loadIISSites()
        {
            this._LstApplication = IIS.GetApplications();
            this.clbSites.Items.Clear();
            this.clbSites.Items.AddRange(_LstApplication.Select(app => Path.GetFileName(app.Path)).ToList<string>().OrderBy(appName=>appName).ToArray());
        }

        private void setSiteChecked(string sSite, bool bChecked)
        {
            if (null != this.cbBranch.SelectedItem)
            {
                string sBranch = this.cbBranch.SelectedItem.ToString();
                Branch oBranch = !string.IsNullOrEmpty(sBranch) ? this.Config.GetBranch(sBranch) : null;
                if (null != oBranch)
                {
                    IISSite oSite = oBranch.GetSite(sSite);
                    if (null != oSite)
                    {
                        oSite.Checked = bChecked;
                    }
                }
            }
        }

        private void setSitesInBranch()
        {
            string sBranch = this.cbBranch.SelectedItem.ToString();

            Branch oBranch = !string.IsNullOrEmpty(sBranch) ? this.Config.GetBranch(sBranch) : null;
            if (null != oBranch)
            {
                for (int iIndex = 0; iIndex < this.clbSites.Items.Count; iIndex++)
                {
                    string sSite = clbSites.Items[iIndex].ToString();
                    IISSite oSite = oBranch.GetSite(sSite);
                    bool bChecked = null != oSite ? oSite.Checked : false;

                    if (null == oSite)
                    {
                        string sVirtualDirectory = this.getVirtualDirectory(sSite);
                        if (!string.IsNullOrEmpty(sVirtualDirectory))
                        {
                            oSite = new IISSite();
                            oSite.Name = sSite;
                            oSite.Path = sVirtualDirectory;
                            oBranch.Sites.Add(oSite);
                        }
                    }

                    this.clbSites.SetItemChecked(iIndex, bChecked);
                }
            }
        }

        private string getVirtualDirectory(string sSite)
        {
            string sReturn = string.Empty;

            Microsoft.Web.Administration.Application oApp = this._LstApplication.Where(app => Path.GetFileName(app.Path) == sSite).First();
            if (null != oApp)
            {
                VirtualDirectory oVirtualDirectory = oApp.VirtualDirectories.Where(vDir => vDir.Path == "/").Single();
                if (null != oVirtualDirectory)
                {
                    sReturn = oVirtualDirectory.PhysicalPath;
                }
            }

            return sReturn;
        }

        private void setSiteValues(bool bSetChange = false)
        {
            if (!bSetChange)
            {
                this.lblName.Text = string.Empty;
                this.txtPath.Text = string.Empty;
            }

            string sBranch = null != this.cbBranch.SelectedItem ? this.cbBranch.SelectedItem.ToString() : string.Empty;
            if (!string.IsNullOrEmpty(sBranch))
            {
                string sSite = null != this.clbSites.SelectedItem ? this.clbSites.SelectedItem.ToString() : string.Empty;
                if (!string.IsNullOrEmpty(sSite))
                {
                    Branch oBranch = !string.IsNullOrEmpty(sBranch) ? this.Config.GetBranch(sBranch) : null;
                    if (null != oBranch)
                    {
                        IISSite oSite = oBranch.GetSite(sSite);
                        if (null != oSite)
                        {
                            if (!bSetChange)
                            {
                                this.lblName.Text = oSite.Name;
                                this.txtPath.Text = oSite.Path;
                            }
                            else {
                                oSite.Path = this.txtPath.Text;
                            }
                        }
                    }
                }
            }
        }

        private void setBranchValues()
        {
            string sBranch = null != this.clbBranch.SelectedItem ? this.clbBranch.SelectedItem.ToString() : string.Empty;
            if (!string.IsNullOrEmpty(sBranch))
            {
                Branch oBranch = this.Config.GetBranch(sBranch);
                if (null != oBranch)
                {
                    this.txtBranch.Text = oBranch.Name;
                }
            }
        }

        private string updateBranch(bool bIsNew = false)
        {
            string sReturn = string.Empty;
            
            if (bIsNew || null != this.clbBranch.SelectedItem)
            {
                string sNewName = this.txtBranch.Text.Trim();
                if (!string.IsNullOrEmpty(sNewName))
                {
                    if (Config.Branches.Where(branch => branch.Name.ToLower() == sNewName.ToLower()).ToList().Count == 0)
                    {
                        string sBranch = !bIsNew ? this.clbBranch.SelectedItem.ToString() : string.Empty;
                        if (bIsNew || !string.IsNullOrEmpty(sBranch))
                        {
                            Branch oBranch = !bIsNew ? Config.GetBranch(sBranch) : new Branch();
                            if (null != oBranch)
                            {
                                oBranch.Name = sNewName;
                                oBranch.Sites = !bIsNew ? oBranch.Sites : this.getSites();

                                if (bIsNew)
                                {
                                    Config.Branches.Add(oBranch);
                                }
                            }

                            sReturn = Config.Save();
                        }
                    }
                    else {
                        sReturn = "Ya existe una Rama con este nombre";
                    }
                }
                else {
                    sReturn = "Nombre de Rama no es válido";
                }
            }
            else {
                sReturn = "No hay Rama seleccionada";
            }

            return sReturn;
        }

        private string deleteBranch()
        {
            string sReturn = "No hay Rama seleccionada";

            if (null != this.clbBranch.SelectedItem)
            {
                string sBranch = this.clbBranch.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(sBranch))
                {
                    Branch oBranch = Config.GetBranch(sBranch);
                    if (null != oBranch)
                    {
                        if (MessageBox.Show("¿Eliminar Rama?", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Config.Branches.Remove(oBranch);
                            sReturn = Config.Save();
                        }
                        else {
                            sReturn = " ";
                        }
                    }
                }
            }

            return sReturn;
        }

        private void refreshSites()
        {
            string sBranch = null != this.cbBranch.SelectedItem ? this.cbBranch.SelectedItem.ToString() : string.Empty;
            if (!string.IsNullOrEmpty(sBranch))
            {
                Branch oBranch = Config.GetBranch(sBranch);
                if (null != oBranch)
                {
                    oBranch.Sites = this.getSites(oBranch);
                    this.setSitesInBranch();
                    this.setSiteValues();
                }
            }
        }

        private List<IISSite> getSites(Branch oBranchUpdate = null)
        {
            List<IISSite> lstReturn = new List<IISSite>();

            if (null != oBranchUpdate)
            {
                this.loadIISSites();
            }

            this._LstApplication.ForEach(app =>
            {
                VirtualDirectory oVirtualDirectory = app.VirtualDirectories.Where(vDir => vDir.Path == "/").Single();
                if (null != oVirtualDirectory)
                {
                    IISSite oSite = new IISSite();
                    oSite.Name = Path.GetFileName(app.Path);
                    oSite.Path = oVirtualDirectory.PhysicalPath;
                    oSite.Checked = null == oBranchUpdate ? false : this.valueCurrentSite(oBranchUpdate, oSite.Name);

                    lstReturn.Add(oSite);
                }
            });
            
            return lstReturn;
        }

        private bool valueCurrentSite(Branch oBranchUpdate, string sSite)
        {
            IISSite oSite = oBranchUpdate.GetSite(sSite);

            return null != oSite && oSite.Checked;
        }

        #endregion
    }
}