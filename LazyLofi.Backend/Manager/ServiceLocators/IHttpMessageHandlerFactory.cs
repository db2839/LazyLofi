using System.Net.Http;

namespace LazyLofi.Backend.Manager.ServiceLocators
{
    internal interface IHttpMessageHandlerFactory
    {
        HttpMessageHandler CreateHttpMessageHandler();
    }
}