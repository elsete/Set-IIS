using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SetIIS.Model
{
    public class Config
    {
        #region Private Properties

        private const string FILENAME = "SetIIS.config";

        #endregion

        #region Public Properties

        public string LastBranchSelected;
        public List<Branch> Branches;
        public bool Reset;

        #endregion

        #region Constructor

        public Config()
        {
            this.LastBranchSelected = string.Empty;
            this.Branches = new List<Branch>();
            this.Reset = true;
        }

        #endregion

        #region Public Methods

        public static Config Load()
        {
            Config oReturn = new Config();

            try
            {
                string sFolder = Path.GetDirectoryName(Application.ExecutablePath);
                string sFile = Path.Combine(sFolder, FILENAME);
                string sJson = File.Exists(sFile) ? File.ReadAllText(sFile) : string.Empty;

                if (!string.IsNullOrEmpty(sJson))
                {
                    oReturn = JsonConvert.DeserializeObject<Config>(sJson);
                }
            }
            catch { }

            return oReturn;
        }

        public string Save()
        {
            string sReturn = string.Empty;

            try
            {
                string sJson = JsonConvert.SerializeObject(this);
                string sFolder = Path.GetDirectoryName(Application.ExecutablePath);
                File.WriteAllText(Path.Combine(sFolder, FILENAME), sJson);
            }
            catch (Exception Ex)
            {
                sReturn = Ex.Message;
            }

            return sReturn;
        }

        public Branch GetBranch(string sName)
        {
            return this.Branches.Where(branch => branch.Name == sName).First();
        }

        public Branch GetLastBranch()
        {
            return this.GetBranch(this.LastBranchSelected);
        }

        #endregion

        #region Private Methods
        
        #endregion
    }
}