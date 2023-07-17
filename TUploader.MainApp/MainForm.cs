using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThrottleDebounce;
using TUploader.MainApp.Models;
using TUploader.MainApp.Properties;
using TUploader.MainApp.Services;

namespace TUploader.MainApp
{
    public partial class MainForm : Form, IDisposable
    {
        private readonly ConcurrentDictionary<string, RateLimitedAction> _debounceMap;
        private readonly GoogleDriveService _driveService;
        private readonly SimpleDataStore _simpleDataStore;
        private SettingsModel _settingsModel;
        private RateLimitedAction _saveAction;

        public MainForm()
        {
            InitializeComponent();
            _debounceMap = new ConcurrentDictionary<string, RateLimitedAction>();
            _driveService = new GoogleDriveService();
            _simpleDataStore = new SimpleDataStore();
            _settingsModel = _simpleDataStore.Load<SettingsModel>() ?? new SettingsModel();
            _saveAction = Debouncer.Debounce(() => _simpleDataStore.Save(_settingsModel),
                TimeSpan.FromSeconds(1), leading: false, trailing: true);

            txtDriveFolder.Text = _settingsModel.DriveFolder;
            txtEmail.Text = _settingsModel.Email;
            txtWatchingPath.Text = _settingsModel.WatchingPath;

            if (_settingsModel.Email != null)
            {
                Task.Run(() => Login(_settingsModel.Email));
            }
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
            _settingsModel.WatchingPath = txtWatchingPath.Text;
            _saveAction.Invoke();

            if (!string.IsNullOrWhiteSpace(txtWatchingPath.Text) && Directory.Exists(txtWatchingPath.Text))
            {
                fileSystemWatcher.Path = txtWatchingPath.Text;
            }
        }

        private void txtDriveFolder_TextChanged(object sender, EventArgs e)
        {
            _settingsModel.DriveFolder = txtDriveFolder.Text;
            _saveAction.Invoke();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                Task.Run(() => Login(_settingsModel.Email));
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            _settingsModel.Email = txtEmail.Text;
            _saveAction.Invoke();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _saveAction.Dispose();
        }

        private async Task Login(string email)
        {
            try
            {
                using (var credStream = new MemoryStream(Resources.Credentials))
                {
                    await _driveService.Authorize(email, credStream);
                }

                MessageBox.Show("Successfully authorized");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", buttons: default, icon: MessageBoxIcon.Error);
            }
        }
    }
}
