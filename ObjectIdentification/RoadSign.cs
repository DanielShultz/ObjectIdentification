using System.Drawing;

namespace ObjectIdentification
{
    public class RoadSign
    {
        public Image day;
        public Image night;
        public string name;
        public RoadSign(Image day, Image night, string name)
        {
            this.day = day;
            this.night = night;
            this.name = name;
        }
    }
}
