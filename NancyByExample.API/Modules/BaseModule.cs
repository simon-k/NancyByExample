using Nancy;

namespace NancyByExample.API.Modules
{
    public class BaseModule : NancyModule
    {
        public BaseModule()
        {
            Get["/"] = Alive;
        }

        public Response Alive(dynamic parameters)
        {
            return "I'm alive!";
        }
    }
}
