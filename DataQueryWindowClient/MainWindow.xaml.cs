using System;
using System.IO;
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
        private const string INSTALLATION_DB = "Installation";
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
                             new { ApplicationId = int.Parse(txtId.Text) }));
            if (_queryService.HasError)
            {
                MessageBox.Show(_queryService.Error);
            }
            else
            {
                datMain.DataContext = result.GetFirstTable();
            }

            /*var ints = await Http.GetAsync<int[]>(INTEGER_URL);
            datMain.DataContext = ints;*/
        }
        #endregion


        private async void MainWindow_OnDrop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            if (files == null) return;

            var file = files[0];
            var args = new
            {
                ApplicationId = int.Parse(txtId.Text),
                Description = txtDescription.Text,
                Directory = Path.GetDirectoryName(file),
                Extension = Path.GetExtension(file),
                IsInit = false,
                Name = Path.GetFileName(file),
                MajorVersion = 2,
                MinorVersion = 3,
                BuildVersion = 3,
                RevisionVersion = 2016
            };
            var query = DataRequestCollection.Create(INSTALLATION_DB, "InsertFileInfo", args);

            var result = await _queryService.SendRequestsAsync(query);
            if (_queryService.HasError)
            {
                MessageBox.Show(_queryService.Error);
            }
            else
            {
                var fileInfoId = Convert.ToInt32(result.GetFirstValue());
                txtFileInfoId.Text = fileInfoId.ToString();
            }
        }
    }
}