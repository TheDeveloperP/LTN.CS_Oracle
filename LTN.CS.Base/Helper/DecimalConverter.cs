// ***********************************************************************
// Copyright (c) 2016 江苏金恒,All rights reserved.
// Assembly:LTN.CS.Core.Helper
// Author:kolio
// Created:2016/11/23 10:11:46
// Description:
// ***********************************************************************
// Last Modified By:kolio
// Last Modified On:2016/11/23 10:11:46
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LTN.CS.Core.Helper;

namespace LTN.CS.Base.Helper
{
    public class DecimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            bool rs = (objectType == typeof(decimal) || objectType == typeof(decimal?));
            return rs;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
            {
                var rs = token.ToObject<decimal>();
                return rs;
            }
            if (token.Type == JTokenType.String)
            {
                // customize this to suit your needs
                return Decimal.Parse(token.ToString(),
                       System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
            }
            if (token.Type == JTokenType.Null && objectType == typeof(decimal?))
            {
                return null;
            }
            throw new JsonSerializationException("Unexpected token type: " +
                                                  token.Type.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Decimal? d = default(Decimal?);
            if (value != null)
            {
                d = value as Decimal?;
                if (d.HasValue) // If value was a decimal?, then this is possible
                {
                    d = new Decimal?(new Decimal(Decimal.ToDouble(d.Value))); // The ToDouble-conversion removes all unnessecary precision
                }
            }
            JToken.FromObject(d).WriteTo(writer);
        }

    }
}
