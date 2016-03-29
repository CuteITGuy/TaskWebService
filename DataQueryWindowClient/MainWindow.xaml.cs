using System.Windows;
using CB.Database.SqlServer;
using CB.Web.WebServices;


namespace DataQueryWindowClient
{
    public partial class MainWindow
    {
        #region Fields
        private const string DATAQUERY_URL = "http://localhost:4975/api/dataquery";
        private const string INTEGER_URL = "http://localhost:4975/api/integer";
        private readonly DataQueryService _queryService = new DataQueryService(DATAQUERY_URL);
        #endregion


        #region  Constructors & Destructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion


        #region Event Handlers
        private async void CmdLoad_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await
                         _queryService.SendRequestsAsync(DataRequestCollection.Create("Installation", "GetAppFileInfos",
                             new { ApplicationId = 3 }));
            if (result.HasError)
            {
                MessageBox.Show(result.Error);
            }
            else
            {
                datMain.DataContext = result.FirstTable;
            }

            /*var ints = await Http.GetAsync<int[]>(INTEGER_URL);
            datMain.DataContext = ints;*/
        }
        #endregion
    }
}