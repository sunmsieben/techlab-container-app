using System.Configuration;
using Azure;
using Azure.Identity;

namespace Gateways.GatewayApi.DataDelivery.Configuration;

public static class KeyvaultConfig
{
    public static void AddKeyVault(this IConfigurationBuilder builder)
    {
        try
        {
            var keyVaultName = builder.Build()["KeyVaultName"];

            var keyVaultUri = $"https://{keyVaultName}.vault.azure.net/";

            var credential = new ChainedTokenCredential(new DefaultAzureCredential(), new EnvironmentCredential());

            builder.AddAzureKeyVault(new Uri(keyVaultUri), credential);
        }
        catch (RequestFailedException rfe)
        {
            var message = "unable to connect to azure keyvault";
#if DEBUG
            message += "ensure that you are logged into visual studio with your FAM_ACCOUNT " +
                       "under (tools -> options -> azureservicesubscription) if that doesn't work, " +
                       "ensure that you are authorized to access the keyvault in the azure portal)";
#endif

            throw new ConfigurationErrorsException(message, rfe);
        }
    }
}