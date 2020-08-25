using System;
using System.Collections.ObjectModel;
using CoreWCF.Channels;

namespace CoreWCF.Description
{
    public class ServiceMetadataBehavior : IServiceBehavior
    {
        private MetadataExporter _metadataExporter;

        public bool HttpGetEnabled { get; set; }
        public Uri HttpGetUrl { get; set; }

        public MetadataExporter MetadataExporter
        {
            get => _metadataExporter ?? (_metadataExporter = new WsdlExporter());
            set => _metadataExporter = value;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }
}