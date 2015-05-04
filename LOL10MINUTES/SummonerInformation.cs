using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Json;

namespace LOL10MINUTES
{
    class SummonerInformation
    {
        string textotodo;

        public void ObterInformacao(string summonername)
        {
            
            List<string> info = new List<string>();
            WebClient web = new WebClient();
            try
            {
                textotodo = web.DownloadString("https://euw.api.pvp.net/api/lol/euw/v1.4/summoner/by-name/" + summonername + "?api_key=067c7765-e085-4a55-83f1-be65b5869416");
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    MessageBox.Show("O jogador ainda nao e LvL30!");//UNRANKED!
                }
            }
            JsonValue data = JsonValue.Parse(textotodo);
            foreach(var campo in data)
            {
                info.Add(campo.Value.ToString());
            }
            JsonValue data2 = JsonValue.Parse(info.ToArray()[0].ToString());
            foreach (var le in data2)
            {
                info.Add(le.Value.ToString());
               
            }
            //info.ToArray()[1].ToString();
        }

    }
}
