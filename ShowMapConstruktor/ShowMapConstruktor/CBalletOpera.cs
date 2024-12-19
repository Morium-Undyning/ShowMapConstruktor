using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShowMapConstruktor
{
    public class CBalletOpera : CMusicShow
    {
        

        public bool isBalletorForNigth { get; private set; }

       

        public string typeMusicShowOrOriginOrGenresOfMusic { get; private set; }

        public CBalletOpera(string cityName, string misucShowName, string nameMisucPlace, string misucGroup, string dateMisucPlace,bool isBalletorForNigth, string typeMusicShowOrOriginOrGenresOfMusic) : base(cityName, misucShowName, nameMisucPlace, misucGroup, dateMisucPlace)
        {
            this.typeMusicShowOrOriginOrGenresOfMusic = typeMusicShowOrOriginOrGenresOfMusic;
            this.isBalletorForNigth = isBalletorForNigth;
        }
    }
}
