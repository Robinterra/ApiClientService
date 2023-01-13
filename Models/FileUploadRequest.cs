namespace ApiService
{

    public class FileUploadRequest
    {

        #region get/set

        public Stream Stream
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
            this.Stream = file.OpenRead();
            this.Name = name;
            this.FileName = fileName;
        }

        public FileUploadRequest(Stream stream, string name, string fileName)
        {
            this.Stream = stream;
            this.Name = name;
            this.FileName = fileName;
        }

        #endregion ctor

    }

}