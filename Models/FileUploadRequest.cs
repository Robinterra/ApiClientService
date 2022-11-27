namespace ApiService
{

    public class FileUploadRequest
    {

        #region get/set

        public FileInfo File
        {
            get;
        }

        public string FileName
        {
            get;
        }

        public string Name
        {
            get;
        }

        #endregion get/set

        #region ctor

        public FileUploadRequest(FileInfo file, string name, string fileName)
        {
            this.File = file;
            this.Name = name;
            this.FileName = fileName;
        }

        #endregion ctor

    }

}