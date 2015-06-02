using GifAtMe.Repository.Contexts;
using System.Data.Entity;
using System.Web;

namespace GifAtMe.Repository
{
    public class GifAtMeContextFactory : IGifAtMeContextFactory
    {
        private string _dataContextKey = "EfObjectContext";

        public GifAtMeContext Create()
        {
            GifAtMeContext stContext = null;
            if (HttpContext.Current.Items.Contains(_dataContextKey))
            {
                stContext = HttpContext.Current.Items[_dataContextKey] as GifAtMeContext;
            }
            else
            {
                stContext = new GifAtMeContext();
                Store(stContext);
            }
            return stContext;
        }

        private void Store(GifAtMeContext stContext)
        {
            if (HttpContext.Current.Items.Contains(_dataContextKey))
            {
                HttpContext.Current.Items[_dataContextKey] = stContext;
            }
            else
            {
                HttpContext.Current.Items.Add(_dataContextKey, stContext);
            }
        }
    }
}