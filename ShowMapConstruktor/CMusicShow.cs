using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Windows;

namespace ShowMapConstruktor
{
    public abstract class CMusicShow
    {
        [JsonInclude]
        public string cityName { get; private set; }

        [JsonInclude]
        public string misucShowName { get; private set; }

        [JsonInclude]
        public string nameMisucPlace { get; private set; }

        [JsonInclude]
        public string misucGroup { get; private set; }

        [JsonInclude]
        public string dateMisucPlace { get; private set; }

        [JsonInclude]
        public double posOfMapX { get; private set; }

        [JsonInclude]
        public double posOfMapY { get; private set; }



        protected CMusicShow(string cityName, string misucShowName, string nameMisucPlace, string misucGroup,string dateMisucPlace,double posOfMapX,double posOfMapY) 
        {
            this.cityName = cityName;
            this.misucShowName = misucShowName;
            this.nameMisucPlace = nameMisucPlace;
            this.misucGroup = misucGroup;
            this.dateMisucPlace = dateMisucPlace;
            this.posOfMapX = posOfMapX;
            this.posOfMapY = posOfMapY;


        }

    }
}
