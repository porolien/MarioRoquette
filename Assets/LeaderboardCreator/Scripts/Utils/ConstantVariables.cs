using Dan.Enums;

namespace Dan
{
    internal static class ConstantVariables
    {
        internal const string GUID_KEY = "ca06c234e4013f92c018675b676afb30f4cf492bc3cce1d5cbbbbb48799b769b";
        
        internal static string GetServerURL(Routes route = Routes.None, string extra = "")
        {
            return SERVER_URL + (route == Routes.Authorize ? "/authorize" :
                route == Routes.Get ? "/get" :
                route == Routes.Upload ? "/entry/upload" :
                route == Routes.UpdateUsername ? "/entry/update-username" :
                route == Routes.DeleteEntry ? "/entry/delete" :
                route == Routes.GetPersonalEntry ? "/entry/get" : "/") + extra;
        }

        private const string SERVER_URL = "https://lcv2-server.danqzq.games";
    }
}