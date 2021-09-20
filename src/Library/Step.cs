//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Recipies
{
    public class Step : IJsonConvertible
    {
        [JsonConstructor]
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Step(string json)
        {
            this.LoadFromJson(json);
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }

        public string ConvertToJson()
        {
            return JsonSerializer.Serialize<Step>(this);
        }

        public void LoadFromJson(string json)
        {
            Step temp = new Step(JsonSerializer.Deserialize<string>(json));
            this.Quantity = temp.Quantity;
            this.Input = temp.Input;
            this.Time = temp.Time;
            this.Equipment = temp.Equipment;
        }
    }
}