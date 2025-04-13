// See https://aka.ms/new-console-template for more information
using tpmodul8_103022300050;

UIConfig config = new UIConfig();

Console.WriteLine("(HASIL DESERIALISASI)");
Console.WriteLine("Satuan Suhu     : " + config.covidConfig.satuan_suhu);
Console.WriteLine("Batas Hari Demam: " + config.covidConfig.batas_hari_demam);
Console.WriteLine("Pesan Ditolak   : " + config.covidConfig.pesan_ditolak);
Console.WriteLine("Pesan Diterima  : " + config.covidConfig.pesan_diterima);

config.UbahSatuan();

try
{
    Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.covidConfig.satuan_suhu}: ");
    double suhu = double.Parse(Console.ReadLine());

    Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
    int hariDemam = int.Parse(Console.ReadLine());

    bool suhuValid;
    if (config.covidConfig.satuan_suhu == "celcius")
    {
        suhuValid = suhu >= 36.5 && suhu <= 37.5;
    }
    else
    {
        suhuValid = suhu >= 97.7 && suhu <= 99.5;
    }

    bool demamValid = hariDemam < config.covidConfig.batas_hari_demam;

    if (suhuValid && demamValid)
    {
        Console.WriteLine(config.covidConfig.pesan_diterima);
    }
    else
    {
        Console.WriteLine(config.covidConfig.pesan_ditolak);
    }
}
catch
{
    Console.WriteLine("Input tidak valid. Harap masukkan angka yang benar.");
}