using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Market.Core.Application.Helper
{
    public static class session
    {
        public static void set<T>(this ISession sesion, string key, T value) 
        {
            sesion.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T get<T>(this ISession sesion, string key)
        {
            var value = sesion.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
