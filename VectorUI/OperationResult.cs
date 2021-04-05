namespace VectorUI
{
    public class OperationResult
    {
        public string headerText; 
        public string bottomText; 
        public OperationStatus status;

        public OperationResult(string headerText, string bottomText, OperationStatus status)
        {
            this.headerText = headerText;
            this.bottomText = bottomText;
            this.status = status;
        }
    }
}