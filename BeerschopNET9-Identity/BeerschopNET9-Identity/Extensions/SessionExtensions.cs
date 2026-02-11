using Newtonsoft.Json;

namespace BeerschopNET9_Identity.Extensions
{
    // static  -> Kan niet geïnstantieerd worden
    // Als je een extension methode wilt, dan moet je static gebruiken. Static betekent: Dit hoort bij de class zelf, niet bij een object (instance) van die class.
    // Je kan dus je methode uitvoeren zonder een object aan te maken
    public static class SessionExtensions
    {
        // Extension methods, as the name suggests, are additional methods.
        // Extension methods allow you to inject additional methods
        // without modifying, deriving or 
        // recompiling the original class, struct or interface.


        public static void SetObject(this ISession session, string key
            , object? value)
        {

            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key); // Json-Object
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            //}
        }

    }
}