using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Net;
using System.IO;
using System.Reflection;
using System.Json;
using Yunan.WPF.ImageAnim;
using System.Windows.Interop;

namespace LOL10MINUTES
{
    /// <summary>
    /// Interaction logic for LolNexus.xaml
    /// </summary>
    public partial class LolNexus : MetroWindow
    {

        string summonerinfo;
        string json2;
        List<string> Detalhes = new List<string>();
        List<string> Detalhes2 = new List<string>();
        List<string> Detalhes3 = new List<string>();
        string GAMEDATA;
        JsonValue data;
        string doublejson;
        JsonValue data2;
        List<string> Summoner1 = new List<string>();
        List<string> Summoner2 = new List<string>();
        List<string> Summoner3 = new List<string>();
        List<string> Summoner4 = new List<string>();
        List<string> Summoner5 = new List<string>();
        List<string> Summoner6 = new List<string>();
        List<string> Summoner7 = new List<string>();
        List<string> Summoner8 = new List<string>();
        List<string> Summoner9 = new List<string>();
        List<string> Summoner10 = new List<string>();
        string RANKROMANO;
        string RANKLIGA;
        string TEXTOHTTP;
        List<string> info = new List<string>();
        string textotodo;
        string Liga;
        public LolNexus()
        {
            InitializeComponent();


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.Visibility = Visibility.Hidden;
            textBox.Visibility = Visibility.Hidden;
            vermelha.Visibility = Visibility.Visible;
            azul.Visibility = Visibility.Visible;

            ObterDataDaMatch("nao");
            MatchDataParse(GAMEDATA);
            SummonerParse();
            
        }

        //REFERENCIAS
        /*
        https://euw.api.pvp.net/observer-mode/rest/consumer/getSpectatorGameInfo/EUW1/[ID DO JOGADOR]?api_key=067c7765-e085-4a55-83f1-be65b5869416
        */
        public void ObterDataDaMatch(string name)
        {
            WebClient Cliente = new WebClient();
            //start try
            try
            {
                summonerinfo = Cliente.DownloadString("https://euw.api.pvp.net/api/lol/euw/v1.4/summoner/by-name/" + textBox.Text + "?api_key=067c7765-e085-4a55-83f1-be65b5869416");
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    MessageBox.Show("SUMMONER NAO EXISTE!");
                    return;
                }

            }
            try
            {
                JsonValue value = JsonValue.Parse(summonerinfo);
                foreach (var ze in value) { json2 = ze.Value.ToString(); }
                data = JsonValue.Parse(json2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            foreach (var valor in data)
            {
                Detalhes.Add(valor.Value.ToString());
            }
            try
            {
                GAMEDATA = Cliente.DownloadString("https://euw.api.pvp.net/observer-mode/rest/consumer/getSpectatorGameInfo/EUW1/" + Detalhes.ToArray()[0].ToString() + "?api_key=067c7765-e085-4a55-83f1-be65b5869416");
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    MessageBox.Show(Detalhes.ToArray()[1].ToString() + " is not in game!");
                }
            }

        }

        public void MatchDataParse(string DATA)
        {
            JsonValue brute = JsonValue.Parse(DATA);
            foreach (var lo in brute) { doublejson = lo.Value.ToString(); Detalhes2.Add(lo.Value.ToString()); }
            data2 = JsonValue.Parse(Detalhes2.ToArray()[5].ToString());
            foreach (var li in data2)
            {
                Detalhes3.Add(li.Value.ToString());


            }
            int a = 0;
            foreach (string i in Detalhes3)
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\" + a + "summoner.txt", i.ToString());
                a++;
            }

        }

