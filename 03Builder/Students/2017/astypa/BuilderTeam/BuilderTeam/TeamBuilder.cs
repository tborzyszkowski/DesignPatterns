using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTeam
{
    public class TeamBuilder
    {
        string Name { get; set; }
        string TrenerName { get; set; }
        Color ShirtColor { get; set; }
        string City { get; set; }
        string Type { get; set; }

        public TeamBuilder CreateTeam(string name)
        {
            this.Name = name;
            return this;
        }

        public TeamBuilder WithTrener(string trenerName)
        {
            this.TrenerName = trenerName;
            return this;
        }

        public TeamBuilder WithShirtColor(Color color)
        {
            this.ShirtColor = color;
            return this;
        }

        public TeamBuilder WithCity (string city)
        {
            this.City = city;
            return this;
        }

        public TeamBuilder AndType(string type)
        {
            this.Type = type;
            return this;
        }

        public Team Build()
        {
            return new Team(Name, TrenerName, ShirtColor, City, Type);
        }

        //conversion operator
        public static implicit operator Team(TeamBuilder tb)
        {
            return new Team(
                tb.Name,
                tb.TrenerName,
                tb.ShirtColor,
                tb.City,
                tb.Type);
        }

    }
}
