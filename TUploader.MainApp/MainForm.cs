using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThrottleDebounce;
using TUploader.MainApp.Properties;
using TUploader.MainApp.Services;

namespace TUploader.MainApp
{
    public partial class MainForm : Form
    {
        private readonly ConcurrentDictionary<string, RateLimitedAction> _debounceMap;
        private readonly GoogleDriveService _driveService;

        public MainForm()
        {
            InitializeComponent();
            _debounceMap = new ConcurrentDictionary<string, RateLimitedAction>();
            _driveService = new GoogleDriveService();
        }

        private void fileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            RateLimitedAction debouncedFunc = null;
            debouncedFunc = _debounceMap.GetOrAdd(e.FullPath, (key) => Debouncer.Debounce(() =>
            {
                try
                {
                    if (e.ChangeType == WatcherChangeTypes.Created)
                    {
                        Invoke((Func<Task>)(async () =>
                        {
                            try
                            {
                                txtResult.Text = e.FullPath;
                                await _driveService.UploadFile(e.FullPath, txtDriveFolder.Text);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", buttons: default, icon: MessageBoxIcon.Error);
                            }
                        }));
                    }
                }
                finally
                {
                    if (_debounceMap.TryRemove(key, out debouncedFunc))
                    {
                        debouncedFunc.Dispose();
                    }
                }
            }, TimeSpan.FromSeconds(1), leading: false, trailing: true));

            debouncedFunc.Invoke();
        }

        private void txtWatchingPath_TextChanged(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtWatchingPath.Text) && Directory.Exists(txtWatchingPath.Text))
            {
                fileSystemWatcher.Path = txtWatchingPath.Text;
            }
        }

        private void txtDriveFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    using (var credStream = new MemoryStream(Resources.Credentials))
                    {
                        await _driveService.Authorize(txtEmail.Text, credStream);
                    }

                    MessageBox.Show("Successfully authorized");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", buttons: default, icon: MessageBoxIcon.Error);
            }
        }
    }
}
