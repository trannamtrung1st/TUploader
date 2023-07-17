using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using MimeKit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TUploader.MainApp.Services
{
    public class GoogleDriveService
    {
        public const string CredentialsFile = "credentials.json";
        const string ApplicationName = nameof(TUploader);

        private DriveService _driveService;
        private UserCredential _userCredential;

        public async Task Authorize(string user, Stream credStream, CancellationToken cancellationToken = default)
        {
            _userCredential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(credStream).Secrets,
                new[] { DriveService.Scope.DriveFile },
                user: user, cancellationToken);

            if (_driveService != null)
            {
                _driveService.Dispose();
            }

            _driveService = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = _userCredential,
                ApplicationName = ApplicationName
            });
        }

        public async Task UploadFile(string filePath, string folderId = null, CancellationToken cancellationToken = default)
        {
            if (_driveService == null) return;

            if (string.IsNullOrWhiteSpace(folderId))
            {
                string defaultFolderName = "Screenshots";
                FilesResource.ListRequest listRequest = _driveService.Files.List();
                listRequest.Q = $"name = '{defaultFolderName}' and mimeType = 'application/vnd.google-apps.folder' and trashed=false";
                listRequest.Fields = "files(id,name)";
                Google.Apis.Drive.v3.Data.FileList folderResult = await listRequest.ExecuteAsync(cancellationToken);
                Google.Apis.Drive.v3.Data.File folderFile = folderResult.Files.FirstOrDefault(f => f.Parents == null && f.Name == defaultFolderName);

                if (folderFile == null)
                {
                    folderFile = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = defaultFolderName,
                        MimeType = "application/vnd.google-apps.folder"
                    };

                    FilesResource.CreateRequest createFolderRequest = _driveService.Files.Create(folderFile);
                    createFolderRequest.Fields = "id";
                    folderFile = await createFolderRequest.ExecuteAsync(cancellationToken);
                }

                folderId = folderFile.Id;
            }

            string fileName = Path.GetFileName(filePath);
            FilesResource.ListRequest listFileRequest = _driveService.Files.List();
            listFileRequest.Q = $"name = '{fileName}' and trashed=false and '{folderId}' in parents";
            listFileRequest.Fields = "files(id,name,mimeType)";
            Google.Apis.Drive.v3.Data.FileList fileResult = await listFileRequest.ExecuteAsync(cancellationToken);
            Google.Apis.Drive.v3.Data.File fileMetadata = fileResult.Files.FirstOrDefault();

            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                if (fileMetadata == null)
                {
                    fileMetadata = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = fileName,
                        Parents = new List<string> { folderId }
                    };

                    string contentType = MimeTypes.GetMimeType(fileName);
                    FilesResource.CreateMediaUpload request = _driveService.Files.Create(fileMetadata, stream, contentType);
                    request.Upload();
                }
                else
                {
                    FilesResource.UpdateMediaUpload request = _driveService.Files.Update(
                        new Google.Apis.Drive.v3.Data.File(),
                        fileMetadata.Id, stream, fileMetadata.MimeType);
                    request.Upload();
                }
            }
        }
    }
}
