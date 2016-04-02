using CB.Web.WebServices;


namespace TaskWebHost.Controllers
{
    public class DataQueryController: QueryController
    {
        #region  Constructors & Destructor
        public DataQueryController(): base("dataQueryConnection") { }
        #endregion
    }
}