        public void SummonerParse()
        {
            JsonValue S1 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\0summoner.txt"));
            foreach (var po in S1)
            {
                Summoner1.Add(po.Value.ToString());

            }
            label.Content = Summoner1.ToArray()[5].ToString().Replace("\"", "");
            Summoner1Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner1.ToArray()[1].ToString() + ".png"));
            Summoner1Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner1.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner1.ToArray()[4].ToString()));
            Summoner1Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner1.ToArray()[4].ToString() + ".png"));
            ObterInformacao(label.Content.ToString());
            ObterLiga(info.ToArray()[0].ToString());// ---------------------------------------ERRO---------------------------//
            Summoner1Rank.Content = Liga;

            //--------------------------------------------
            JsonValue S2 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\1summoner.txt"));
            foreach (var po in S2)
            {
                Summoner2.Add(po.Value.ToString());

            }
            label_Copy.Content = Summoner2.ToArray()[5].ToString().Replace("\"", "");
            Summoner2Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner2.ToArray()[1].ToString() + ".png"));
            Summoner2Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner2.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner2.ToArray()[4].ToString()));
            Summoner2Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner2.ToArray()[4].ToString() + ".png"));
            //--------------------------------------------
            //--------------------------------------------
            JsonValue S3 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\2summoner.txt"));
            foreach (var po in S3)
            {
                Summoner3.Add(po.Value.ToString());

            }
            label_Copy1.Content = Summoner3.ToArray()[5].ToString().Replace("\"", "");
            Summoner3Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner3.ToArray()[1].ToString() + ".png"));
            Summoner3Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner3.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner3.ToArray()[4].ToString()));
            Summoner3Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner3.ToArray()[4].ToString() + ".png"));
            //--------------------------------------------
            //--------------------------------------------
            JsonValue S4 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\3summoner.txt"));
            foreach (var po in S4)
            {
                Summoner4.Add(po.Value.ToString());

            }
            label_Copy2.Content = Summoner4.ToArray()[5].ToString().Replace("\"", "");
            Summoner4Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner4.ToArray()[1].ToString() + ".png"));
            Summoner4Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner4.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner4.ToArray()[4].ToString()));
            Summoner4Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner4.ToArray()[4].ToString() + ".png"));
            //--------------------------------------------
            //--------------------------------------------
            JsonValue S5 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\4summoner.txt"));
            foreach (var po in S5)
            {
                Summoner5.Add(po.Value.ToString());

            }
            label_Copy3.Content = Summoner5.ToArray()[5].ToString().Replace("\"", "");
            Summoner5Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner5.ToArray()[1].ToString() + ".png"));
            Summoner5Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner5.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner5.ToArray()[4].ToString()));
            Summoner5Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner5.ToArray()[4].ToString() + ".png"));
            //--------------------------------------------
            //--------------------------------------------
            JsonValue S6 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\5summoner.txt"));
            foreach (var po in S6)
            {
                Summoner6.Add(po.Value.ToString());

            }
            label_Copy4.Content = Summoner6.ToArray()[5].ToString().Replace("\"", "");
            Summoner6Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner6.ToArray()[1].ToString() + ".png"));
            Summoner6Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner6.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner6.ToArray()[4].ToString()));
            Summoner6Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner6.ToArray()[4].ToString() + ".png"));
            //--------------------------------------------
            //--------------------------------------------
            JsonValue S7 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\6summoner.txt"));
            foreach (var po in S7)
            {
                Summoner7.Add(po.Value.ToString());

            }
            label_Copy5.Content = Summoner7.ToArray()[5].ToString().Replace("\"", "");
            Summoner7Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner7.ToArray()[1].ToString() + ".png"));
            Summoner7Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner7.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner7.ToArray()[4].ToString()));
            Summoner7Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner7.ToArray()[4].ToString() + ".png"));
            //--------------------------------------------
            //--------------------------------------------
            JsonValue S8 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\7summoner.txt"));
            foreach (var po in S8)
            {
                Summoner8.Add(po.Value.ToString());

            }
            label_Copy6.Content = Summoner8.ToArray()[5].ToString().Replace("\"", "");
            Summoner8Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner8.ToArray()[1].ToString() + ".png"));
            Summoner8Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner8.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner8.ToArray()[4].ToString()));
            Summoner8Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner8.ToArray()[4].ToString() + ".png"));
            //--------------------------------------------
            //--------------------------------------------
            JsonValue S9 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\8summoner.txt"));
            foreach (var po in S9)
            {
                Summoner9.Add(po.Value.ToString());

            }
            label_Copy7.Content = Summoner9.ToArray()[5].ToString().Replace("\"", "");
            Summoner9Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner9.ToArray()[1].ToString() + ".png"));
            Summoner9Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner9.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner9.ToArray()[4].ToString()));
            Summoner9Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner9.ToArray()[4].ToString() + ".png"));
            //--------------------------------------------
            //--------------------------------------------
            JsonValue S10 = JsonValue.Parse(File.ReadAllText(Directory.GetCurrentDirectory() + "\\9summoner.txt"));
            foreach (var po in S10)
            {
                Summoner10.Add(po.Value.ToString());

            }
            label_Copy8.Content = Summoner10.ToArray()[5].ToString().Replace("\"", "");
            Summoner10Sp1.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner10.ToArray()[1].ToString() + ".png"));
            Summoner10Sp2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Spells\\" + Summoner10.ToArray()[2].ToString() + ".png"));
            GetIcon(Int32.Parse(Summoner10.ToArray()[4].ToString()));
            Summoner10Icon.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\Icons\\" + Summoner10.ToArray()[4].ToString() + ".png"));

            //--------------------------------------------
            //--------------------------------------------
        }
        private void GetIcon(int number)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\Icons\\" + number + ".png"))
            {

                WebClient joao = new WebClient();
                string text = joao.DownloadString("http://ddragon.leagueoflegends.com/realms/euw.json").ToString();
                string[] URL = text.Split(':');
                // url[8] da me isto "4.21.5","l"298
                string[] bom = URL[8].Split('"');
                // bom[1] da me isto 4.21.5

                joao.DownloadFile("http://ddragon.leagueoflegends.com/cdn/" + bom[1] + "/img/profileicon/" + number + ".png ", Directory.GetCurrentDirectory() + "\\Icons\\" + number + ".png");// AQUIAQUI
            }
        }

       public void ObterLiga(string id) // UGLY HACK AHEAD!!!
        {
            MessageBox.Show(id);
            WebClient web = new WebClient();
            try
            {
                TEXTOHTTP = web.DownloadString("https://euw.api.pvp.net/api/lol/euw/v2.5/league/by-summoner/" + id + "/entry?api_key=067c7765-e085-4a55-83f1-be65b5869416");
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    MessageBox.Show("O jogador ainda nao e LvL30!");//UNRANKED!
                }
            }
            string[] textoseparado = TEXTOHTTP.Split(':');
            // apanho isto  "IV", "isInactive"
            string[] ranknumero = textoseparado[8].Split('"');
            //apanho isto IV
            RANKROMANO = ranknumero[1];
            string[] rankliga = textoseparado[3].Split('"');
            RANKLIGA = rankliga[1];
            string Liga = RANKLIGA + " " + RANKROMANO;



        }


        public void ObterInformacao(string summonername)
        {

            
            WebClient web = new WebClient();
            try
            {
                textotodo = web.DownloadString("https://euw.api.pvp.net/api/lol/euw/v1.4/summoner/by-name/" + summonername + "?api_key=067c7765-e085-4a55-83f1-be65b5869416");
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    MessageBox.Show("Unranked");//UNRANKED!
                }
            }
            JsonValue data = JsonValue.Parse(textotodo);
            foreach (var campo in data)
            {
                info.Add(campo.Value.ToString());
            }
            JsonValue data2 = JsonValue.Parse(info.ToArray()[0].ToString());
            foreach (var le in data2)
            {
                info.Add(le.Value.ToString());
                

            }
           //[0]- id [1]- name
        }
        

    }
}

        /*private void ObterLiga(string nome)
        {
            
            WebClient web = new WebClient();
            try
            {
                TEXTOHTTP = web.DownloadString("https://euw.api.pvp.net/api/lol/euw/v2.5/league/by-summoner/" + nome + "/entry?api_key=067c7765-e085-4a55-83f1-be65b5869416");
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    MessageBox.Show("O jogador ainda nao e LvL30!");//UNRANKED!
                }
            }
            
            JsonValue players = JsonValue.Parse(TEXTOHTTP);
            foreach(var ze in players)
            {
                pone = ze.Value.ToString();
            }
            JsonValue ki = JsonValue.Parse(pone);
            foreach(var tu in ki)
            {
                //Se tiver String summoner name
                MessageBox.Show(tu.Value.ToString());
            }
        }
        */



//Obter liga do LOLSUMMONERINFO


/*
    \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
     if(jogador == 1)
            {

            }
            if(jogador == 2)
            {

            }
            if (jogador == 3)
            {

            }
            if (jogador == 4)
            {

            }
            if (jogador == 5)
            {

            }
            if (jogador == 6)
            {

            }
            if (jogador == 7)
            {

            }
            if (jogador == 8)
            {

            }
            if (jogador == 9)
            {

            }
            if (jogador == 10)
            {

            }
    */

