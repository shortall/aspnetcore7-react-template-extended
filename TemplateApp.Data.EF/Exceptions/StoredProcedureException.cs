namespace TemplateApp.Data.EF.Exceptions
{
    public class StoredProcedureException : Exception
    {
        public StoredProcedureException(string procName, Exception innerException)
            : base(string.Format("Error calling stored procedure {0}", procName), innerException) { }
    }
}
