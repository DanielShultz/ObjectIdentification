using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectIdentification
{
    public class QuestionRoadSign
    {
        RoadSign main;
        RoadSign second;
        RoadSign additional;
        int random;
        Random rnd = new Random();

        public QuestionRoadSign(RoadSign main, RoadSign second)
        {
            this.main = main;
            this.second = second;
            this.additional = second;
            random = rnd.Next(0, 4);
        }
        public QuestionRoadSign(RoadSign main, RoadSign second, RoadSign additional)
        {
            this.main = main;
            this.second = second;
            this.additional = additional;
            random = rnd.Next(0, 4);
        }
        public RoadSign First()
        {
            if (random == 0)
            {
                return second;
            }
            else
            {
                if (random == 1)
                {
                    return additional;
                }
                return main;
            }
        }
        public RoadSign Second()
        {
            if (random == 2)
            {
                return second;
            }
            else
            {
                if (random == 3)
                {
                    return additional;
                }
                return main;
            }
        }
        public string[] Names()
        {
            if (second.name == additional.name)
            {
                return (new string[] { main.name, second.name});
            }
            else
            {
                return (new string[] { main.name, second.name, additional.name });
            }
        }
    }
}
