namespace api_net_csharp_rest_webapi.Services
{
    //class
    public class HelloWorldService : IHelloWorldService
    {
        public HelloWorldService(
        ){
        }

        public  string GetHelloWorld()
        {
            return "Hola mundo";
        }
    }

    //Interfas
    public interface IHelloWorldService
    {
        string GetHelloWorld();
    }

}
