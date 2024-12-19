using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShowMapConstruktor
{
    internal class CMusicShowList
    {
        private readonly ISaveList<List<CMusicShow>> _serialzer = new JsonMusicSaver();
        private List<CMusicShow> musicShow;
        public CMusicShowList() 
        {
            musicShow = new List<CMusicShow>();
        }

        public List<CMusicShow> GetShows() 
        {
            return musicShow;
        }

        public void AddShow(string cityName, string misucShowName, string nameMisucPlace, string misucGroup, string dateMisucPlace, double posOfMapX, double posOfMapY, int musicIndex, string typeMusicShowOrOriginOrGenresOfMusic, bool isBalletor, bool forNigth)
        {
            switch (musicIndex)
            {
                
                case 2:
                    musicShow.Add(new CRockConcert(cityName, misucShowName, nameMisucPlace, misucGroup, dateMisucPlace, posOfMapX, posOfMapY, typeMusicShowOrOriginOrGenresOfMusic, forNigth)); 
                    break;
                case 1:
                    musicShow.Add(new CBalletOpera(cityName, misucShowName, nameMisucPlace, misucGroup, dateMisucPlace,posOfMapX, posOfMapY, isBalletor, typeMusicShowOrOriginOrGenresOfMusic));
                    break;
                case 0:
                    musicShow.Add(new CDefaultMusicShow(cityName, misucShowName, nameMisucPlace,  misucGroup, posOfMapX, posOfMapY, dateMisucPlace, typeMusicShowOrOriginOrGenresOfMusic));
                    break;


            }
        }

        public CMusicShow GetMusicShowByName(string misucShow)
        {
            return musicShow.Find(musics => musics.misucShowName.Equals(misucShow, StringComparison.OrdinalIgnoreCase));
        }

        public CMusicShow GetMusicShowByIndex(int index)
        {
            if (index < 0 || index >= musicShow.Count)
            {
                return null;
            }
            return musicShow[index];
        }

        public void DeleteMusicShowByName(string misucShow)
        {
            musicShow.RemoveAll(musics => musics.misucShowName.Equals(misucShow, StringComparison.OrdinalIgnoreCase));
        }

        public void DeleteMusicShowIndex(int index)
        {
            if (index >= 0 && index < musicShow.Count)
            {
                musicShow.RemoveAt(index);
            }
        }

        public List<string> GetListOfMusicShowNames()
        {
            return musicShow.ConvertAll(musics => musics.misucShowName);
        }

        public void SaveToJson(string path)
        {
            _serialzer.Save(musicShow, path);
        }

        public void LoadFromJson(string path)
        {
            musicShow = _serialzer.Load(path);
        }

    }
}
