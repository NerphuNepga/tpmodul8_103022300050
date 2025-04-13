using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300050
{
    internal class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
        
        public CovidConfig() { }

        public CovidConfig(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
    }
    class UIConfig
    {
        public CovidConfig covidConfig;
        public const string filePath = "C:\\benkyou, study me\\C#\\Konstruksi Perangkat Lunak\\tpmodul8_103022300050\\covid_config.json";
        public UIConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        private CovidConfig ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            covidConfig = JsonSerializer.Deserialize<CovidConfig>(configJsonData);
            return covidConfig;
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(covidConfig, options);
            File.WriteAllText(filePath, jsonString);
        }
        private void SetDefault()
        {
            covidConfig = new CovidConfig()
            {
                satuan_suhu = "celcius",
                batas_hari_demam = 14,
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            };
        }
        public void UbahSatuan()
        {
            if (covidConfig.satuan_suhu == "celcius")
            {
                covidConfig.satuan_suhu = "fahrenheit";
            }
            else
            {
                covidConfig.satuan_suhu = "celcius";
            }
            WriteNewConfigFile();
            Console.WriteLine($"Satuan suhu telah diubah menjadi: {covidConfig.satuan_suhu}");
        }
    }
}
