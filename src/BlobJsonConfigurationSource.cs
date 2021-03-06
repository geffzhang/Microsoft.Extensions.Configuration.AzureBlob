﻿using Microsoft.Extensions.Configuration.Json;
using System;

namespace Microsoft.Extensions.Configuration.AzureBlob
{
    public class BlobJsonConfigurationSource : JsonConfigurationSource
    {
        internal BlobAccessor BlobAccessor { get; set; }
        internal BlobJsonConfigurationOption Option { get; set; }

        public BlobJsonConfigurationSource(BlobJsonConfigurationOption option)
        {
            Option = option ?? throw new ArgumentNullException(nameof(option));

            var account = BlobJsonConfigurationOption.GetAccount(option.BlobUri);

            BlobAccessor = BlobAccessor.Create(option.BlobUri, account, option.SASToken);
        }

        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new BlobJsonConfigurationProvider(this);
        }
    }
}
