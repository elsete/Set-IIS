using System.Collections.Generic;
using System.Linq;

namespace SetIIS.Model
{
    public class Branch
    {
        #region Public Properties

        public string Name;
        public List<IISSite> Sites;

        #endregion

        #region Constructor

        public Branch() {
            this.Name = string.Empty;
            this.Sites = new List<IISSite>();
        }

        #endregion

        #region Public Methods

        public IISSite GetSite(string sSite)
        {
            return this.Sites.Where(site => site.Name == sSite).DefaultIfEmpty(null).First<IISSite>();
        }

        #endregion
    }
}