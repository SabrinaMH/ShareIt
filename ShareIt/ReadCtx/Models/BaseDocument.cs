namespace ShareIt.ReadCtx.Models
{
    public abstract class BaseDocument
    {
        public string DocumentType { get; private set; }

        public BaseDocument(string documentType)
        {
            DocumentType = documentType;
        }
    }
}