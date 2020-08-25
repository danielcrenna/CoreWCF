namespace CoreWCF.Description
{
    public abstract class MetadataExporter
    {
        public abstract void ExportContract(ContractDescription contract);
        public abstract void ExportEndpoint(ServiceEndpoint endpoint);
    }
}