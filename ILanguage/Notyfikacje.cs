using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using System.Threading.Tasks;

namespace ILanguage
{
    public static class Notyfikacje
    {
        static List<String> dane = new List<String>();
        static int i = 0;

        static ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
        static XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

        public static async void wczytajDane()//wczytuje dane i od razu formatuje "slowo1 - slowo2"
        {            
            var path = @"Dane\slownik.txt";
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            var file = await folder.GetFileAsync(path);
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);

            foreach (var line in readFile)
            {
                string[] pom = line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                String p = pom[0] + " - " + pom[1];
                dane.Add(p);
                i++;
            }
        }

        public async static void wyswietlaj(int n, int przerwa){
            for (int i = 0; i < n; i++)
            {
                wyswietlNotyfikacje();
                await(Task.Delay(przerwa*1000));
            }
        }

        public static void wyswietlNotyfikacje(){

            XmlNodeList toastTextAttributes = toastXml.GetElementsByTagName("text");

            String napis;
            
            //losowanie
            Random r = new Random();
            int x = r.Next(0, i);

            try
            {
                napis = dane[x];
            }
            catch (Exception) {
                napis = "Pusty słownik.";
            };

            
            toastTextAttributes[0].InnerText = napis;

            //okreslenie kiedy ma sie pojawic:
            Int16 odstepSek = 1;
            DateTime dueTime = DateTime.Now.AddSeconds(odstepSek);

            ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toastXml, dueTime);
            ToastNotifier notifier = ToastNotificationManager.CreateToastNotifier();
            notifier.AddToSchedule(scheduledToast);

        }

    }
}
