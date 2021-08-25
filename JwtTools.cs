using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace WebApi
{
    public class JwtTools
    {
        public static string Key { get; set; } = "Hellow";

        public static string Encoder(Dictionary<string, object> payload, string key = null) {
            if (string.IsNullOrEmpty(key)) {
                key = Key;
            }
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            payload.Add("timeout", DateTime.Now.AddDays(1));
            var token = encoder.Encode(payload, key);
            return token.Length > 0 ? token : "Error";
        }
        public static Dictionary<string, object> Decode(string iwtStr, string key = null) 
        {
            if (string.IsNullOrEmpty(key))
            {
                key = Key;
            }
            try { 
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, urlEncoder);
            var json = decoder.Decode(iwtStr, key,verify:true);
            var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                if ((DateTime)result["timeout"] < DateTime.Now) {
                    throw new Exception("登录过期，请重新登录");
                }
                result.Remove("timeout");
                return result;
            }
            catch (TokenExpiredException)
            {
                throw;
            }
        }
    }
}