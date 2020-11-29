using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace botDBUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[,] fulltablearray { get; set; }
        public int linenumber { get; set; }
        public string[,] picturetoname { get; set; }
        public int length { get; set; }

        private void Fulltable()//формирование таблицы из исходных файлов
        {
            string commonpath = @"C:\Bot\NewRqPL12\";
            linenumber = 0;
            using (StreamReader sr = new StreamReader(commonpath + "manufacturer.txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    linenumber++;
                }
                sr.Close();
            }
            fulltablearray = new string[linenumber, 18];

            string[] SR(string path)
            {
                string[] a = new string[linenumber];
                using (StreamReader sr = new StreamReader(commonpath + path + ".txt", System.Text.Encoding.Default))
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        a[i] = sr.ReadLine();
                    }
                    sr.Close();
                }
                return a;
            } //считывание статов из файлов
            string[] cashSR()
            {
                string[] a = new string[linenumber];
                if (File.Exists(@"C:\Bot\NewRqPL12\CashCarsPL12.txt"))
                {
                    using (StreamReader sr = new StreamReader(@"C:\Bot\NewRqPL12\CashCarsPL12.txt", System.Text.Encoding.Default))
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            a[i] = sr.ReadLine();
                        }
                        sr.Close();
                    }
                }
                else
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        a[i] = "0";
                    }
                }
                return a;
            } //удалить после обновы наличие автомобилей, переписать файл с нуля

            string[] acc = SR("acceleration");
            string[] body = SR("body");
            string[] grade = SR("class");
            string[] clearance = SR("clearance");
            string[] country = SR("country");
            string[] drive = SR("drive");
            string[] fuel = SR("fuel");
            string[] grip = SR("grip");
            string[] manufacturer = SR("manufacturer");
            string[] model = SR("model");
            string[] rq = SR("rq");
            string[] seats = SR("seats");
            string[] speed = SR("speed");
            string[] tires = SR("tires");
            string[] weight = SR("weight");
            string[] year = SR("year");
            string[] cash = cashSR();
            string[] tags = SR("tags");

            for (int i = 0; i < linenumber; i++)
            {
                fulltablearray[i, 0] = acc[i];
                fulltablearray[i, 1] = body[i];
                fulltablearray[i, 2] = grade[i];
                fulltablearray[i, 3] = clearance[i];
                fulltablearray[i, 4] = country[i];
                fulltablearray[i, 5] = drive[i];
                fulltablearray[i, 6] = fuel[i];
                fulltablearray[i, 7] = grip[i];
                fulltablearray[i, 8] = manufacturer[i];
                fulltablearray[i, 9] = model[i];
                fulltablearray[i, 10] = rq[i];
                fulltablearray[i, 11] = seats[i];
                fulltablearray[i, 12] = speed[i];
                fulltablearray[i, 13] = tires[i];
                fulltablearray[i, 14] = weight[i];
                fulltablearray[i, 15] = year[i];
                fulltablearray[i, 16] = cash[i];
                fulltablearray[i, 17] = tags[i];
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Bot\fulltabletestPL12.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < linenumber; i++)
                {
                    for (int j = 0; j < 17; j++)
                    {
                        if (j > 0)
                        {
                            sw.Write(" ");
                        }
                        sw.Write(fulltablearray[i, j]);
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }

            Filter();
        }        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label52.Text = "default";
            label49.Text = "default";
            System.Object[] DEcars = { "Audi", "BMW", "Gumpert", "Mercedes-Benz", "Porsche", "Vauxhall", "Volkswagen", "Mini", "RUF", "Smart" };
            System.Object[] GBcars = { "Ariel", "Aston Martin", "Austin", "Bentley", "Caterham", "Ford", "Jaguar", "Land Rover",
                                       "Lotus", "McLaren", "MG", "Rover", "TVR", "Vauxhall"};
            System.Object[] FRcars = { "Bugatti", "Citroen", "DS", "Peugeot", "Renault" };
            System.Object[] ITcars = { "Alfa Romeo", "Fiat", "Lamborghini", "Lancia", "Maserati", "Pagani", "De Tomaso" };
            System.Object[] JPcars = { "Honda", "Infiniti", "Mazda", "Mitsubishi", "Nissan", "Subaru", "Suzuki" };
            System.Object[] UScars = { "Acura", "Buick", "Cadillac", "Chevrolet", "Chrysler", "Dodge", "Ford", "GMC", "Hummer",
                                        "Plymouth", "Pontiac", "Ram", "Scuderia Cameron Glickenhaus", };
            System.Object[] ATcars = { "KTM" };
            System.Object[] SEcars = { "Volvo", "Koenigsegg" };
            System.Object[] AUcars = { "Vauxhall" };
            System.Object[] HRcars = { "Rimac" };
            System.Object[] NLcars = { "Donkervoort", "Spyker" };
            comboBox2.Items.Clear();
            comboBox2.Text = null;
            comboBox3.Items.Clear();
            comboBox3.Text = null;
            switch (comboBox1.Text)
            {
                case "DE":
                    comboBox2.Items.AddRange(DEcars);
                    break;
                case "GB":
                    comboBox2.Items.AddRange(GBcars);
                    break;
                case "US":
                    comboBox2.Items.AddRange(UScars);
                    break;
                case "IT":
                    comboBox2.Items.AddRange(ITcars);
                    break;
                case "JP":
                    comboBox2.Items.AddRange(JPcars);
                    break;
                case "FR":
                    comboBox2.Items.AddRange(FRcars);
                    break;
                case "SE":
                    comboBox2.Items.AddRange(SEcars);
                    break;
                case "AT":
                    comboBox2.Items.AddRange(ATcars);
                    break;
                case "AU":
                    comboBox2.Items.AddRange(AUcars);
                    break;
                case "HR":
                    comboBox2.Items.AddRange(HRcars);
                    break;
                case "NL":
                    comboBox2.Items.AddRange(NLcars);
                    break;
                default:
                    break;
            }
        } //дописывать марки вручную, PL12

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label52.Text = "default";
            label49.Text = "default";
            System.Object[] Acuracars = { "Integra GS-R 1994", "Legend 3.2 V6 1990", "NSX 2016", "NSX-T 1998" };
            System.Object[] AlfaRomeocars = { "33 1993", "75 1985", "90 1984", "146 1996", "155 1992", "159 2005", "166 1998", "145 Cloverleaf 1994", "147 GTA 2002", "155 TS BTCC 1994", "156 GTA 2002", "164 ProCar 1988", "164 Super 1993", "1750 GTV 1967", "2000 GTV 1971", "2000 Sportiva 1954", "2600 SZ 1965", "4C 2017", "6C 2500 Villa d'Este 1949", "8C Competizione 2007", "8C Spider 2010", "Alfa 6 1980", "Alfasud 1982", "Alfasud Sprint 1976", "Alfetta GT Rally Version 1975", "Alfetta GTV 1976", "Autodelta 156 GTA 3.7 V6 2004", "Brera S 2008", "Carabo 1968", "Disco Volante (8C) 2013", "Disco Volante (C52) 1952", "Giulia GTA Stradale 1965", "Giulia Quadrifoglio 2017", "Giulia TZ 1963", "Giulia Veloce 2017", "Giulietta 2017", "Giulietta Spider 1955", "GT 2003", "GT 1600 Junior 1972", "GTA 1300 Junior 1968", "GTV 1998", "Mito 2017", "MiTo GTA 2009", "Montreal 1970", "Scighera 1997", "Spider 2006", "Spider (S1) 1969", "Spider (S3) 1983", "Spider (S4) 1990", "Spider Veloce (S2) 1971", "Sprint GT 1963", "Sprint GTV 1965", "Stelvio Quadrifoglio 2018", "SZ 1989", "Tipo 33 Stradale 1967"};
            System.Object[] Arielcars = { "Atom 1 1999", "Atom 2 Supercharged 2003", "Atom 3 2008", "Atom 3 Supercharged 2008", "Atom 3.5 2013", "Atom 4 2018", "Atom 500 V8 2011", "Nomad 2018" };
            System.Object[] AstonMartincars = { "Bulldog 1980", "CC100 Speedster 2013", "Cygnet 2011", "DB AR1 2002", "DB10 2015", "DB11 2016", "DB3S 1953", "DB4 1958", "DB4 GT Zagato 1961", "DB5 1963", "DB6 1965", "DB7 1993", "DB7 GT 2002", "DB7 Vantage 1999", "DB7 Zagato 2002", "DB9 2004", "DBS 1967", "DBS Carbon Black Edition 2010", "DBS Superleggera 2019", "DBS Superleggera Volante 2019", "DBS V12 2007", "Lagonda 1976", "Lagonda Vignale 1993", "One-77 2009", "Rapide 2010", "Rapide Bertone Jet 2+2 2013", "Rapide S 2014", "V12 Vanquish 2001", "V12 Vanquish S 2004", "V12 Vantage 2009", "V12 Vantage Carbon Black Edition 2010", "V12 Vantage RS 2007", "V12 Zagato 2012", "V8 1972", "V8 Coupe 1996", "V8 Vantage 1977", "V8 Vantage 2005", "V8 Vantage N400 2007", "V8 Vantage Volante 2000", "V8 Volante 1986", "V8 Volante 1996", "V8 Zagato 1986", "Vanquish S 2016", "Vanquish Volante 2013", "Vanquish Zagato 2017", "Vantage 1993", "Vantage 2018", "Virage 1989", "Virage 2011", "Virage Volante 1992", "Virage Volante 2011", "Vulcan 2018"};
            System.Object[] Audicars = { "quattro 1980", "quattro 20V 1990", "R8 Coupe V10 plus 2015", "R8 Spyder V10 2013", "RS 2 Avant 1994", "RS 3 Sportback 2015", "RS 4 Avant 2000", "RS 4 Avant 2006", "RS 5 Cabriolet 2012", "RS 6 Avant (delimited) 2013", "RS 6 plus 2004", "RS 7 Sportback 2015", "RS Q3 2015", "S1 2014", "S2 Coupe 1993", "S3 2006", "S4 1998", "S4 2012", "S4 Avant 2004", "S5 Coupe 2008", "S6 1997", "S6 2003", "S8 2006", "S8 plus 2015", "Sport quattro S1 1985", "SQ5 2015", "TT RS plus Coupe 2012", "TTS Coupe 2015" };
            System.Object[] Austincars = { "1100 1963", "Allegro 1979", "Ambassador 1982", "Healey 3000 1959", "Healey Sprite 1958", "Maxi 1969" };
            System.Object[] Bentleycars = { "Arnage 1999", "Arnage FInal Series 2009", "Arnage T 2007", "Azure 1995", "Azure 2006", "Azure T 2009", "Bentayga Diesel 2019", "Bentayga V8 2019", "Bentayga W12 2019", "Brooklands 1992", "Brooklands 2008", "Continental 24 2017", "Continental Breitling Jet Team Series Limited Edition 2016", "Continental Flying Spur 2005", "Continental GT 2003", "Continental GT 2006", "Continental GT 2012", "Continental GT 2019", "Continental GT Convertible 2020", "Continental GT Convertible Number 1 Edition by Mulliner 2020", "Continental GT Number 9 Edition by Mulliner 2019", "Continental GT Pikes Peak 2019", "Continental GT Speed Coupe 2015", "Continental GT V8 2019", "Continental GT V8 S 2014", "Continental GT3 2013", "Continental GT3 2018", "Continental GT3-R 2015", "Continental R 1991", "Continental Supersports 2010", "Continental Supersports 2017", "Continental Supersports Convertible 2011", "Continental Supersports Convertible ISR 2011", "Continental T 1999", "EXP 100 GT 2019", "Flying Spur 2018", "Flying Spur 2020", "Flying Spur V8 S 2017", "Flying Spur W12 2017", "Flying Spur W12 S 2017", "Hunaudieres 1999", "Mulsanne 2019", "Mulsanne Blue Train Limited Edition 2015", "Mulsanne Design Series 2017", "Mulsanne Extended Wheelbase 2017", "Mulsanne Grand Convertible 2014", "Mulsanne Grand Limousine 2019", "Mulsanne S 1987", "Mulsanne Speed 2019", "Mulsanne Turbo 1983", "Mulsanne W.O. Edition 2018", "The Sir Peter Blake Continental GT 2016", "Turbo R 1985" };
            System.Object[] BMWcars = { "316 1975", "507 1956", "525 1973", "1800 1963", "116d 2015", "123d 2007", "130i 2005", "130i 2007", "135i Convertible 2008", "1-series M coupe 2011", "2002 Tii 1972", "2002 turbo 1973", "220d Active Tourer 2014", "220d xDrive Gran Tourer 2015", "2800 CS 1968", "320d 2005", "320d Touring 2010", "320Si 2005", "323i 1995", "325i 1982", "325i Convertible 2009", "325iX 1988", "328i 1991", "328i Gran Turismo 2014", "330d 1998", "330d 2005", "330d Touring 2014", "330e 2016", "330i 1998", "335d 2016", "335i 2008", "435i Gran Coupe 2014", "440i 2018", "520d Touring 2012", "520d Touring 2017", "520d xDrive 2017", "520i 2016", "524td 1983", "525ix 1991", "530d 2004", "530i 1996", "535d Touring 2009", "535i 2010", "540i 1993", "540i 1996", "545i 2004", "635CSi 1980", "640d 2011", "640d 2016", "640i xDrive 2012", "640i xDrive Gran Turismo 2017", "645ci 2003", "650i Convertible 2005", "650i Convertible 2012", "728i 1977", "730d 2002", "730d 2008", "730i 1986", "740d 2016", "740i 1994", "750d xDrive 2013", "750i 2016", "750iL 1995", "750Li 2009", "850CSi 1992", "H2R 2004", "i3 2013", "i3 S 2017", "i8 2014", "i8 Roadster 2018", "Isetta 250 1955", "M Coupe 1998", "M1 1978", "M1 Procar Group 4 1979", "M135i 2016", "M140i 2017", "M2 (delimited) 2016", "M2 Competition (delimited) 2019", "M240i 2017", "M240i Convertible 2016", "M3 1986", "M3 1993", "M3 2001", "M3 2008", "M3 CRT 2011", "M3 CS 2018", "M3 CSL 2003", "M3 GTR 2001", "M3 GTS 2010", "M4 2016", "M4 GTS 2016", "M5 1985", "M5 1988", "M5 1998", "M5 2004", "M5 2016", "M5 2018", "M5 Competition (delimited) 2018", "M6 2006", "M6 2016", "M6 Convertible 2006", "M6 Gran Coupe 2013", "M760Li xDrive V12 2015", "M8 GTE 2018", "M850i xDrive 2018", "M850i xDrive Convertible 2019", "Nazca C2 1992", "X1 2010", "X1 2017", "X2 2018", "X3 2003", "X3 35d 2014", "X3 M40i 2018", "X3 xDrive 28d 2016", "X4 2018", "X5 2008", "X5 4.4i 2000", "X5 40e (PHEV) 2016", "X5 M 2009", "X5 M50d 2016", "X6 2012", "X6 2015", "X6 M 2009", "Z1 1989", "Z3 2.2l 2000", "Z4 3.0si 2006", "Z4 sDrive18i 2013", "Z4 sDrive28i 2016", "Z4M Coupe 2006", "Z8 2000" };
            System.Object[] Bugatticars = { "Chiron 2017", "Chiron Sport 2019", "EB110 GT 1992", "EB110 Super Sport 1992", "Veyron 16.4 2005", "Veyron 16.4 Grand Sport 2009", "Veyron 16.4 Super Sport 2010" };
            System.Object[] Buickcars = { "Century Special Coupe 1973", "Enclave 2008", "GNX 1987", "LaCrosse CXL 2005", "LeSabre 2000", "Park Avenue 2000", "Reatta 1988", "Regal GS 2012", "Regal Turbo 2011", "Rendezvous 2002", "Riviera Coupe 1965", "Roadmaster 1954", "Skylark GS 1954", "Verano 2012" };
            System.Object[] Cadillaccars = { "Allante 1989", "ATS-V 2016", "Cien 2002", "Cimarron 1982", "CT6 2016", "CTS 2016", "CTS Coupe 2016", "CTS Sport Wagon 2014", "CTS Vsport 2015", "CTS-V 2004", "CTS-V 2016", "CTS-V Sport Wagon 2010", "DeVille 1977", "DTS 2006", "Eldorado 1979", "Eldorado 1991", "Eldorado 1995", "Elmiraj 2013", "ELR 2016", "Escalade 1999", "Escalade 2002", "Escalade 2011", "Escalade ESV 2016", "Escalade EXT 2011", "Sedan De Ville 2000", "Seville 1980", "Sixteen 2003", "SRX 2006", "STS 2005", "STS-V 2005", "XLR roadster 2004", "XLR-V 2006", "XT5 2016" };
            System.Object[] Caterhamcars = { "21 1995", "CSR 2005", "JPE 1992", "RS Levante 2008", "Seven 160 2013", "Seven 270 2015", "Seven 360 2015", "Seven 420 2015", "Seven 620R 2013", "Superlight R500 2008" };
            System.Object[] Chevroletcars = { "454 SS 1990", "Aerovette 1977", "Aveo 2011", "Bel Air 1957", "Beretta GTZ 1991", "Blazer 2000", "Blazer S-10 1983", "Camaro berlinetta 1985", "Camaro IROC Z/28 1990", "Camaro IROC-Z 1985", "Camaro SS 2017", "Camaro SS 2019", "Camaro SS Convertible 2012", "Camaro SS Coupe 2010", "Camaro Z/28 1970", "Camaro Z/28 1977", "Camaro Z/28 1993", "Camaro Z/28 2015", "Camaro Z28 SS 1999", "Camaro ZL1 2012", "Camaro ZL1 2015", "Camaro ZL1 1LE 2018", "Caprice 1991", "Captiva 2007", "Captiva LTX 2008", "Chevelle SS 454 1970", "Chevette 1976", "Cobalt SS S/C 2006", "Cobalt SS Turbo 2009", "Code 130R 2012", "Colorado ZR2 2018", "COPO Camaro 2012", "Copo Camaro 2018", "Corvette 1953", "Corvette 2009", "Corvette 396 1965", "Corvette C4 1984", "Corvette C5 1997", "Corvette Grand Sport 1996", "Corvette Grand Sport 2017", "Corvette LT-1 1970", "Corvette Stingray Z51 2016", "Corvette Z06 2001", "Corvette Z06 2006", "Corvette Z06 2016", "Corvette Z06 Lingenfelter 2006", "Corvette ZR1 1971", "Corvette ZR1 1993", "Corvette ZR1 2019", "Corvette ZR2 1972", "Cruze LS 2009", "Cruze LT 2012", "Cruze SW 2012", "El Camino 1963", "El Camino 1981", "El Camino SS 454 1969", "Fleetline 1948", "HHR SS Turbocharged 2008", "Impala 1959", "Impala SS 1964", "Impala SS 1996", "Impala SS427 1967", "K5 Blazer 5.7L 1972", "Lacetti 2004", "Lumina Z34 1991", "Malibu 2019", "Matiz 2005", "Miray 2011", "Monte Carlo 1970", "Monte Carlo SS 1983", "Monte Carlo SS 2006", "Monte Carlo SS Jeff Gordon Edition 2003", "Orlando LTZ 2010", "S-10 Blazer Xtreme 1999", "Silverado 2016", "Silverado SS 2006", "Spark 2009", "SSR 2003", "SSR 6.0L 2007", "Suburban 2016", "Tahoe 1995", "Tahoe Custom 2018", "Trailblazer SS 2006", "Tru 140S 2012", "Volt 2012" };
            System.Object[] Chryslercars = { "200 2017", "300 2018", "300 SRT8 2012", "300 SRT-8 2005", "300 Touring 2005", "300H 1962", "300M Special Edition 2002", "Aspen Hybrid 2009", "Crossfire Coupe 2004", "Crossfire Roadster 2004", "Crossfire SRT-6 Coupe 2004", "Drifter 1977", "Imperial 1990", "Laser XT 1984", "LeBaron GTS Turbo 1985", "LHS 1994", "ME Four-Twelve 2004", "Newport 1968", "Pacifica 2018", "Prowler 2001", "PT Cruiser 2004", "Sebring 1995", "Sebring 2001", "Sebring 2007", "Sebring Convertible 1996", "TC by Maserati 1990", "Town and Country 1990", "Town and Country 1991", "Town and Country 1996", "Town and Country 2001", "Town and Country 2008", "Turbine Car 1963" };
            System.Object[] Citroencars = { "2CV 6 1979", "Ami Super 1973", "AX GTi 1993", "Axel 12 TRS 1984", "BX 16v 1987", "BX 17 D Turbo Break 1982", "BX 4TC 1982", "BX 4TC Group B 1986", "C1 VTi 68 2015", "C2 VTS 2003", "C2-R2 Max 2008", "C3 Aircross 2018", "C3 Picasso 2016", "C3 PureTech 110 2016", "C3-XR 2014", "C4 2.0 16v VTS 2004", "C4 Cactus 2.0 HDi 16v 2014", "C4 Picasso THP 165 2016", "C5 Aircross 2018", "C5 Crosstourer 2014", "C5 HPi 2001", "C5 Saloon 1.6 L 2004", "C5 Tourer 3.0 L 2016", "C5 V6 2003", "C6 3.0 L V6 HDi 2005", "C-Crosser 2.2 L HDi 2007", "CX GTi Turbo 1974", "CXperience 2016", "C-Zero 2016", "Grand C4 Picasso 2015", "GSA 1979", "GT 2008", "GZ 1973", "M35 1969", "Mehari 4x4 1980", "Metropolis 2010", "Saxo VTS 16V 1996", "SM 2.7 Injection 1972", "Traction Avant 1934", "Visa GTi 1978", "Xantia Activa V6 1997", "Xantia VSX 1993", "XM V6 24V 1989", "Xsara Picasso 1997", "Xsara VTS 1997", "ZX Volcane TD 1991" };
            System.Object[] DeTomasocars = { "Deauville 1971", "Guara 1993", "Guara 1998", "Longchamp 1973", "Longchamp GTS 1989", "Mangusta 1967", "Mangusta 1967", "Pantera GT5 1984", "Pantera GT5-S 1989", "Pantera GTS 1974", "Pantera L 1973", "Pantera SI 1991", "Vallelunga Competizione 1964"};
            System.Object[] Dodgecars = { "Avenger 1995", "Caliber R/T AWD 2007", "Caliber SRT4 2008", "Caravan Turbo 1989", "Challenger GT AWD 2018", "Challenger SRT Demon 2017", "Challenger SRT Hellcat 2015", "Challenger SRT Hellcat Widebody 2018", "Challenger T/A 1970", "Charger Daytona 2017", "Charger R/T Scat Pack 2015", "Charger SRT Hellcat 2015", "Charger SRT-8 2006", "Coronet Super Bee 1968", "Dakota R/T 1998", "Dart 2017", "Daytona IROC R/T 1992", "Durango GT 2018", "Grand Caravan 2018", "Intrepid 1993", "Journey 2018", "Magnum SRT-8 2006", "Monaco 1974", "Neon R/T Coupe 1998", "Nitro R/T 2007", "Spirit R/T 1991", "SRT Viper 2013", "SRT-4 2004", "Stealth 1995", "Stealth R/T Twin Turbo 1990", "Viper ACR 2016", "Viper GTS-R 1996", "Viper RT/10 1992" };
            System.Object[] Donkervoortcars = { "D10 1988", "D8 270 2008", "D8 270 RS 2006", "D8 Audi (AGU) 1999", "D8 Audi (E-gas) Wide Track 2004", "D8 Cosworth 1994", "D8 GT 2007", "D8 GTO 2014", "D8 GTO-40 2018", "D8 GTO-RS 2016", "D8 Zetec Sport 1994", "S7 1978", "S8 1980", "S8A 1983", "S8AT 1986" };
            System.Object[] DScars = { "4 2011", "5 2012", "3 Convertible 2016", "3 DSport HDi 2016", "3 Performance 2016", "DS 3 Racing 2011", "DS 6 2015", "DS 7 Crossback 2018", "DS 7 Crossback E-Tense 4x4 PHEV 2018", "DS Convertible 1958", "DS Numero 9 2012", "Survolt 2010", "Wild Rubis 2013" };
            System.Object[] Fiatcars = { "127 1971", "128 1969", "500 1957", "500 2017", "124 Spider 2017", "124 Sport Spider 1966", "126p 1972", "131 Mirafiori 1974", "500L 2012", "500X 2017", "8V 1952", "8V Supersonic 1953", "Abarth 030 1974", "Abarth 1000TC Berlina Corsa 1967", "Abarth 124 Spider 2017", "Abarth 124 Spider Rally 2016", "Abarth 131 Rally 1976", "Abarth 1500 Biposto 1952", "Abarth 500 Abarth 1964", "Abarth 595 Turismo 2012", "Abarth 695 Biposto 2017", "Abarth 695 Tributo Ferrari 2009", "Abarth 695 Tributo Maserati 2012", "Abarth 750 Zagato 1956", "Abarth Grande Punto 2010", "Abarth Grande Punto S2000 2006", "Abarth Simca 1300 Bialbero 1962", "Abarth Stilo Group N 2002", "Barchetta 1995", "Bravo 2007", "Campagnola 1951", "Campagnola 1974", "Cinquecento Sporting 1994", "Coupe 20v Turbo 1993", "Dino Coupe 1966", "Dino Spider 1966", "Fullback Cross 2017", "Multipla 1998", "Panda 1980", "Panda 2017", "Panda 100hp 2006", "Panda 4x4 1983", "Panda 4x4 2019", "Panda Cross 4x4 Mark 3 2014", "Punto 2017", "Punto 1.4 GT 1993", "Punto Cabrio 1993", "Punto HGT 1999", "Qubo 2009", "Seicento Rally Spec 1998", "Stilo 2.4 20v Schumacher GP 2002", "Strada Abarth 130TC 1982", "Tipo 2017", "Tipo 2.0 Sedicivalvole 1988", "Turbina 1954", "Uno Turbo 1985", "X1/9 1972", "X1/9 Dallara 1975" };
            System.Object[] Fordcars = { "B-Max 2012", "Capri 3.0 S 1978", "C-Max 2015", "Cortina 1974", "Ecosport 2016", "Edge 2016", "Escort Mexico 1972", "Escort Rally Spec 1970", "Escort Rally Spec 1979", "Escort RS Cosworth 1992", "Escort RS Turbo 1984", "Escort RS1600 1968", "Escort RS2000 1974", "Escort RS2000 1996", "Escort XR3i 1982", "F-150 SVT Raptor 2014", "Fiesta 1976", "Fiesta 1983", "Fiesta 1993", "Fiesta 1997", "Fiesta 2007", "Fiesta 1.0 2016", "Fiesta ST 2016", "Fiesta XR2 1981", "Fiesta XR2 1988", "Focus 2004", "Focus 2006", "Focus 2015", "Focus 1.0 2016", "Focus Bioethanol 2006", "Focus Coupe-Cabriolet 2007", "Focus RS 2002", "Focus RS 2009", "Focus RS500 2010", "Focus ST 2012", "Focus ST Mountune 2014", "Focus ST Superchips 2005", "Focus ST TDCi Estate 2016", "Focus ST170 2002", "Galaxy 2015", "Granada 2.8i S 1977", "GT 2005", "GT 2017", "GT40 1965", "GT90 1995", "Ka 2011", "Kuga 2016", "Mondeo 2004", "Mondeo 2013", "Mondeo 2017", "Mondeo 2.0tdci 2016", "Mondeo Hybrid 2016", "Mondeo ST200 1998", "Mondeo ST220 2000", "Mustang 2005", "Mustang 2005", "Mustang 2.3 2016", "Mustang 289 1966", "Mustang BOSS 302 2012", "Mustang GT 2016", "Mustang GT Power Pack 2016", "Puma 1.7 1997", "Racing Puma 2000", "Ranger 2006", "Ranger 2012", "Ranger 2016", "Ranger 2016", "Ranger Wildtrak 2012", "RS200 1984", "Scorpio 24-valve 1991", "Sierra RS Cosworth 1986", "Sierra RS Cosworth 4x4 1990", "Sierra RS500 1987", "Sierra XR4i 1983", "S-Max 2016", "Taurus SHO 2017", "Thunderbird 3.9l V8 2002", "Transit 2.2 TDCi 2013" };
            System.Object[] GMCcars = { "Acadia 2016", "Acadia Denali 2018", "Caballero Diablo 1984", "Denali XT 2008", "Envoy 1998", "Granite 2010", "Safari 1996", "Sierra All Terrain X 2017", "Syclone 1991", "Terrain 2010", "Typhoon 1993", "Yukon 2010", "Yukon Denali 2004", "Yukon XL 2014" };
            System.Object[] Gumpertcars = { "Apollo 2006", "Apollo Basic 2007", "Apollo Enraged 2012", "Apollo R 2012", "Apollo S 2010", "Intensa Emozione 2019", "N 2016" };
            System.Object[] Hondacars = { "Accord 1.8 1976", "Accord 3.5l V6 2016", "Accord Euro-R 2006", "Accord Hybrid 2016", "Accord Type R 1997", "Beat 1991", "Capa 4WD 1998", "City Cabriolet 1981", "City Turbo 1981", "Civic 1.8 2016", "Civic 1500 1979", "Civic CRX Si 1983", "Civic Hybrid 2013", "Civic Si 1995", "Civic Tourer 1.6d 2016", "Civic Type R 1999", "Civic Type R 2001", "Civic Type R 2006", "Civic Type R 2016", "Clarity 2016", "CR-V 1997", "CR-V 1.6 i-DTEC 2016", "CR-V 2.0 i-VTEC 2002", "CR-V 2.2 i-DTEC 2007", "CR-X 1.6i-16 1983", "CRX VTEC 1988", "CR-Z 2016", "EV Plus 1997", "FR-V 2.2 i-CTDi 2004", "HR-V 1.8 4WD 2016", "Insight 2000", "Integra Type R 1995", "Integra Type R 2002", "Jazz 2001", "Jazz 2016", "Jazz Hybrid 2007", "Legend 2.7 V6 1985", "Legend 3.5 V6 1995", "Legend 3.7 SH-AWD 2004", "NSX 1990", "NSX-R 2002", "Odyssey 2016", "Odyssey 2.3 1995", "Odyssey 3.5 V6 2005", "Pilot 4WD 2003", "Pilot 4WD 2009", "Pilot 4WD 2016", "Prelude 1978", "Prelude 2.0l 1982", "Prelude 2.0Si 4WS 1987", "Prelude Type S 1996", "Prelude VTEC 1991", "Ridgeline 2016", "S2000 1999", "S2000 Type S 2008", "S800 1967", "S-MX 4WD 1996", "Vamos 4WD Turbo 2016" };
            System.Object[] Hummercars = { "H1 1992", "H2 SUT 2005", "H2 SUV 2003", "H3 2006", "H3T 2009" };
            System.Object[] Infiniticars = { "FX35 2003", "G35 2002", "G35 2007", "G37 2009", "M35 2009", "M45 2003", "M45 2006", "Q30 2016", "Q50 2014", "Q60 2016", "Q70 2016", "QX30 2017", "QX50 2016", "QX70 2016" };
            System.Object[] Jaguarcars = { "C-Type 1951", "C-X75 2010", "C-X75 2013", "D-Type 1954", "E-PACE 2018", "E-Type 1961", "F-Pace 3.0 D 2016", "F-PACE SVR 2018", "F-Type Coupe 2016", "F-Type Project 7 2015", "F-Type R Convertible 2016", "F-Type R Coupe AWD 2016", "F-Type Rally Car 2018", "F-Type SVR Coupe 2017", "I-PACE 2018", "Mark 1 1957", "Mark 2 1959", "Mark 2 BTCC 1960", "SS 100 1936", "S-Type R 2007", "XE R-Dynamic S 2020", "XE S 2016", "XE SV Project 8 2017", "XF S 2016", "XFR-S Sportbrake 2016", "XJ 3.0 V6 2016", "XJ 5.0 V8 2010", "XJ12 1972", "XJ12 1974", "XJ12 1980", "XJ13 1966", "XJ220 1992", "XJ220S TWR 1994", "XJ6 1974", "XJ6 1986", "XJ-C 1975", "XJR 1995", "XJR 1998", "XJR 2003", "XJR 2013", "XJR 575 2018", "XJR-15 1990", "XJR-9 1988", "XJS 1988", "XJ-S Trans-Am 1978", "XJS TWR 1982", "XK Convertible 2010", "XK120 1948", "XK140 1954", "XK150 1957", "XK8 1997", "XKR 2008", "XKR 100 2002", "XKR 175 2010", "XKR 4.2-S 2005", "XKR 75 2010", "XKR-R 2001", "XKR-S Convertible 2011", "XKR-S GT 2014", "XKSS 1957", "X-Type 2001" };
            System.Object[] Koenigseggcars = { "Agera 2011", "Agera Final 2016", "Agera R 2014", "Agera RS 2015", "CC8S 2001", "CCR 2004", "CCX 2006", "CCXR 2007", "CCXR Edition 2008", "CCXR Trevita 2008", "Gemera 2020", "Jesko 2019", "Jesko Absolut 2020", "One:1 2014", "Regera 2015" };
            System.Object[] KTMcars = { "X-Bow GT 2016", "X-Bow GT4 2016", "X-Bow R 2016", "X-Bow RR 2016" };
            System.Object[] Lamborghinicars = { "350GT 1964", "400GT 1966", "Aventador Coupe 2011", "Aventador J 2012", "Aventador Roadster 2012", "Aventador S 2018", "Aventador S Roadster 2018", "Aventador SV 2015", "Aventador SV Roadster 2015", "Aventador SVJ 2018", "Centenario 2016", "Countach 25th Anniversario 1988", "Countach 5000 Quattrovalvole 1985", "Countach LP400 1974", "Countach LP400 S 1978", "Countach LP500 S 1982", "Diablo 1990", "Diablo 6.0 2000", "Diablo 6.0 SE 2001", "Diablo GT 1999", "Diablo SE 1993", "Diablo SV 1996", "Diablo VT 1993", "Diablo VT Roadster 1995", "Espada Serie I 1968", "Espada Serie II 1970", "Espada Serie III 1972", "Gallardo (1st gen) 2003", "Gallardo LP 550-2 Valentino Balboni 2009", "Gallardo LP 570-4 Edizione Tecnica 2012", "Gallardo LP550-2 (2nd gen) 2010", "Gallardo LP550-2 Spyder (2nd gen) 2012", "Gallardo LP560-4 (2nd gen) 2008", "Gallardo LP560-4 Spyder (2nd gen) 2009", "Gallardo LP570-4 Spyder Performante (2nd gen) 2010", "Gallardo LP570-4 Super Trofeo Stradale (2nd gen) 2011", "Gallardo LP570-4 Superleggera (2nd gen) 2012", "Gallardo Spyder (1st gen) 2006", "Gallardo Superleggera (1st gen) 2007", "Huracan Coupe 2014", "Huracan Performante 2018", "Huracan Performante Spyder 2018", "Huracan RWD 2015", "Huracan RWD Spyder 2018", "Huracan Spyder 2015", "Islero 1968", "Islero S 1969", "Jalpa 1981", "Jarama GT 1970", "Jarama GTS 1972", "LM002 1986", "Miura P 400 1966", "Miura Roadster 1968", "Miura S 1968", "Miura SV 1971", "Miura SV/J 1971", "Murcielago 2001", "Murcielago LP640 2006", "Murcielago LP640 Roadster 2007", "Murcielago LP650-4 Roadster 2009", "Murcielago LP670-4 SuperVeloce 2009", "Murcielago Roadster 2004", "Reventon 2007", "Sesto Elemento 2010", "Silhouette 1976", "Urraco P250 1973", "Urraco P300 1973", "Urus 2018", "Veneno 2013" };
            System.Object[] Lanciacars = { "037 Rally 1982", "2000 HF Coupe 1971", "Aprilia Sport Zagato 1938", "Aurelia 1956", "Beta Coupe 1982", "Beta HPE 1978", "Beta Montecarlo 1975", "D24 Pininfarina Spider Sport 1953", "Dedra 1996", "Delta 2012", "Delta HF 4WD 1986", "Delta HF Integrale 16v 1990", "Delta HF Integrale Evoluzione 1992", "Delta Integrale 16v 1989", "Delta Integrale 8v 1989", "Delta Integrale Evoluzione 1991", "Delta Integrale Evoluzione II 1993", "Delta S4 Rally 1985", "Delta S4 Stradale (SE038) 1985", "ECV 1986", "Flaminia Sport Zagato 1958", "Flavia 2000 Coupe 1969", "Fulvia Coupe 1965", "LC2 1984", "Montecarlo Turbo 1981", "New Stratos 2010", "Rally 037 Stradale 1982", "Stratos 1973", "Stratos HF Group 4 1974", "Stratos Zero 1970", "Thema 8.32 1986", "Y10 1985", "Ypsilon 2017" };
            System.Object[] LandRovercars = { "Defender 110 2016", "Defender 90 2006", "Defender Works V8 2018", "Discovery 2011", "Discovery 1 1989", "Discovery 2 1998", "Discovery 3 2004", "Discovery 5 2017", "Discovery Si4 2019", "Discovery Sport 2016", "Discovery Sport P250 AWD 2020", "Freelander 1997", "Freelander 2 TD4 2012", "Range Rover 4.4 V8 2002", "Range Rover 4.6 HSE 1994", "Range Rover 5.0 V8 2016", "Range Rover Evoque 2016", "Range Rover Evoque 2018", "Range Rover Evoque 2018", "Range Rover Evoque Autobiography Dynamic 2015", "Range Rover Mk 1 1970", "Range Rover P400e PHEV 2018", "Range Rover Sport 2005", "Range Rover Sport 2018", "Range Rover Sport SVR 2016", "Range Rover Sport SVR 2018", "Range Rover Velar 2018", "Range Rover Velar SVAutobiography Dynamic Edition 2019", "Series 1 1948"};
            System.Object[] Lotuscars = { "2-Eleven GT4 2009", "2-Eleven S'charged 2007", "340R 2000", "3-Eleven 430 2018", "Carlton 1991", "Eclat 1976", "Elan 1962", "Elan SE 1989", "Elise 1996", "Elise 1.6 2015", "Elise 111S 2002", "Elise Cup 250 2019", "Elise Sport 135 2003", "Elise Sprint 2017", "Elite 1957", "Esprit 1976", "Esprit S4 1993", "Esprit Sport 350 1999", "Esprit Turbo 1981", "Esprit V8 2002", "Essex Turbo Esprit 1980", "Europa 47 Twin Cam 1966", "Europa S 2006", "Europa SE 2008", "Europa Special 1973", "Evora 280 2009", "Evora 400 2015", "Evora GT430 2018", "Evora GT430 Sport 2017", "Evora GTE Road Car 2011", "Evora S 2010", "Evora Sport 410 2019", "Exige 265E 2007", "Exige Cup 260 2009", "Exige Cup 430 2019", "Exige S 2015", "Exige S1 2000", "Exige S2 2005", "Exige Scura 2009", "Group GT4 2011", "M100 Elan 1989", "Mk1 Cortina 1967", "Seven 1957" };
            System.Object[] Maseraticars = { "430 1987", "250F 1955", "3200 GT Assetto Corsa 1998", "3500 GT 1957", "5000 GT 1959", "A6 1500 1947", "A6G 2000 1950", "Birdcage 75th 2005", "Biturbo S 1983", "Bora 1971", "Coupe GranSport 2004", "Ghibli 2018", "Ghibli Cup 1992", "Ghibli Diesel 2018", "Ghibli S Q4 2016", "Ghibli SS 1969", "Ghibli SS Spyder 1969", "GranCabrio 2018", "GranCabrio MC 2016", "GranTurismo 2018", "GranTurismo MC Stradale 2016", "Indy 1969", "Karif 1988", "Khamsin 1974", "Kyalami 1978", "Levante Diesel 2018", "Levante S 2018", "MC12 Stradale 2004", "Merak SS 1976", "Mexico 1966", "Mistral 1963", "Quattroporte 1974", "Quattroporte 1994", "Quattroporte 2017", "Quattroporte Diesel 2018", "Quattroporte GTS 2016", "Quattroporte Sport GT S 2009", "Racing 1991", "Royale 1986", "Sebring 1962", "Shamal 1990", "Spyder 1991", "Spyder GranSport 2005", "Tipo 61 Birdcage 1959" };
            System.Object[] Mazdacars = { "2 2018", "3 2018", "6 2016", "6 MPS 2005", "787b 1990", "Autozam AZ-1 1992", "BBR MX-5 GT270 2013", "BT-50 2018", "Carol 1962", "Cosmo 1967", "Cosmo 1975", "Cosmo 1981", "Cosmo 1990", "CX-3 2018", "CX-5 2018", "CX-9 2018", "Eunos Roadster RS-Limited 1994", "Furai 2007", "Jota MX-5 GT 2013", "MX-5 1989", "MX-5 1998", "MX-5 2005", "MX-5 2018", "MX-5 BBR Turbo 1990", "MX-5 RF 2018", "RX-3 1971", "RX-7 1978", "RX-7 1985", "RX-7 1992", "RX-7 Convertible 1988", "RX-7 Spirit R 2002", "RX-7 Turbo 1983", "RX-7 Turbo 1985", "RX-7 Type RS 1998", "RX-7 Type RZ 2000", "RX-8 2002", "RX-8 PZ 2006", "RX-8 Spirit R 2012" };
            System.Object[] McLarencars = { "12C 2011", "12C GT3 2012", "570S Coupe 2015", "570S Spider 2017", "600LT Coupe 2018", "600LT Spider 2019", "650S 2014", "650S GT3 2016", "675LT 2015", "720S 2018", "720S GT3 2019", "720S Spider 2018", "F1 1994", "F1 GT 1997", "F1 GTR Short Tail 1995", "F1 LM 1995", "GT 2019", "Mercedes-Benz SLR McLaren 2003", "Mercedes-Benz SLR McLaren 722 2006", "Mercedes-Benz SLR McLaren Roadster 2007", "P1 2014", "P1 GTR 2015", "Senna 2019" };
            System.Object[] MercedesBenzcars = { "600 1964", "190 E 2.0 1985", "190 E 2.3-16 1984", "190 E Evo II 1990", "280 GE 1990", "300 SL 1963", "57S Maybach 2012", "62 Landaulet Maybach 2010", "A 160 1997", "A 180d 2012", "A 200 2012", "A 200 CDI 2004", "AMG A 45 2016", "AMG C 43 1999", "AMG C 55 2007", "AMG C 63 2012", "AMG C 63 2015", "AMG CLK 63 Black Series 2007", "AMG CLK DTM 2007", "AMG E 55 2003", "AMG E 63 2011", "AMG E 63 S 2015", "AMG G 55 2006", "AMG G 63 2015", "AMG G 63 6x6 2013", "AMG GLE 63 S 2015", "AMG GT 2016", "AMG GT S 2016", "AMG ML 63 2012", "AMG S 55 2003", "AMG S 63 2011", "AMG S 65 2006", "AMG S 65 Coupe 2016", "AMG SL 73 1999", "AMG SLC 43 2016", "AMG SLK 32 2004", "AMG SLK Black Series 2007", "AMG SLS 2010", "AMG SLS Black Series 2013", "AMG SLS Electric 2013", "AMG SLS GT 2012", "AMG SLS GT3 2016", "AMG SLS Roadster 2012", "C 200 K 2002", "C 250d 2015", "C 350 4MATIC 2009", "C 350e 2015", "CLA 250 4MATIC 2015", "CLK 230 K 1999", "CLS 400 2015", "E 220 2015", "E 320 1994", "E 320 CDI 2005", "E 430 1999", "E 500 1994", "G 500 2012", "GL 350 2015", "GLA 220d 2015", "GLC 250d 2015", "S 280 1995", "S 350 4MATIC 2007", "S 400h L 2016", "SL 500 2016", "SLK 200 2016", "V 250d 2015"};
            System.Object[] MGcars = { "Maestro Turbo 1983", "Metro 6R4 1984", "Metro Turbo 1982", "MGB 1962", "MGB GT V8 1973", "MGC GT 1967", "Midget 1961", "Montego Turbo 1985" };
            System.Object[] Minicars = { "Cooper 2016", "Cooper Convertible 2016", "Cooper S 1971", "Cooper S 2016", "Cooper S Works GP 2006", "Cooper SD 2011", "JCW ALL4 Countryman 2016", "JCW Convertible 2016", "JCW Coupe 2016", "John Cooper Works 2016", "One 2016" };
            System.Object[] Mitsubishicars = { "ASX 2010", "ASX 2015", "Colt 2004", "Colt 2009", "Colt CZC 2006", "Colt Ralliart Version-R 2009", "Grandis 2006", "i 2007", "L200 2016", "Lancer Evo I 1992", "Lancer Evo IV 1996", "Lancer Evo IX MR FQ-360 2007", "Lancer Evo VI T.M. Edition 2000", "Lancer Evo VIII 260 2004", "Lancer Evo VIII FQ-400 2004", "Lancer Evo VIII MR FQ-340 2005", "Lancer Evo X FQ-300 SST 2007", "Lancer Evo X FQ-360 2009", "Lancer GS4 2007", "Lancer Sportback 2008", "Mirage 2013", "Montero Black Edition 2011", "Montero SG4 2011", "Outlander 2012", "Outlander PHEV 2016" };
            System.Object[] Nissancars = { "200SX 1993", "350Z 2002", "350Z Roadster 2005", "370Z 2011", "Almera 1998", "Almera GTI 1997", "Cube 1998", "Cube 2010", "Datsun 240Z 1969", "Datsun 240Z Rally Car 1969", "Figaro 1991", "GT-R 2014", "GT-R Nismo 2016", "Juke 2013", "Juke Nismo 2016", "Juke-R 2011", "Leaf 2016", "Micra 1991", "Micra 2004", "Micra 2011", "Micra 2016", "Murano 2002", "Murano 2008", "Murano CrossCabriolet 2008", "Murano GT-C 2006", "Navara 2016", "Note 2006", "Note 2013", "NP300 Navara 2017", "Pathfinder 1985", "Pathfinder 2006", "Pathfinder 2010", "Pathfinder 2016", "Patrol 1986", "Patrol 1987", "Patrol 1997", "Patrol 2000", "Patrol (type 60) 1959", "Patrol Nismo 2016", "Pixo 2009", "Primera 1999", "Primera 2004", "Primera eGT 1990", "Pulsar 1978", "Pulsar 1982", "Pulsar 1986", "Pulsar 1995", "Pulsar 2015", "Qashqai 2008", "Qashqai 2016", "R390 GT1 Road Car 1998", "S-Cargo 1989", "Silvia 1965", "Silvia 1975", "Silvia 240RS 1983", "Skyline GT-R (R32) 1989", "Skyline GT-R (R33) 1997", "Skyline GT-R (R34) 1999", "Skyline Hardtop 2000 GT-R (C10) 1971", "Terrano II 2002", "X-Trail 2001", "X-Trail 2010", "X-Trail 2016" };
            System.Object[] Paganicars = { "Huayra 2016", "Huayra BC 2016", "Huayra Roadster 2017", "Zonda 760RS 2012", "Zonda C12 1999", "Zonda Cinque Roadster 2009", "Zonda F 2005", "Zonda R 2007", "Zonda Revolucion 2013", "Zonda S 2000", "Zonda S 7.3 2002" };
            System.Object[] Peugeotcars = { "108 2018", "203 1948", "208 2018", "301 2018", "305 1977", "307 2003", "308 2018", "404 1962", "405 1987", "508 2018", "605 1989", "607 1999", "907 2004", "1007 2005", "2008 2018", "3008 2018", "5008 2018", "106 Rallye (S1) 1993", "106 Rallye (S2) 1997", "204 Coupe 1965", "205 GTi 1.6 1984", "205 GTi 1.9 1986", "205 Rallye 1988", "205 T16 1984", "205 T16 Evo 2 1985", "205 T16 Pikes Peak 1987", "206 CC 2000", "206 GTi 1999", "206 RC 2003", "206 WRC 2000", "207 RC 2007", "207 S2000 2007", "208 GTi 2018", "208 R2 2012", "208 T16 Pikes Peak 2013", "208 T16 R5 2014", "208 WRX 2018", "3008 DKR 2017", "306 GTi-6 1996", "306 Maxi 1999", "306 Rallye 1998", "308 GTi 2018", "308 R HYbrid 2016", "309 GTi 1986", "402 Darl'mat 1937", "404 Coupe 1963", "405 Mi16 1987", "405 T16 1993", "405 T16 Pikes Peak 1988", "406 Coupe 1997", "407 Coupe 2006", "407 Silhouette 2004", "504 Coupe 1968", "505 Break 1982", "607 Pescarolo 2002", "905B 1992", "908 HDi FAP 2007", "908 RC 2006", "e-208 2019", "e-Legend 2018", "EX1 2010", "Hoggar 2010", "iOn 2018", "Onyx 2012", "Oxia 1988", "Quasar 1984", "Rally 504 1971", "RC Diamonds 2002", "RC Spades 2002", "RCZ R 2013", "SR1 2010" };
            System.Object[] Plymouthcars = { "Barracuda Fastback 1968", "Duster 340 1972", "Fury 1958", "GTX 1968", "HEMI 'Cuda 1970", "Reliant 1981", "Roadrunner 383 1968", "Scamp 1982", "Superbird 1970" };
            System.Object[] Pontiaccars = { "6000 STE AWD 1988", "Aztek 2001", "Bonneville Special 1954", "Bonneville SSEi 2000", "Fiero 1984", "Fiero GT 1988", "Firebird Trans Am 1970", "Firebird Trans Am 1985", "G6 2005", "G8 GXP 2010", "Grand Am 1986", "Grand Am GT 1992", "Grand Prix 2+2 1986", "Grand Prix GTP 1997", "Grand Prix GXP 2006", "GTO 2006", "GTO Judge Ram Air IV 1970", "Montana 2005", "Solstice GXP Coupe 2009", "Sunbird GT 1986", "Sunfire 1995", "Tempest Le Mans GTO 1966", "Torrent GXP 2008", "Trans Am 1978", "Trans Am 20th Anniversary 1989", "Trans Am 30th Anniversary 1999", "Trans Am 35th Anniversary 2002", "Vibe GT 2003" };
            System.Object[] Porschecars = { "356 1948", "356 1955", "911 1965", "914 1969", "917 1970", "924 1976", "928 1977", "944 1982", "959 1986", "968 1992", "356 B Convertible 1600 1965", "356 Speedster 1955", "550 Spyder 1955", "718 Boxster 2017", "718 Boxster S 2017", "718 Cayman 2016", "911 Carrera 1994", "911 Carrera 2004", "911 Carrera 2016", "911 Carrera 2 Targa 1989", "911 Carrera 2.7 RS 1973", "911 Carrera 4 1989", "911 Carrera 4 2000", "911 Carrera Cabriolet 2000", "911 Carrera GTS 2015", "911 Carrera RSR 3.0 1973", "911 Carrera S 2004", "911 Carrera S 2015", "911 Carrera S Cabriolet 2016", "911 GT1 race car 1997", "911 GT1 road car 1997", "911 GT2 2001", "911 GT2 2007", "911 GT2 RS 2011", "911 GT2 RS 2018", "911 GT3 1999", "911 GT3 2006", "911 GT3 2013", "911 GT3 RS 2004", "911 GT3 RS 2006", "911 GT3 RS 2015", "911 GT3 RS 2018", "911 GT3 RS 4.0 2011", "911 R 2016", "911 RS 1992", "911 Targa 4S 2004", "911 Targa 4S 2015", "911 Targa 4S 2016", "911 Turbo 1975", "911 Turbo 1990", "911 Turbo 1995", "911 Turbo 2001", "911 Turbo 2006", "911 Turbo 2013", "911 Turbo Martini 1978", "911 Turbo S 2013", "911S 2.4 Targa 1972", "911S 2.7 1974", "918 Spyder 2013", "924 Carrera GTS 1981", "924 Carrera GTS Rallye 1981", "924 Turbo 1979", "928 S 1980", "935 'Moby Dick' 1978", "959 Dakar 1986", "962 C 1985", "968 Clubsport 1993", "968 Turbo S 1993", "Boxster 1996", "Boxster 2005", "Boxster 2015", "Boxster GTS 2015", "Boxster S 2015", "Boxster Spyder 2009", "Boxster Spyder 2016", "Carrera GT 2003", "Cayenne GTS 2016", "Cayenne Turbo 2002", "Cayenne Turbo 2017", "Cayman 2005", "Cayman 2009", "Cayman 2012", "Cayman GT4 2015", "Cayman GTS 2014", "Macan GTS 2015", "Macan Turbo 2016", "Macan Turbo Performance Pack 2017", "Panamera Turbo 2010", "Panamera Turbo 2017" };
            System.Object[] Ramcars = { "1500 Rebel 2019", "Dodge 1st Gen 1981", "Dodge Li'l Red Express Truck 1978", "Dodge Ramcharger 1974", "Dodge Ramcharger 1981" };
            System.Object[] Renaultcars = { "4 1961", "5 1972", "5 1984", "6 1968", "12 1969", "14 1976", "16 1965", "18 1978", "30 1975", "17 Coupe 1976", "19 16S 1988", "21 2.0l Turbo Quadra 1986", "21 Savanna 1986", "25 V6 Turbo 1983", "3.5l V6 Espace MK4 2002", "5 GT Turbo 1985", "5 Turbo 1980", "9 Turbo 1981", "Alaskan 2015", "Alpine A110 1971", "Alpine A310 V6 Group 4/B 1983", "Alpine GTA V6 Turbo Le Mans 1990", "Avantime 3.0 V6 2002", "Captur 2016", "Clio 1990", "Clio 1998", "Clio 2005", "Clio 2016", "DeZir 2010", "Espace 1984", "Espace 1991", "Espace 1997", "Espace 2002", "Espace 2016", "Fluence 2013", "Fuego Turbo 1984", "Kadjar 2016", "Koleos 2008", "Koleos 2018", "Laguna 1994", "Laguna 2001", "Laguna 2007", "Laguna Coupe 2010", "Megane 1995", "Megane 2002", "Megane 2008", "R12 Gordini 1973", "R17 Gordini 1979", "R20 Turbo 4x4 1979", "R21 Turbo Europa Cup 1988", "R5 MAXI TURBO 1987", "R8 Gordini 1964", "Safrane Biturbo 1992", "Scenic 1996", "Scenic 2003", "Scenic 2016", "Sport Clio 172 Cup 1999", "Sport Clio 182 Trophy 2005", "Sport Clio 200 2009", "Sport Clio 220 Trophy 2016", "Sport Clio Cup Car 2014", "Sport Clio R.S.16 2016", "Sport Clio V6 2001", "Sport Clio V6 2003", "Sport Laguna BTCC 1999", "Sport Megane 2002", "Sport Megane 2.0 dCi 175 2008", "Sport Megane 275 Trophy-R 2016", "Sport Megane IV R.S. 2018", "Sport Megane R26.R 2008", "Sport Megane Trophy 2009", "Sport R.S. 01 2015", "Sport Spider 1996", "Sport Twingo 133 Cup 2012", "Sport Twingo GT 2016", "Talisman 2015", "Trezor 2016", "Twingo 1993", "Twingo 2007", "Twingo 2007", "Twizy 2016", "Twizy F1 2013", "Vel Satis 2002", "Wind 2010", "Zoe 2016" };
            System.Object[] Rimaccars = { "C_Two 2019", "Concept_One 2016" };
            System.Object[] Rovercars = { "200 1995", "216 1984", "400 1995", "623 1993", "800 1986", "220 Coupe Turbo 1992", "220 GSi 1989", "P6 1963", "SD1 1976" };
            System.Object[] RUFcars = { "3400S 1999", "3800S 2013", "BTR 1983", "BTR2 1993", "CTR \"Yellowbird\" 1987", "CTR2 1995", "CTR3 2007", "CTR3 Clubsport 2012", "Dakara 2009", "R Kompressor 2006", "R Turbo 2001", "R56.11 2011", "RCT 1991", "RGT 2000", "RK Coupe 2006", "Rt 12 S 2009", "Rt 35 2012", "RTR 2016", "SCR 1978", "SCR 4.2 2016", "Turbo 3.3 1977", "Turbo Florio 2015", "Turbo R Limited 2016" };
            System.Object[] ScuderiaCameronGlickenhauscars = { "SCG003S 2018" };
            System.Object[] Smartcars = { "Brabus Roadster 2005", "Crossblade 2002", "Forfour 2016", "Fortwo 2004", "Fortwo Cabrio 2016", "Fortwo Coupe T 2016", "Fortwo EV 2008" };
            System.Object[] Spykercars = { "C12 La Turbie 2006", "C12 Zagato 2007", "C8 Aileron 2009", "C8 Aileron Spyder 2010", "C8 Double 12 S (Stage V) 2002", "C8 Laviolette 2001", "C8 Laviolette LM85 2008", "C8 Preliator 2016", "C8 Preliator Spyder 2017", "C8 Spyder SWB 2000", "C8 Spyder T 2003", "D12 Peking-to-Paris 2006" };
            System.Object[] Subarucars = { "Alcyone SVX 1991", "Baja Turbo 2003", "Brat 1978", "BRZ 2016", "Forester 1997", "Forester 2002", "Forester 2008", "Forester 2016", "Impreza 22B 1998", "Impreza WRX 1993", "Impreza WRX STI 2005", "Impreza WRX STI 2010", "Justy 1984", "Legacy 1989", "Legacy 1993", "Legacy 1998", "Legacy 2003", "Legacy 2009", "Legacy 2016", "Leone 1971", "Leone 1979", "Leone 1984", "Levorg 2016", "Outback 2008", "Rex 1972", "Rex 1981", "Rex 1986", "Tribeca 2006", "WRX STI 2015", "XT 1985", "XV 2016" };
            System.Object[] Suzukicars = { "Alto 2004", "Baleno 2016", "Celerio 2016", "Ertiga 2016", "Ignis 2016", "Ignis Sport 2004", "Jimny 2007", "Kizashi 4x4 2010", "Liana 2001", "Pikes Peak XL7 2007", "SC100 1977", "Splash 2008", "Splash 2012", "Swift 2016", "Swift Rally Spec 2008", "Swift Sport 2006", "SX4 2006", "SX4 S-Cross 2016", "Vitara 2005", "Vitara S 2016", "Wagon R 1993", "X-90 1995", "XL-7 1998" };
            System.Object[] TVRcars = { "1600M 1972", "280i 1984", "3000S 1973", "400SE 1988", "450 SEAC 1988", "450SE 1989", "Cerbera Speed 12 2000", "Cerbera Speed Six 1998", "Chimaera 5.0 1993", "Grantura 1958", "Griffith 2020", "Griffith 200 1965", "Griffith 4.3 1992", "Griffith 400 1964", "Griffith 500 1993", "Sagaris 2005", "S-Series V8S 1986", "T350 2002", "Taimar 1976", "Taimar Turbo 1977", "Tamora 2001", "Tasmin 350i Convertible 1984", "Tuscan Convertible 2005", "Tuscan race car 1989", "Tuscan S 2005", "Tuscan V8 1967", "Typhon 2000", "Vixen S2 1970" };
            System.Object[] Vauxhallcars = { "Adam 1.2 2016", "Adam Rocks S 2015", "Antara 2.2CDTi 2016", "Astra 2016", "Astra 1.2 1984", "Astra 1.4i 1991", "Astra 1.4i 1998", "Astra 1.6 1979", "Astra 1.6 CDTi 2009", "Astra 1.6i 2004", "Astra GTE 1988", "Astra VXR 2010", "Calibra Turbo 1992", "Carlton GSi3000 24v 1989", "Cascada 2016", "Cavalier 1.6 1988", "Cavalier 1600L 1975", "Cavalier SRi 1981", "Chevette HSR 1980", "Corsa 1.4 2016", "Corsa 1.4i 1993", "Corsa VXR 2016", "Firenza 2000 SL Coupe 1971", "Firenza Baby Bertha 1974", "Firenza Old Nail 1971", "Frontera 1989", "GTC VXR 2016", "HP Firenza 1973", "Insignia 2.0 CDTi 2016", "Insignia Grand Sport 2018", "Insignia VXR S'sport 2016", "Insignia VXR Unlimited 2011", "Maloo R8 LSA 2016", "Mokka 4x4 2016", "Nova GTE 1987", "Opel Adam R2 2016", "Opel Admiral V8 1965", "Opel Ascona 400 1979", "Opel Corsa Super 1600 2001", "Opel Diplomat A V8 Coupe 1965", "Opel GT 1968", "Opel GT 2007", "Opel GT Concept 2016", "Opel GTC Concept 2007", "Opel Insignia Country Tourer 2013", "Opel Kadett GT/E 1975", "Opel Kadett Rallye E 4S 1985", "Opel Manta 400 1979", "Opel Manta 400 Rally 1982", "Opel Manta GTE 1988", "Opel Monza GSE 1983", "Opel OPC Extreme 2014", "Opel Vectra GSi 1988", "PA Velox 1959", "Senator 1987", "Signum 2003", "Tigra 1994", "Tigra TwinTop 2004", "Vectra 2.5 V6 1995", "Vectra VXR 2006", "VX220 2000", "VX220 Turbo 2003", "VXR8 GTS 2016" };
            System.Object[] Volkswagencars = { "Arteon 2017", "Atlas 2018", "Beetle 1970", "Beetle 2011", "Beetle Cabriolet 1970", "Beetle Cabriolet 2012", "CC 2008", "Corrado 1988", "Corrado 16v G60 1988", "Corrado VR6 1992", "Country Buggy 1968", "Fox 2005", "Golf 1974", "Golf 1983", "Golf 1991", "Golf 1997", "Golf 2003", "Golf 2017", "Golf G60 Rallye 1988", "Golf GTD 2009", "Golf GTI 1982", "Golf GTI 1985", "Golf GTI 1991", "Golf GTI 1997", "Golf GTI 2004", "Golf GTI 2009", "Golf GTI 2013", "Golf GTI G60 1990", "Golf GTI TCR 2018", "Golf GTI W12 2007", "Golf R 2012", "Golf R 2015", "Golf R32 2005", "Golf R400 2015", "Golf VR6 1991", "I.D. R Pikes Peak 2018", "Jetta 1980", "Jetta 2004", "Jetta 2008", "Jetta 2011", "Jetta 2019", "Jetta GTI 1988", "Jetta VR6 1992", "Karmann Ghia 1974", "Lupo GTI 2001", "New Beetle 1999", "New Beetle Cabriolet 2003", "New Beetle RSi 2000", "Passat 1975", "Passat 1983", "Passat 1988", "Passat 1993", "Passat 2006", "Passat 2018", "Phaeton 2002", "Phaeton 2014", "Polo 1976", "Polo 1984", "Polo 1994", "Polo 2003", "Polo 2009", "Polo 2018", "Polo GT G40 1987", "Polo GTI 1999", "Polo GTI 2006", "Polo GTI 2010", "Polo GTI 2018", "Scirocco 1982", "Scirocco 2008", "Scirocco GTI 1986", "Scirocco R 2009", "Sharan 2008", "Sharan 2015", "Tiguan 2011", "Tiguan 2017", "Touareg 2008", "Touareg 2010", "Touareg 2018", "Touran 2003", "Touran 2015", "Transporter 1996", "Transporter 2004", "Transporter 2016", "T-Roc 2017", "Type 2 1966", "Type 2 1970", "Type 2 1979", "up! 2013", "up! GTI 2018", "W12 Nardo 2001", "W12 Roadster 1997", "W12 Syncro 1997" };
            System.Object[] Volvocars = { "145 1971", "1800ES 1972", "240 GLT 1988", "360 GLT 1983", "440 GLT 1992", "480 Turbo 1988", "740 Turbo 1990", "850 AWD 1997", "850 BTCC 1994", "850 R 1997", "850 T-5R 1995", "960 3.0 1991", "Amazon 1958", "C30 Polestar Performance 2010", "C30 T5 R-Design 2008", "C303 Paris Dakar 1983", "C70 T5 2013", "C70 T5 2.3 2003", "P1800 1961", "Polestar 1 2020", "S60 R AWD 2004", "S60 T6 2013", "S60 T8 AWD 2020", "S80 V8 2006", "S90 T5 2016", "S90 T8 2018", "V40 T5 2018", "V60 Polestar 2015", "V60 T8 Polestar 2020", "V70 R 2000", "V90 T8 AWD 2018", "XC40 T5 2019", "XC60 T8 2018", "XC90 T5 2018", "XC90 T8 Twin Engine 2016", "XC90 V8 2010" };
            comboBox3.Items.Clear();
            comboBox3.Text = null;

            switch (comboBox2.Text)
            {
                case "Acura":
                    comboBox3.Items.AddRange(Acuracars);
                    break;
                case "Alfa Romeo":
                    comboBox3.Items.AddRange(AlfaRomeocars);
                    break;
                case "Ariel":
                    comboBox3.Items.AddRange(Arielcars);
                    break;
                case "Aston Martin":
                    comboBox3.Items.AddRange(AstonMartincars);
                    break;
                case "Audi":
                    comboBox3.Items.AddRange(Audicars);
                    break;
                case "Austin":
                    comboBox3.Items.AddRange(Austincars);
                    break;
                case "Bentley":
                    comboBox3.Items.AddRange(Bentleycars);
                    break;
                case "BMW":
                    comboBox3.Items.AddRange(BMWcars);
                    break;
                case "Bugatti":
                    comboBox3.Items.AddRange(Bugatticars);
                    break;
                case "Buick":
                    comboBox3.Items.AddRange(Buickcars);
                    break;
                case "Cadillac":
                    comboBox3.Items.AddRange(Cadillaccars);
                    break;
                case "Caterham":
                    comboBox3.Items.AddRange(Caterhamcars);
                    break;
                case "Chevrolet":
                    comboBox3.Items.AddRange(Chevroletcars);
                    break;
                case "Chrysler":
                    comboBox3.Items.AddRange(Chryslercars);
                    break;
                case "Citroen":
                    comboBox3.Items.AddRange(Citroencars);
                    break;
                case "De Tomaso":
                    comboBox3.Items.AddRange(DeTomasocars);
                    break;
                case "Dodge":
                    comboBox3.Items.AddRange(Dodgecars);
                    break;
                case "Donkervoort":
                    comboBox3.Items.AddRange(Donkervoortcars);
                    break;
                case "DS":
                    comboBox3.Items.AddRange(DScars);
                    break;
                case "Fiat":
                    comboBox3.Items.AddRange(Fiatcars);
                    break;
                case "Ford":
                    comboBox3.Items.AddRange(Fordcars);
                    break;
                case "GMC":
                    comboBox3.Items.AddRange(GMCcars);
                    break;
                case "Gumpert":
                    comboBox3.Items.AddRange(Gumpertcars);
                    break;
                case "Honda":
                    comboBox3.Items.AddRange(Hondacars);
                    break;
                case "Hummer":
                    comboBox3.Items.AddRange(Hummercars);
                    break;
                case "Infiniti":
                    comboBox3.Items.AddRange(Infiniticars);
                    break;
                case "Jaguar":
                    comboBox3.Items.AddRange(Jaguarcars);
                    break;
                case "Koenigsegg":
                    comboBox3.Items.AddRange(Koenigseggcars);
                    break;
                case "KTM":
                    comboBox3.Items.AddRange(KTMcars);
                    break;
                case "Lamborghini":
                    comboBox3.Items.AddRange(Lamborghinicars);
                    break;
                case "Lancia":
                    comboBox3.Items.AddRange(Lanciacars);
                    break;
                case "Land Rover":
                    comboBox3.Items.AddRange(LandRovercars);
                    break;
                case "Lotus":
                    comboBox3.Items.AddRange(Lotuscars);
                    break;
                case "Maserati":
                    comboBox3.Items.AddRange(Maseraticars);
                    break;
                case "Mazda":
                    comboBox3.Items.AddRange(Mazdacars);
                    break;
                case "McLaren":
                    comboBox3.Items.AddRange(McLarencars);
                    break;
                case "Mercedes-Benz":
                    comboBox3.Items.AddRange(MercedesBenzcars);
                    break;
                case "MG":
                    comboBox3.Items.AddRange(MGcars);
                    break;
                case "Mini":
                    comboBox3.Items.AddRange(Minicars);
                    break;
                case "Mitsubishi":
                    comboBox3.Items.AddRange(Mitsubishicars);
                    break;
                case "Nissan":
                    comboBox3.Items.AddRange(Nissancars);
                    break;
                case "Pagani":
                    comboBox3.Items.AddRange(Paganicars);
                    break;
                case "Peugeot":
                    comboBox3.Items.AddRange(Peugeotcars);
                    break;
                case "Plymouth":
                    comboBox3.Items.AddRange(Plymouthcars);
                    break;
                case "Pontiac":
                    comboBox3.Items.AddRange(Pontiaccars);
                    break;
                case "Porsche":
                    comboBox3.Items.AddRange(Porschecars);
                    break;
                case "Ram":
                    comboBox3.Items.AddRange(Ramcars);
                    break;
                case "Renault":
                    comboBox3.Items.AddRange(Renaultcars);
                    break;
                case "Rimac":
                    comboBox3.Items.AddRange(Rimaccars);
                    break;
                case "Rover":
                    comboBox3.Items.AddRange(Rovercars);
                    break;
                case "RUF":
                    comboBox3.Items.AddRange(RUFcars);
                    break;
                case "Scuderia Cameron Glickenhaus":
                    comboBox3.Items.AddRange(ScuderiaCameronGlickenhauscars);
                    break;
                case "Smart":
                    comboBox3.Items.AddRange(Smartcars);
                    break;
                case "Spyker":
                    comboBox3.Items.AddRange(Spykercars);
                    break;
                case "Subaru":
                    comboBox3.Items.AddRange(Subarucars);
                    break;
                case "Suzuki":
                    comboBox3.Items.AddRange(Suzukicars);
                    break;
                case "TVR":
                    comboBox3.Items.AddRange(TVRcars);
                    break;
                case "Vauxhall":
                    comboBox3.Items.AddRange(Vauxhallcars);
                    break;
                case "Volkswagen":
                    comboBox3.Items.AddRange(Volkswagencars);
                    break;
                case "Volvo":
                    comboBox3.Items.AddRange(Volvocars);
                    break;
                default:
                    break;
            }
        } //формируется функцией ManModY, PL12

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label49.Text = "default";
            string thecar;
            string wantedcar = comboBox2.Text + " " + comboBox3.Text;
            for (int i = 0; i < linenumber; i++)
            {
                thecar = fulltablearray[i, 8] + " " + fulltablearray[i, 9] + " " + fulltablearray[i, 15];
                if (wantedcar == thecar)
                {
                    label52.Text = fulltablearray[i, 16];
                    break;
                }
            }
        }
        
        private void WriteCashCars()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\NewRqPL12\CashCarsPL12.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < linenumber; i++)
                {
                    sw.WriteLine(fulltablearray[i, 16]);
                }
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Bot\bettertestPL12.txt", false, System.Text.Encoding.Default))
            {
                string thecar;
                for (int i = 0; i < linenumber; i++)
                {
                    thecar = fulltablearray[i, 2] + " " + fulltablearray[i, 8] + " " + fulltablearray[i, 9] + " " + fulltablearray[i, 15];
                    if (Convert.ToInt32(fulltablearray[i, 16]) > 0)
                        sw.WriteLine(thecar + " " + fulltablearray[i, 16]);
                }
                sw.Close();
            }

            Filter();
        }

        private void AddCashCar()
        {
            string thecar;
            bool found = false;
            int number = Convert.ToInt32(textBox42.Text);
            string wantedcar = comboBox2.Text + " " + comboBox3.Text;
            for (int i = 0; i < linenumber; i++)
            {
                thecar = fulltablearray[i, 8] + " " + fulltablearray[i, 9] + " " + fulltablearray[i, 15];
                if (wantedcar == thecar)
                {
                    int oldnumber = Convert.ToInt32(fulltablearray[i, 16]);
                    fulltablearray[i, 16] = (oldnumber + number).ToString();
                    label52.Text = fulltablearray[i, 16];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                label49.Text = "Машина не найдена";
            }
            else
            {
                label49.Text = "Машина найдена";
            }
            WriteCashCars();
        }

        private void SetCashCar()
        {
            string thecar;
            bool found = false;
            int number = Convert.ToInt32(textBox42.Text);
            string wantedcar = comboBox2.Text + " " + comboBox3.Text;
            for (int i = 0; i < linenumber; i++)
            {
                thecar = fulltablearray[i, 8] + " " + fulltablearray[i, 9] + " " + fulltablearray[i, 15];
                if (wantedcar == thecar)
                {
                    fulltablearray[i, 16] = number.ToString();
                    label52.Text = fulltablearray[i, 16];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                label49.Text = "Машина не найдена";
            }
            else
            {
                label49.Text = "Машина найдена";
            }
            WriteCashCars();
        }

        private void RemoveCashCar()
        {
            string thecar;
            bool found = false;
            int number = Convert.ToInt32(textBox42.Text);
            string wantedcar = comboBox2.Text + " " + comboBox3.Text;
            for (int i = 0; i < linenumber; i++)
            {
                thecar = fulltablearray[i, 8] + " " + fulltablearray[i, 9] + " " + fulltablearray[i, 15];
                if (wantedcar == thecar)
                {
                    int oldnumber = Convert.ToInt32(fulltablearray[i, 16]);
                    fulltablearray[i, 16] = (oldnumber - number).ToString();
                    label52.Text = fulltablearray[i, 16];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                label49.Text = "Машина не найдена";
            }
            else
            {
                label49.Text = "Машина найдена";
            }
            WriteCashCars();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddCashCar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetCashCar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveCashCar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fulltable();
            PictureToNameTable();
        }
        
        //===================================================================

        //Дебаг

        public void Filter()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\filter.txt", false, System.Text.Encoding.Default))
            {
                string thecar;
                for (int i = 0; i < linenumber; i++)
                {
                    thecar = fulltablearray[i, 2] + " " + fulltablearray[i, 8] + " " + fulltablearray[i, 9] + " " + fulltablearray[i, 15];
                    if (Convert.ToInt32(fulltablearray[i, 16]) > 0)
                    {
                        if (fulltablearray[i, 2] == "f")
                        {
                            if(fulltablearray[i, 1] == "saloon")
                            {
                                sw.WriteLine(thecar + " " + fulltablearray[i, 16]);
                            }                            
                        }
                    }
                }
                sw.Close();
            }

            int allcars = 0;
            for (int i = 0; i < linenumber; i++)
            {
                allcars += Convert.ToInt32(fulltablearray[i, 16]);
            }
            textBox8.Text = allcars.ToString();
        }

        //Для обновы

        public void ManModY()
        {
            string commonpath = @"C:\Bot\NewRqPL12\";
            string prevmanufacturer = "default";
            string[] manufacturer = new string[linenumber];
            string[] model = new string[linenumber];
            string[] year = new string[linenumber];

            using (StreamReader sr = new StreamReader(commonpath + "manufacturer.txt", System.Text.Encoding.Default))
            {
                for (int i = 0; i < manufacturer.Length; i++)
                {
                    manufacturer[i] = sr.ReadLine();
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(commonpath + "model.txt", System.Text.Encoding.Default))
            {
                for (int i = 0; i < model.Length; i++)
                {
                    model[i] = sr.ReadLine();
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(commonpath + "year.txt", System.Text.Encoding.Default))
            {
                for (int i = 0; i < year.Length; i++)
                {
                    year[i] = sr.ReadLine();
                }
                sr.Close();
            }

            for (int i = 0; i < manufacturer.Length; i++)
            {
                if (manufacturer[i] != prevmanufacturer)
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\Bot\switchcasePL12.txt", true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("case \"" + manufacturer[i] + "\":");
                        sw.WriteLine("comboBox3.Items.AddRange(" + manufacturer[i] + "cars);");
                        sw.WriteLine("break;");
                        sw.Close();
                    }

                    using (StreamWriter sw = new StreamWriter(@"C:\Bot\allmanufacturerPL12.txt", true, System.Text.Encoding.Default))
                    {
                        if (prevmanufacturer != "default")
                        {
                            sw.WriteLine("};");
                        }
                        sw.Write("System.Object[] " + manufacturer[i] + "cars = { ");
                        prevmanufacturer = manufacturer[i];
                        sw.Close();
                    }

                    using (StreamWriter sw = new StreamWriter(@"C:\Bot\allmanufacturerPL12.txt", true, System.Text.Encoding.Default))
                    {
                        sw.Write("\"" + model[i] + " " + year[i] + "\"");
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\Bot\allmanufacturerPL12.txt", true, System.Text.Encoding.Default))
                    {
                        sw.Write(", ");
                        sw.Write("\"" + model[i] + " " + year[i] + "\"");
                        sw.Close();
                    }
                }
            }
        } //формирует список для комбо бокса2

        private void button1_Click(object sender, EventArgs e)
        {
            CarStats();
        }

        public void CarStats()//создание списка статов для бота на основе фуллтэйбл
        {
            int clearance;
            int tires;
            int drive;
            double acceleration;
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\CarStatsPL12.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine("switch (carname)");
                sw.WriteLine("{");
                for (int i = 1; i < linenumber; i++)
                {
                    switch (fulltablearray[i, 3])
                    {
                        case "low":
                            clearance = 1;
                            break;
                        case "mid":
                            clearance = 2;
                            break;
                        default:
                            clearance = 3;
                            break;
                    }
                    switch (fulltablearray[i, 13])
                    {
                        case "slick":
                            tires = 1;
                            break;
                        case "per":
                            tires = 2;
                            break;
                        case "std":
                            tires = 3;
                            break;
                        case "all":
                            tires = 4;
                            break;
                        default:
                            tires = 5;
                            break;
                    }
                    switch (fulltablearray[i, 5])
                    {
                        case "fwd":
                            drive = 1;
                            break;
                        case "rwd":
                            drive = 2;
                            break;
                        default:
                            drive = 4;
                            break;
                    }
                    acceleration = double.Parse(fulltablearray[i, 0]);
                    sw.WriteLine("case \"" + fulltablearray[i, 8] + " " + fulltablearray[i, 9] + " " + fulltablearray[i, 15] + "\":");
                    sw.WriteLine("NotePad.DoLog(\"" + fulltablearray[i, 8] + " " + fulltablearray[i, 9] + " " + fulltablearray[i, 15] + "\");");
                    sw.WriteLine("clearance = " + clearance + ";");
                    sw.WriteLine("tires = " + tires + ";");
                    sw.WriteLine("drive = " + drive + ";");
                    sw.WriteLine("acceleration = " + acceleration + ";");
                    sw.WriteLine("maxspeed = " + fulltablearray[i, 12] + ";");
                    sw.WriteLine("grip = " + fulltablearray[i, 7] + ";");
                    sw.WriteLine("weight = " + fulltablearray[i, 14] + ";");
                    //power
                    //torque
                    sw.WriteLine("break;");
                }
                sw.WriteLine("default:");
                sw.WriteLine("NotePad.DoLog(\"Неизвестная тачка\");");
                sw.WriteLine("clearance = 1;");
                sw.WriteLine("tires = 2;");
                sw.WriteLine("drive = 2;");
                sw.WriteLine("acceleration = 36;");
                sw.WriteLine("maxspeed = 100;");
                sw.WriteLine("grip = 45;");
                sw.WriteLine("weight = 2500;");
                //sw.WriteLine("power = 50;");
                //sw.WriteLine("torque = 50;");
                sw.Write("}");
            }
        }

        //===================================================================

        public void PictureToNameTable()
        {
            string commonpath = @"C:\Bot\NewRqPL12\";
            string path = "PictureToCar.txt";
            length = 0;
            using (StreamReader sr = new StreamReader(commonpath + path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    length++;
                }
                sr.Close();
            }
            picturetoname = new string[length, 2];

            using (StreamReader sr = new StreamReader(commonpath + path, System.Text.Encoding.Default))
            {
                for (int i = 0; i < length; i++)
                {
                    string theline = sr.ReadLine();
                    picturetoname[i, 0] = Transform3(theline, 1);
                    picturetoname[i, 1] = Transform3(theline, 2);
                }
                sr.Close();
            }
        }

        public string Transform3(string t, int wordN)
        {
            string forreturn;
            string a = t.Trim();
            char[] word = a.ToCharArray();

            int wordBlength = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != ' ')
                {
                    wordBlength++;
                }
                else break;
            }
            char[] wordB = new char[wordBlength];
            for (int i = 0; i < wordB.Length; i++)
            {
                wordB[i] = word[i];
            }

            char[] wordC = new char[word.Length - wordBlength - 1];
            for (int i = 0; i < wordC.Length; i++)
            {
                wordC[i] = word[i + wordBlength + 1];
            }

            if (wordN == 1)
            {
                forreturn = new string(wordB);
            }
            else
            {
                forreturn = new string(wordC);
            }
            return forreturn;
        }

        public void PictureToNameTableAdd()
        {
            string commonpath = @"C:\Bot\NewRqPL12\";
            string path = "PictureToCar.txt";
            string thecar = comboBox5.Text + " " + comboBox6.Text;
            using (StreamWriter sw = new StreamWriter(commonpath + path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(textBox1.Text + " " + thecar);
                sw.Close();
            }
            PictureToNameTable();
            textBox1.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
        }          

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string path = @"D:\Bot\thereisnothinginteresting\Finger1\";
            string ending = ".jpg";
            if(File.Exists(path + textBox1.Text + ending))
            {
                pictureBox1.Image = Image.FromFile(path + textBox1.Text + ending);
            }
            else
            {
                pictureBox1.Image = null;
            }

            label3.Text = "unknown";
            
            for(int i = 0; i < length; i++)
            {                
                if(picturetoname[i,0] == textBox1.Text)
                {
                    label3.Text = "known";
                    break;
                }
            }            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Object[] DEcars = { "Audi", "BMW", "Gumpert", "Mercedes-Benz", "Porsche", "Vauxhall", "Volkswagen", "Mini", "RUF", "Smart" };
            System.Object[] GBcars = { "Ariel", "Aston Martin", "Austin", "Bentley", "Caterham", "Ford", "Jaguar", "Land Rover",
                                       "Lotus", "McLaren", "MG", "Rover", "TVR", "Vauxhall"};
            System.Object[] FRcars = { "Bugatti", "Citroen", "DS", "Peugeot", "Renault" };
            System.Object[] ITcars = { "Alfa Romeo", "Fiat", "Lamborghini", "Lancia", "Maserati", "Pagani", "De Tomaso" };
            System.Object[] JPcars = { "Honda", "Infiniti", "Mazda", "Mitsubishi", "Nissan", "Subaru", "Suzuki" };
            System.Object[] UScars = { "Acura", "Buick", "Cadillac", "Chevrolet", "Chrysler", "Dodge", "Ford", "GMC", "Hummer",
                                        "Plymouth", "Pontiac", "Ram", "Scuderia Cameron Glickenhaus", };
            System.Object[] ATcars = { "KTM" };
            System.Object[] SEcars = { "Volvo", "Koenigsegg" };
            System.Object[] AUcars = { "Vauxhall" };
            System.Object[] HRcars = { "Rimac" };
            System.Object[] NLcars = { "Donkervoort", "Spyker" };
            comboBox5.Items.Clear();
            comboBox5.Text = null;
            comboBox6.Items.Clear();
            comboBox6.Text = null;
            switch (comboBox4.Text)
            {
                case "DE":
                    comboBox5.Items.AddRange(DEcars);
                    break;
                case "GB":
                    comboBox5.Items.AddRange(GBcars);
                    break;
                case "US":
                    comboBox5.Items.AddRange(UScars);
                    break;
                case "IT":
                    comboBox5.Items.AddRange(ITcars);
                    break;
                case "JP":
                    comboBox5.Items.AddRange(JPcars);
                    break;
                case "FR":
                    comboBox5.Items.AddRange(FRcars);
                    break;
                case "SE":
                    comboBox5.Items.AddRange(SEcars);
                    break;
                case "AT":
                    comboBox5.Items.AddRange(ATcars);
                    break;
                case "AU":
                    comboBox5.Items.AddRange(AUcars);
                    break;
                case "HR":
                    comboBox5.Items.AddRange(HRcars);
                    break;
                case "NL":
                    comboBox5.Items.AddRange(NLcars);
                    break;
                default:
                    break;
            }
        } //копия комбобокса1, PL12

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Object[] Acuracars = { "Integra GS-R 1994", "Legend 3.2 V6 1990", "NSX 2016", "NSX-T 1998" };
            System.Object[] AlfaRomeocars = { "33 1993", "75 1985", "90 1984", "146 1996", "155 1992", "159 2005", "166 1998", "145 Cloverleaf 1994", "147 GTA 2002", "155 TS BTCC 1994", "156 GTA 2002", "164 ProCar 1988", "164 Super 1993", "1750 GTV 1967", "2000 GTV 1971", "2000 Sportiva 1954", "2600 SZ 1965", "4C 2017", "6C 2500 Villa d'Este 1949", "8C Competizione 2007", "8C Spider 2010", "Alfa 6 1980", "Alfasud 1982", "Alfasud Sprint 1976", "Alfetta GT Rally Version 1975", "Alfetta GTV 1976", "Autodelta 156 GTA 3.7 V6 2004", "Brera S 2008", "Carabo 1968", "Disco Volante (8C) 2013", "Disco Volante (C52) 1952", "Giulia GTA Stradale 1965", "Giulia Quadrifoglio 2017", "Giulia TZ 1963", "Giulia Veloce 2017", "Giulietta 2017", "Giulietta Spider 1955", "GT 2003", "GT 1600 Junior 1972", "GTA 1300 Junior 1968", "GTV 1998", "Mito 2017", "MiTo GTA 2009", "Montreal 1970", "Scighera 1997", "Spider 2006", "Spider (S1) 1969", "Spider (S3) 1983", "Spider (S4) 1990", "Spider Veloce (S2) 1971", "Sprint GT 1963", "Sprint GTV 1965", "Stelvio Quadrifoglio 2018", "SZ 1989", "Tipo 33 Stradale 1967" };
            System.Object[] Arielcars = { "Atom 1 1999", "Atom 2 Supercharged 2003", "Atom 3 2008", "Atom 3 Supercharged 2008", "Atom 3.5 2013", "Atom 4 2018", "Atom 500 V8 2011", "Nomad 2018" };
            System.Object[] AstonMartincars = { "Bulldog 1980", "CC100 Speedster 2013", "Cygnet 2011", "DB AR1 2002", "DB10 2015", "DB11 2016", "DB3S 1953", "DB4 1958", "DB4 GT Zagato 1961", "DB5 1963", "DB6 1965", "DB7 1993", "DB7 GT 2002", "DB7 Vantage 1999", "DB7 Zagato 2002", "DB9 2004", "DBS 1967", "DBS Carbon Black Edition 2010", "DBS Superleggera 2019", "DBS Superleggera Volante 2019", "DBS V12 2007", "Lagonda 1976", "Lagonda Vignale 1993", "One-77 2009", "Rapide 2010", "Rapide Bertone Jet 2+2 2013", "Rapide S 2014", "V12 Vanquish 2001", "V12 Vanquish S 2004", "V12 Vantage 2009", "V12 Vantage Carbon Black Edition 2010", "V12 Vantage RS 2007", "V12 Zagato 2012", "V8 1972", "V8 Coupe 1996", "V8 Vantage 1977", "V8 Vantage 2005", "V8 Vantage N400 2007", "V8 Vantage Volante 2000", "V8 Volante 1986", "V8 Volante 1996", "V8 Zagato 1986", "Vanquish S 2016", "Vanquish Volante 2013", "Vanquish Zagato 2017", "Vantage 1993", "Vantage 2018", "Virage 1989", "Virage 2011", "Virage Volante 1992", "Virage Volante 2011", "Vulcan 2018" };
            System.Object[] Audicars = { "quattro 1980", "quattro 20V 1990", "R8 Coupe V10 plus 2015", "R8 Spyder V10 2013", "RS 2 Avant 1994", "RS 3 Sportback 2015", "RS 4 Avant 2000", "RS 4 Avant 2006", "RS 5 Cabriolet 2012", "RS 6 Avant (delimited) 2013", "RS 6 plus 2004", "RS 7 Sportback 2015", "RS Q3 2015", "S1 2014", "S2 Coupe 1993", "S3 2006", "S4 1998", "S4 2012", "S4 Avant 2004", "S5 Coupe 2008", "S6 1997", "S6 2003", "S8 2006", "S8 plus 2015", "Sport quattro S1 1985", "SQ5 2015", "TT RS plus Coupe 2012", "TTS Coupe 2015" };
            System.Object[] Austincars = { "1100 1963", "Allegro 1979", "Ambassador 1982", "Healey 3000 1959", "Healey Sprite 1958", "Maxi 1969" };
            System.Object[] Bentleycars = { "Arnage 1999", "Arnage FInal Series 2009", "Arnage T 2007", "Azure 1995", "Azure 2006", "Azure T 2009", "Bentayga Diesel 2019", "Bentayga V8 2019", "Bentayga W12 2019", "Brooklands 1992", "Brooklands 2008", "Continental 24 2017", "Continental Breitling Jet Team Series Limited Edition 2016", "Continental Flying Spur 2005", "Continental GT 2003", "Continental GT 2006", "Continental GT 2012", "Continental GT 2019", "Continental GT Convertible 2020", "Continental GT Convertible Number 1 Edition by Mulliner 2020", "Continental GT Number 9 Edition by Mulliner 2019", "Continental GT Pikes Peak 2019", "Continental GT Speed Coupe 2015", "Continental GT V8 2019", "Continental GT V8 S 2014", "Continental GT3 2013", "Continental GT3 2018", "Continental GT3-R 2015", "Continental R 1991", "Continental Supersports 2010", "Continental Supersports 2017", "Continental Supersports Convertible 2011", "Continental Supersports Convertible ISR 2011", "Continental T 1999", "EXP 100 GT 2019", "Flying Spur 2018", "Flying Spur 2020", "Flying Spur V8 S 2017", "Flying Spur W12 2017", "Flying Spur W12 S 2017", "Hunaudieres 1999", "Mulsanne 2019", "Mulsanne Blue Train Limited Edition 2015", "Mulsanne Design Series 2017", "Mulsanne Extended Wheelbase 2017", "Mulsanne Grand Convertible 2014", "Mulsanne Grand Limousine 2019", "Mulsanne S 1987", "Mulsanne Speed 2019", "Mulsanne Turbo 1983", "Mulsanne W.O. Edition 2018", "The Sir Peter Blake Continental GT 2016", "Turbo R 1985" };
            System.Object[] BMWcars = { "316 1975", "507 1956", "525 1973", "1800 1963", "116d 2015", "123d 2007", "130i 2005", "130i 2007", "135i Convertible 2008", "1-series M coupe 2011", "2002 Tii 1972", "2002 turbo 1973", "220d Active Tourer 2014", "220d xDrive Gran Tourer 2015", "2800 CS 1968", "320d 2005", "320d Touring 2010", "320Si 2005", "323i 1995", "325i 1982", "325i Convertible 2009", "325iX 1988", "328i 1991", "328i Gran Turismo 2014", "330d 1998", "330d 2005", "330d Touring 2014", "330e 2016", "330i 1998", "335d 2016", "335i 2008", "435i Gran Coupe 2014", "440i 2018", "520d Touring 2012", "520d Touring 2017", "520d xDrive 2017", "520i 2016", "524td 1983", "525ix 1991", "530d 2004", "530i 1996", "535d Touring 2009", "535i 2010", "540i 1993", "540i 1996", "545i 2004", "635CSi 1980", "640d 2011", "640d 2016", "640i xDrive 2012", "640i xDrive Gran Turismo 2017", "645ci 2003", "650i Convertible 2005", "650i Convertible 2012", "728i 1977", "730d 2002", "730d 2008", "730i 1986", "740d 2016", "740i 1994", "750d xDrive 2013", "750i 2016", "750iL 1995", "750Li 2009", "850CSi 1992", "H2R 2004", "i3 2013", "i3 S 2017", "i8 2014", "i8 Roadster 2018", "Isetta 250 1955", "M Coupe 1998", "M1 1978", "M1 Procar Group 4 1979", "M135i 2016", "M140i 2017", "M2 (delimited) 2016", "M2 Competition (delimited) 2019", "M240i 2017", "M240i Convertible 2016", "M3 1986", "M3 1993", "M3 2001", "M3 2008", "M3 CRT 2011", "M3 CS 2018", "M3 CSL 2003", "M3 GTR 2001", "M3 GTS 2010", "M4 2016", "M4 GTS 2016", "M5 1985", "M5 1988", "M5 1998", "M5 2004", "M5 2016", "M5 2018", "M5 Competition (delimited) 2018", "M6 2006", "M6 2016", "M6 Convertible 2006", "M6 Gran Coupe 2013", "M760Li xDrive V12 2015", "M8 GTE 2018", "M850i xDrive 2018", "M850i xDrive Convertible 2019", "Nazca C2 1992", "X1 2010", "X1 2017", "X2 2018", "X3 2003", "X3 35d 2014", "X3 M40i 2018", "X3 xDrive 28d 2016", "X4 2018", "X5 2008", "X5 4.4i 2000", "X5 40e (PHEV) 2016", "X5 M 2009", "X5 M50d 2016", "X6 2012", "X6 2015", "X6 M 2009", "Z1 1989", "Z3 2.2l 2000", "Z4 3.0si 2006", "Z4 sDrive18i 2013", "Z4 sDrive28i 2016", "Z4M Coupe 2006", "Z8 2000" };
            System.Object[] Bugatticars = { "Chiron 2017", "Chiron Sport 2019", "EB110 GT 1992", "EB110 Super Sport 1992", "Veyron 16.4 2005", "Veyron 16.4 Grand Sport 2009", "Veyron 16.4 Super Sport 2010" };
            System.Object[] Buickcars = { "Century Special Coupe 1973", "Enclave 2008", "GNX 1987", "LaCrosse CXL 2005", "LeSabre 2000", "Park Avenue 2000", "Reatta 1988", "Regal GS 2012", "Regal Turbo 2011", "Rendezvous 2002", "Riviera Coupe 1965", "Roadmaster 1954", "Skylark GS 1954", "Verano 2012" };
            System.Object[] Cadillaccars = { "Allante 1989", "ATS-V 2016", "Cien 2002", "Cimarron 1982", "CT6 2016", "CTS 2016", "CTS Coupe 2016", "CTS Sport Wagon 2014", "CTS Vsport 2015", "CTS-V 2004", "CTS-V 2016", "CTS-V Sport Wagon 2010", "DeVille 1977", "DTS 2006", "Eldorado 1979", "Eldorado 1991", "Eldorado 1995", "Elmiraj 2013", "ELR 2016", "Escalade 1999", "Escalade 2002", "Escalade 2011", "Escalade ESV 2016", "Escalade EXT 2011", "Sedan De Ville 2000", "Seville 1980", "Sixteen 2003", "SRX 2006", "STS 2005", "STS-V 2005", "XLR roadster 2004", "XLR-V 2006", "XT5 2016" };
            System.Object[] Caterhamcars = { "21 1995", "CSR 2005", "JPE 1992", "RS Levante 2008", "Seven 160 2013", "Seven 270 2015", "Seven 360 2015", "Seven 420 2015", "Seven 620R 2013", "Superlight R500 2008" };
            System.Object[] Chevroletcars = { "454 SS 1990", "Aerovette 1977", "Aveo 2011", "Bel Air 1957", "Beretta GTZ 1991", "Blazer 2000", "Blazer S-10 1983", "Camaro berlinetta 1985", "Camaro IROC Z/28 1990", "Camaro IROC-Z 1985", "Camaro SS 2017", "Camaro SS 2019", "Camaro SS Convertible 2012", "Camaro SS Coupe 2010", "Camaro Z/28 1970", "Camaro Z/28 1977", "Camaro Z/28 1993", "Camaro Z/28 2015", "Camaro Z28 SS 1999", "Camaro ZL1 2012", "Camaro ZL1 2015", "Camaro ZL1 1LE 2018", "Caprice 1991", "Captiva 2007", "Captiva LTX 2008", "Chevelle SS 454 1970", "Chevette 1976", "Cobalt SS S/C 2006", "Cobalt SS Turbo 2009", "Code 130R 2012", "Colorado ZR2 2018", "COPO Camaro 2012", "Copo Camaro 2018", "Corvette 1953", "Corvette 2009", "Corvette 396 1965", "Corvette C4 1984", "Corvette C5 1997", "Corvette Grand Sport 1996", "Corvette Grand Sport 2017", "Corvette LT-1 1970", "Corvette Stingray Z51 2016", "Corvette Z06 2001", "Corvette Z06 2006", "Corvette Z06 2016", "Corvette Z06 Lingenfelter 2006", "Corvette ZR1 1971", "Corvette ZR1 1993", "Corvette ZR1 2019", "Corvette ZR2 1972", "Cruze LS 2009", "Cruze LT 2012", "Cruze SW 2012", "El Camino 1963", "El Camino 1981", "El Camino SS 454 1969", "Fleetline 1948", "HHR SS Turbocharged 2008", "Impala 1959", "Impala SS 1964", "Impala SS 1996", "Impala SS427 1967", "K5 Blazer 5.7L 1972", "Lacetti 2004", "Lumina Z34 1991", "Malibu 2019", "Matiz 2005", "Miray 2011", "Monte Carlo 1970", "Monte Carlo SS 1983", "Monte Carlo SS 2006", "Monte Carlo SS Jeff Gordon Edition 2003", "Orlando LTZ 2010", "S-10 Blazer Xtreme 1999", "Silverado 2016", "Silverado SS 2006", "Spark 2009", "SSR 2003", "SSR 6.0L 2007", "Suburban 2016", "Tahoe 1995", "Tahoe Custom 2018", "Trailblazer SS 2006", "Tru 140S 2012", "Volt 2012" };
            System.Object[] Chryslercars = { "200 2017", "300 2018", "300 SRT8 2012", "300 SRT-8 2005", "300 Touring 2005", "300H 1962", "300M Special Edition 2002", "Aspen Hybrid 2009", "Crossfire Coupe 2004", "Crossfire Roadster 2004", "Crossfire SRT-6 Coupe 2004", "Drifter 1977", "Imperial 1990", "Laser XT 1984", "LeBaron GTS Turbo 1985", "LHS 1994", "ME Four-Twelve 2004", "Newport 1968", "Pacifica 2018", "Prowler 2001", "PT Cruiser 2004", "Sebring 1995", "Sebring 2001", "Sebring 2007", "Sebring Convertible 1996", "TC by Maserati 1990", "Town and Country 1990", "Town and Country 1991", "Town and Country 1996", "Town and Country 2001", "Town and Country 2008", "Turbine Car 1963" };
            System.Object[] Citroencars = { "2CV 6 1979", "Ami Super 1973", "AX GTi 1993", "Axel 12 TRS 1984", "BX 16v 1987", "BX 17 D Turbo Break 1982", "BX 4TC 1982", "BX 4TC Group B 1986", "C1 VTi 68 2015", "C2 VTS 2003", "C2-R2 Max 2008", "C3 Aircross 2018", "C3 Picasso 2016", "C3 PureTech 110 2016", "C3-XR 2014", "C4 2.0 16v VTS 2004", "C4 Cactus 2.0 HDi 16v 2014", "C4 Picasso THP 165 2016", "C5 Aircross 2018", "C5 Crosstourer 2014", "C5 HPi 2001", "C5 Saloon 1.6 L 2004", "C5 Tourer 3.0 L 2016", "C5 V6 2003", "C6 3.0 L V6 HDi 2005", "C-Crosser 2.2 L HDi 2007", "CX GTi Turbo 1974", "CXperience 2016", "C-Zero 2016", "Grand C4 Picasso 2015", "GSA 1979", "GT 2008", "GZ 1973", "M35 1969", "Mehari 4x4 1980", "Metropolis 2010", "Saxo VTS 16V 1996", "SM 2.7 Injection 1972", "Traction Avant 1934", "Visa GTi 1978", "Xantia Activa V6 1997", "Xantia VSX 1993", "XM V6 24V 1989", "Xsara Picasso 1997", "Xsara VTS 1997", "ZX Volcane TD 1991" };
            System.Object[] DeTomasocars = { "Deauville 1971", "Guara 1993", "Guara 1998", "Longchamp 1973", "Longchamp GTS 1989", "Mangusta 1967", "Mangusta 1967", "Pantera GT5 1984", "Pantera GT5-S 1989", "Pantera GTS 1974", "Pantera L 1973", "Pantera SI 1991", "Vallelunga Competizione 1964" };
            System.Object[] Dodgecars = { "Avenger 1995", "Caliber R/T AWD 2007", "Caliber SRT4 2008", "Caravan Turbo 1989", "Challenger GT AWD 2018", "Challenger SRT Demon 2017", "Challenger SRT Hellcat 2015", "Challenger SRT Hellcat Widebody 2018", "Challenger T/A 1970", "Charger Daytona 2017", "Charger R/T Scat Pack 2015", "Charger SRT Hellcat 2015", "Charger SRT-8 2006", "Coronet Super Bee 1968", "Dakota R/T 1998", "Dart 2017", "Daytona IROC R/T 1992", "Durango GT 2018", "Grand Caravan 2018", "Intrepid 1993", "Journey 2018", "Magnum SRT-8 2006", "Monaco 1974", "Neon R/T Coupe 1998", "Nitro R/T 2007", "Spirit R/T 1991", "SRT Viper 2013", "SRT-4 2004", "Stealth 1995", "Stealth R/T Twin Turbo 1990", "Viper ACR 2016", "Viper GTS-R 1996", "Viper RT/10 1992" };
            System.Object[] Donkervoortcars = { "D10 1988", "D8 270 2008", "D8 270 RS 2006", "D8 Audi (AGU) 1999", "D8 Audi (E-gas) Wide Track 2004", "D8 Cosworth 1994", "D8 GT 2007", "D8 GTO 2014", "D8 GTO-40 2018", "D8 GTO-RS 2016", "D8 Zetec Sport 1994", "S7 1978", "S8 1980", "S8A 1983", "S8AT 1986" };
            System.Object[] DScars = { "4 2011", "5 2012", "3 Convertible 2016", "3 DSport HDi 2016", "3 Performance 2016", "DS 3 Racing 2011", "DS 6 2015", "DS 7 Crossback 2018", "DS 7 Crossback E-Tense 4x4 PHEV 2018", "DS Convertible 1958", "DS Numero 9 2012", "Survolt 2010", "Wild Rubis 2013" };
            System.Object[] Fiatcars = { "127 1971", "128 1969", "500 1957", "500 2017", "124 Spider 2017", "124 Sport Spider 1966", "126p 1972", "131 Mirafiori 1974", "500L 2012", "500X 2017", "8V 1952", "8V Supersonic 1953", "Abarth 030 1974", "Abarth 1000TC Berlina Corsa 1967", "Abarth 124 Spider 2017", "Abarth 124 Spider Rally 2016", "Abarth 131 Rally 1976", "Abarth 1500 Biposto 1952", "Abarth 500 Abarth 1964", "Abarth 595 Turismo 2012", "Abarth 695 Biposto 2017", "Abarth 695 Tributo Ferrari 2009", "Abarth 695 Tributo Maserati 2012", "Abarth 750 Zagato 1956", "Abarth Grande Punto 2010", "Abarth Grande Punto S2000 2006", "Abarth Simca 1300 Bialbero 1962", "Abarth Stilo Group N 2002", "Barchetta 1995", "Bravo 2007", "Campagnola 1951", "Campagnola 1974", "Cinquecento Sporting 1994", "Coupe 20v Turbo 1993", "Dino Coupe 1966", "Dino Spider 1966", "Fullback Cross 2017", "Multipla 1998", "Panda 1980", "Panda 2017", "Panda 100hp 2006", "Panda 4x4 1983", "Panda 4x4 2019", "Panda Cross 4x4 Mark 3 2014", "Punto 2017", "Punto 1.4 GT 1993", "Punto Cabrio 1993", "Punto HGT 1999", "Qubo 2009", "Seicento Rally Spec 1998", "Stilo 2.4 20v Schumacher GP 2002", "Strada Abarth 130TC 1982", "Tipo 2017", "Tipo 2.0 Sedicivalvole 1988", "Turbina 1954", "Uno Turbo 1985", "X1/9 1972", "X1/9 Dallara 1975" };
            System.Object[] Fordcars = { "B-Max 2012", "Capri 3.0 S 1978", "C-Max 2015", "Cortina 1974", "Ecosport 2016", "Edge 2016", "Escort Mexico 1972", "Escort Rally Spec 1970", "Escort Rally Spec 1979", "Escort RS Cosworth 1992", "Escort RS Turbo 1984", "Escort RS1600 1968", "Escort RS2000 1974", "Escort RS2000 1996", "Escort XR3i 1982", "F-150 SVT Raptor 2014", "Fiesta 1976", "Fiesta 1983", "Fiesta 1993", "Fiesta 1997", "Fiesta 2007", "Fiesta 1.0 2016", "Fiesta ST 2016", "Fiesta XR2 1981", "Fiesta XR2 1988", "Focus 2004", "Focus 2006", "Focus 2015", "Focus 1.0 2016", "Focus Bioethanol 2006", "Focus Coupe-Cabriolet 2007", "Focus RS 2002", "Focus RS 2009", "Focus RS500 2010", "Focus ST 2012", "Focus ST Mountune 2014", "Focus ST Superchips 2005", "Focus ST TDCi Estate 2016", "Focus ST170 2002", "Galaxy 2015", "Granada 2.8i S 1977", "GT 2005", "GT 2017", "GT40 1965", "GT90 1995", "Ka 2011", "Kuga 2016", "Mondeo 2004", "Mondeo 2013", "Mondeo 2017", "Mondeo 2.0tdci 2016", "Mondeo Hybrid 2016", "Mondeo ST200 1998", "Mondeo ST220 2000", "Mustang 2005", "Mustang 2005", "Mustang 2.3 2016", "Mustang 289 1966", "Mustang BOSS 302 2012", "Mustang GT 2016", "Mustang GT Power Pack 2016", "Puma 1.7 1997", "Racing Puma 2000", "Ranger 2006", "Ranger 2012", "Ranger 2016", "Ranger 2016", "Ranger Wildtrak 2012", "RS200 1984", "Scorpio 24-valve 1991", "Sierra RS Cosworth 1986", "Sierra RS Cosworth 4x4 1990", "Sierra RS500 1987", "Sierra XR4i 1983", "S-Max 2016", "Taurus SHO 2017", "Thunderbird 3.9l V8 2002", "Transit 2.2 TDCi 2013" };
            System.Object[] GMCcars = { "Acadia 2016", "Acadia Denali 2018", "Caballero Diablo 1984", "Denali XT 2008", "Envoy 1998", "Granite 2010", "Safari 1996", "Sierra All Terrain X 2017", "Syclone 1991", "Terrain 2010", "Typhoon 1993", "Yukon 2010", "Yukon Denali 2004", "Yukon XL 2014" };
            System.Object[] Gumpertcars = { "Apollo 2006", "Apollo Basic 2007", "Apollo Enraged 2012", "Apollo R 2012", "Apollo S 2010", "Intensa Emozione 2019", "N 2016" };
            System.Object[] Hondacars = { "Accord 1.8 1976", "Accord 3.5l V6 2016", "Accord Euro-R 2006", "Accord Hybrid 2016", "Accord Type R 1997", "Beat 1991", "Capa 4WD 1998", "City Cabriolet 1981", "City Turbo 1981", "Civic 1.8 2016", "Civic 1500 1979", "Civic CRX Si 1983", "Civic Hybrid 2013", "Civic Si 1995", "Civic Tourer 1.6d 2016", "Civic Type R 1999", "Civic Type R 2001", "Civic Type R 2006", "Civic Type R 2016", "Clarity 2016", "CR-V 1997", "CR-V 1.6 i-DTEC 2016", "CR-V 2.0 i-VTEC 2002", "CR-V 2.2 i-DTEC 2007", "CR-X 1.6i-16 1983", "CRX VTEC 1988", "CR-Z 2016", "EV Plus 1997", "FR-V 2.2 i-CTDi 2004", "HR-V 1.8 4WD 2016", "Insight 2000", "Integra Type R 1995", "Integra Type R 2002", "Jazz 2001", "Jazz 2016", "Jazz Hybrid 2007", "Legend 2.7 V6 1985", "Legend 3.5 V6 1995", "Legend 3.7 SH-AWD 2004", "NSX 1990", "NSX-R 2002", "Odyssey 2016", "Odyssey 2.3 1995", "Odyssey 3.5 V6 2005", "Pilot 4WD 2003", "Pilot 4WD 2009", "Pilot 4WD 2016", "Prelude 1978", "Prelude 2.0l 1982", "Prelude 2.0Si 4WS 1987", "Prelude Type S 1996", "Prelude VTEC 1991", "Ridgeline 2016", "S2000 1999", "S2000 Type S 2008", "S800 1967", "S-MX 4WD 1996", "Vamos 4WD Turbo 2016" };
            System.Object[] Hummercars = { "H1 1992", "H2 SUT 2005", "H2 SUV 2003", "H3 2006", "H3T 2009" };
            System.Object[] Infiniticars = { "FX35 2003", "G35 2002", "G35 2007", "G37 2009", "M35 2009", "M45 2003", "M45 2006", "Q30 2016", "Q50 2014", "Q60 2016", "Q70 2016", "QX30 2017", "QX50 2016", "QX70 2016" };
            System.Object[] Jaguarcars = { "C-Type 1951", "C-X75 2010", "C-X75 2013", "D-Type 1954", "E-PACE 2018", "E-Type 1961", "F-Pace 3.0 D 2016", "F-PACE SVR 2018", "F-Type Coupe 2016", "F-Type Project 7 2015", "F-Type R Convertible 2016", "F-Type R Coupe AWD 2016", "F-Type Rally Car 2018", "F-Type SVR Coupe 2017", "I-PACE 2018", "Mark 1 1957", "Mark 2 1959", "Mark 2 BTCC 1960", "SS 100 1936", "S-Type R 2007", "XE R-Dynamic S 2020", "XE S 2016", "XE SV Project 8 2017", "XF S 2016", "XFR-S Sportbrake 2016", "XJ 3.0 V6 2016", "XJ 5.0 V8 2010", "XJ12 1972", "XJ12 1974", "XJ12 1980", "XJ13 1966", "XJ220 1992", "XJ220S TWR 1994", "XJ6 1974", "XJ6 1986", "XJ-C 1975", "XJR 1995", "XJR 1998", "XJR 2003", "XJR 2013", "XJR 575 2018", "XJR-15 1990", "XJR-9 1988", "XJS 1988", "XJ-S Trans-Am 1978", "XJS TWR 1982", "XK Convertible 2010", "XK120 1948", "XK140 1954", "XK150 1957", "XK8 1997", "XKR 2008", "XKR 100 2002", "XKR 175 2010", "XKR 4.2-S 2005", "XKR 75 2010", "XKR-R 2001", "XKR-S Convertible 2011", "XKR-S GT 2014", "XKSS 1957", "X-Type 2001" };
            System.Object[] Koenigseggcars = { "Agera 2011", "Agera Final 2016", "Agera R 2014", "Agera RS 2015", "CC8S 2001", "CCR 2004", "CCX 2006", "CCXR 2007", "CCXR Edition 2008", "CCXR Trevita 2008", "Gemera 2020", "Jesko 2019", "Jesko Absolut 2020", "One:1 2014", "Regera 2015" };
            System.Object[] KTMcars = { "X-Bow GT 2016", "X-Bow GT4 2016", "X-Bow R 2016", "X-Bow RR 2016" };
            System.Object[] Lamborghinicars = { "350GT 1964", "400GT 1966", "Aventador Coupe 2011", "Aventador J 2012", "Aventador Roadster 2012", "Aventador S 2018", "Aventador S Roadster 2018", "Aventador SV 2015", "Aventador SV Roadster 2015", "Aventador SVJ 2018", "Centenario 2016", "Countach 25th Anniversario 1988", "Countach 5000 Quattrovalvole 1985", "Countach LP400 1974", "Countach LP400 S 1978", "Countach LP500 S 1982", "Diablo 1990", "Diablo 6.0 2000", "Diablo 6.0 SE 2001", "Diablo GT 1999", "Diablo SE 1993", "Diablo SV 1996", "Diablo VT 1993", "Diablo VT Roadster 1995", "Espada Serie I 1968", "Espada Serie II 1970", "Espada Serie III 1972", "Gallardo (1st gen) 2003", "Gallardo LP 550-2 Valentino Balboni 2009", "Gallardo LP 570-4 Edizione Tecnica 2012", "Gallardo LP550-2 (2nd gen) 2010", "Gallardo LP550-2 Spyder (2nd gen) 2012", "Gallardo LP560-4 (2nd gen) 2008", "Gallardo LP560-4 Spyder (2nd gen) 2009", "Gallardo LP570-4 Spyder Performante (2nd gen) 2010", "Gallardo LP570-4 Super Trofeo Stradale (2nd gen) 2011", "Gallardo LP570-4 Superleggera (2nd gen) 2012", "Gallardo Spyder (1st gen) 2006", "Gallardo Superleggera (1st gen) 2007", "Huracan Coupe 2014", "Huracan Performante 2018", "Huracan Performante Spyder 2018", "Huracan RWD 2015", "Huracan RWD Spyder 2018", "Huracan Spyder 2015", "Islero 1968", "Islero S 1969", "Jalpa 1981", "Jarama GT 1970", "Jarama GTS 1972", "LM002 1986", "Miura P 400 1966", "Miura Roadster 1968", "Miura S 1968", "Miura SV 1971", "Miura SV/J 1971", "Murcielago 2001", "Murcielago LP640 2006", "Murcielago LP640 Roadster 2007", "Murcielago LP650-4 Roadster 2009", "Murcielago LP670-4 SuperVeloce 2009", "Murcielago Roadster 2004", "Reventon 2007", "Sesto Elemento 2010", "Silhouette 1976", "Urraco P250 1973", "Urraco P300 1973", "Urus 2018", "Veneno 2013" };
            System.Object[] Lanciacars = { "037 Rally 1982", "2000 HF Coupe 1971", "Aprilia Sport Zagato 1938", "Aurelia 1956", "Beta Coupe 1982", "Beta HPE 1978", "Beta Montecarlo 1975", "D24 Pininfarina Spider Sport 1953", "Dedra 1996", "Delta 2012", "Delta HF 4WD 1986", "Delta HF Integrale 16v 1990", "Delta HF Integrale Evoluzione 1992", "Delta Integrale 16v 1989", "Delta Integrale 8v 1989", "Delta Integrale Evoluzione 1991", "Delta Integrale Evoluzione II 1993", "Delta S4 Rally 1985", "Delta S4 Stradale (SE038) 1985", "ECV 1986", "Flaminia Sport Zagato 1958", "Flavia 2000 Coupe 1969", "Fulvia Coupe 1965", "LC2 1984", "Montecarlo Turbo 1981", "New Stratos 2010", "Rally 037 Stradale 1982", "Stratos 1973", "Stratos HF Group 4 1974", "Stratos Zero 1970", "Thema 8.32 1986", "Y10 1985", "Ypsilon 2017" };
            System.Object[] LandRovercars = { "Defender 110 2016", "Defender 90 2006", "Defender Works V8 2018", "Discovery 2011", "Discovery 1 1989", "Discovery 2 1998", "Discovery 3 2004", "Discovery 5 2017", "Discovery Si4 2019", "Discovery Sport 2016", "Discovery Sport P250 AWD 2020", "Freelander 1997", "Freelander 2 TD4 2012", "Range Rover 4.4 V8 2002", "Range Rover 4.6 HSE 1994", "Range Rover 5.0 V8 2016", "Range Rover Evoque 2016", "Range Rover Evoque 2018", "Range Rover Evoque 2018", "Range Rover Evoque Autobiography Dynamic 2015", "Range Rover Mk 1 1970", "Range Rover P400e PHEV 2018", "Range Rover Sport 2005", "Range Rover Sport 2018", "Range Rover Sport SVR 2016", "Range Rover Sport SVR 2018", "Range Rover Velar 2018", "Range Rover Velar SVAutobiography Dynamic Edition 2019", "Series 1 1948" };
            System.Object[] Lotuscars = { "2-Eleven GT4 2009", "2-Eleven S'charged 2007", "340R 2000", "3-Eleven 430 2018", "Carlton 1991", "Eclat 1976", "Elan 1962", "Elan SE 1989", "Elise 1996", "Elise 1.6 2015", "Elise 111S 2002", "Elise Cup 250 2019", "Elise Sport 135 2003", "Elise Sprint 2017", "Elite 1957", "Esprit 1976", "Esprit S4 1993", "Esprit Sport 350 1999", "Esprit Turbo 1981", "Esprit V8 2002", "Essex Turbo Esprit 1980", "Europa 47 Twin Cam 1966", "Europa S 2006", "Europa SE 2008", "Europa Special 1973", "Evora 280 2009", "Evora 400 2015", "Evora GT430 2018", "Evora GT430 Sport 2017", "Evora GTE Road Car 2011", "Evora S 2010", "Evora Sport 410 2019", "Exige 265E 2007", "Exige Cup 260 2009", "Exige Cup 430 2019", "Exige S 2015", "Exige S1 2000", "Exige S2 2005", "Exige Scura 2009", "Group GT4 2011", "M100 Elan 1989", "Mk1 Cortina 1967", "Seven 1957" };
            System.Object[] Maseraticars = { "430 1987", "250F 1955", "3200 GT Assetto Corsa 1998", "3500 GT 1957", "5000 GT 1959", "A6 1500 1947", "A6G 2000 1950", "Birdcage 75th 2005", "Biturbo S 1983", "Bora 1971", "Coupe GranSport 2004", "Ghibli 2018", "Ghibli Cup 1992", "Ghibli Diesel 2018", "Ghibli S Q4 2016", "Ghibli SS 1969", "Ghibli SS Spyder 1969", "GranCabrio 2018", "GranCabrio MC 2016", "GranTurismo 2018", "GranTurismo MC Stradale 2016", "Indy 1969", "Karif 1988", "Khamsin 1974", "Kyalami 1978", "Levante Diesel 2018", "Levante S 2018", "MC12 Stradale 2004", "Merak SS 1976", "Mexico 1966", "Mistral 1963", "Quattroporte 1974", "Quattroporte 1994", "Quattroporte 2017", "Quattroporte Diesel 2018", "Quattroporte GTS 2016", "Quattroporte Sport GT S 2009", "Racing 1991", "Royale 1986", "Sebring 1962", "Shamal 1990", "Spyder 1991", "Spyder GranSport 2005", "Tipo 61 Birdcage 1959" };
            System.Object[] Mazdacars = { "2 2018", "3 2018", "6 2016", "6 MPS 2005", "787b 1990", "Autozam AZ-1 1992", "BBR MX-5 GT270 2013", "BT-50 2018", "Carol 1962", "Cosmo 1967", "Cosmo 1975", "Cosmo 1981", "Cosmo 1990", "CX-3 2018", "CX-5 2018", "CX-9 2018", "Eunos Roadster RS-Limited 1994", "Furai 2007", "Jota MX-5 GT 2013", "MX-5 1989", "MX-5 1998", "MX-5 2005", "MX-5 2018", "MX-5 BBR Turbo 1990", "MX-5 RF 2018", "RX-3 1971", "RX-7 1978", "RX-7 1985", "RX-7 1992", "RX-7 Convertible 1988", "RX-7 Spirit R 2002", "RX-7 Turbo 1983", "RX-7 Turbo 1985", "RX-7 Type RS 1998", "RX-7 Type RZ 2000", "RX-8 2002", "RX-8 PZ 2006", "RX-8 Spirit R 2012" };
            System.Object[] McLarencars = { "12C 2011", "12C GT3 2012", "570S Coupe 2015", "570S Spider 2017", "600LT Coupe 2018", "600LT Spider 2019", "650S 2014", "650S GT3 2016", "675LT 2015", "720S 2018", "720S GT3 2019", "720S Spider 2018", "F1 1994", "F1 GT 1997", "F1 GTR Short Tail 1995", "F1 LM 1995", "GT 2019", "Mercedes-Benz SLR McLaren 2003", "Mercedes-Benz SLR McLaren 722 2006", "Mercedes-Benz SLR McLaren Roadster 2007", "P1 2014", "P1 GTR 2015", "Senna 2019" };
            System.Object[] MercedesBenzcars = { "600 1964", "190 E 2.0 1985", "190 E 2.3-16 1984", "190 E Evo II 1990", "280 GE 1990", "300 SL 1963", "57S Maybach 2012", "62 Landaulet Maybach 2010", "A 160 1997", "A 180d 2012", "A 200 2012", "A 200 CDI 2004", "AMG A 45 2016", "AMG C 43 1999", "AMG C 55 2007", "AMG C 63 2012", "AMG C 63 2015", "AMG CLK 63 Black Series 2007", "AMG CLK DTM 2007", "AMG E 55 2003", "AMG E 63 2011", "AMG E 63 S 2015", "AMG G 55 2006", "AMG G 63 2015", "AMG G 63 6x6 2013", "AMG GLE 63 S 2015", "AMG GT 2016", "AMG GT S 2016", "AMG ML 63 2012", "AMG S 55 2003", "AMG S 63 2011", "AMG S 65 2006", "AMG S 65 Coupe 2016", "AMG SL 73 1999", "AMG SLC 43 2016", "AMG SLK 32 2004", "AMG SLK Black Series 2007", "AMG SLS 2010", "AMG SLS Black Series 2013", "AMG SLS Electric 2013", "AMG SLS GT 2012", "AMG SLS GT3 2016", "AMG SLS Roadster 2012", "C 200 K 2002", "C 250d 2015", "C 350 4MATIC 2009", "C 350e 2015", "CLA 250 4MATIC 2015", "CLK 230 K 1999", "CLS 400 2015", "E 220 2015", "E 320 1994", "E 320 CDI 2005", "E 430 1999", "E 500 1994", "G 500 2012", "GL 350 2015", "GLA 220d 2015", "GLC 250d 2015", "S 280 1995", "S 350 4MATIC 2007", "S 400h L 2016", "SL 500 2016", "SLK 200 2016", "V 250d 2015" };
            System.Object[] MGcars = { "Maestro Turbo 1983", "Metro 6R4 1984", "Metro Turbo 1982", "MGB 1962", "MGB GT V8 1973", "MGC GT 1967", "Midget 1961", "Montego Turbo 1985" };
            System.Object[] Minicars = { "Cooper 2016", "Cooper Convertible 2016", "Cooper S 1971", "Cooper S 2016", "Cooper S Works GP 2006", "Cooper SD 2011", "JCW ALL4 Countryman 2016", "JCW Convertible 2016", "JCW Coupe 2016", "John Cooper Works 2016", "One 2016" };
            System.Object[] Mitsubishicars = { "ASX 2010", "ASX 2015", "Colt 2004", "Colt 2009", "Colt CZC 2006", "Colt Ralliart Version-R 2009", "Grandis 2006", "i 2007", "L200 2016", "Lancer Evo I 1992", "Lancer Evo IV 1996", "Lancer Evo IX MR FQ-360 2007", "Lancer Evo VI T.M. Edition 2000", "Lancer Evo VIII 260 2004", "Lancer Evo VIII FQ-400 2004", "Lancer Evo VIII MR FQ-340 2005", "Lancer Evo X FQ-300 SST 2007", "Lancer Evo X FQ-360 2009", "Lancer GS4 2007", "Lancer Sportback 2008", "Mirage 2013", "Montero Black Edition 2011", "Montero SG4 2011", "Outlander 2012", "Outlander PHEV 2016" };
            System.Object[] Nissancars = { "200SX 1993", "350Z 2002", "350Z Roadster 2005", "370Z 2011", "Almera 1998", "Almera GTI 1997", "Cube 1998", "Cube 2010", "Datsun 240Z 1969", "Datsun 240Z Rally Car 1969", "Figaro 1991", "GT-R 2014", "GT-R Nismo 2016", "Juke 2013", "Juke Nismo 2016", "Juke-R 2011", "Leaf 2016", "Micra 1991", "Micra 2004", "Micra 2011", "Micra 2016", "Murano 2002", "Murano 2008", "Murano CrossCabriolet 2008", "Murano GT-C 2006", "Navara 2016", "Note 2006", "Note 2013", "NP300 Navara 2017", "Pathfinder 1985", "Pathfinder 2006", "Pathfinder 2010", "Pathfinder 2016", "Patrol 1986", "Patrol 1987", "Patrol 1997", "Patrol 2000", "Patrol (type 60) 1959", "Patrol Nismo 2016", "Pixo 2009", "Primera 1999", "Primera 2004", "Primera eGT 1990", "Pulsar 1978", "Pulsar 1982", "Pulsar 1986", "Pulsar 1995", "Pulsar 2015", "Qashqai 2008", "Qashqai 2016", "R390 GT1 Road Car 1998", "S-Cargo 1989", "Silvia 1965", "Silvia 1975", "Silvia 240RS 1983", "Skyline GT-R (R32) 1989", "Skyline GT-R (R33) 1997", "Skyline GT-R (R34) 1999", "Skyline Hardtop 2000 GT-R (C10) 1971", "Terrano II 2002", "X-Trail 2001", "X-Trail 2010", "X-Trail 2016" };
            System.Object[] Paganicars = { "Huayra 2016", "Huayra BC 2016", "Huayra Roadster 2017", "Zonda 760RS 2012", "Zonda C12 1999", "Zonda Cinque Roadster 2009", "Zonda F 2005", "Zonda R 2007", "Zonda Revolucion 2013", "Zonda S 2000", "Zonda S 7.3 2002" };
            System.Object[] Peugeotcars = { "108 2018", "203 1948", "208 2018", "301 2018", "305 1977", "307 2003", "308 2018", "404 1962", "405 1987", "508 2018", "605 1989", "607 1999", "907 2004", "1007 2005", "2008 2018", "3008 2018", "5008 2018", "106 Rallye (S1) 1993", "106 Rallye (S2) 1997", "204 Coupe 1965", "205 GTi 1.6 1984", "205 GTi 1.9 1986", "205 Rallye 1988", "205 T16 1984", "205 T16 Evo 2 1985", "205 T16 Pikes Peak 1987", "206 CC 2000", "206 GTi 1999", "206 RC 2003", "206 WRC 2000", "207 RC 2007", "207 S2000 2007", "208 GTi 2018", "208 R2 2012", "208 T16 Pikes Peak 2013", "208 T16 R5 2014", "208 WRX 2018", "3008 DKR 2017", "306 GTi-6 1996", "306 Maxi 1999", "306 Rallye 1998", "308 GTi 2018", "308 R HYbrid 2016", "309 GTi 1986", "402 Darl'mat 1937", "404 Coupe 1963", "405 Mi16 1987", "405 T16 1993", "405 T16 Pikes Peak 1988", "406 Coupe 1997", "407 Coupe 2006", "407 Silhouette 2004", "504 Coupe 1968", "505 Break 1982", "607 Pescarolo 2002", "905B 1992", "908 HDi FAP 2007", "908 RC 2006", "e-208 2019", "e-Legend 2018", "EX1 2010", "Hoggar 2010", "iOn 2018", "Onyx 2012", "Oxia 1988", "Quasar 1984", "Rally 504 1971", "RC Diamonds 2002", "RC Spades 2002", "RCZ R 2013", "SR1 2010" };
            System.Object[] Plymouthcars = { "Barracuda Fastback 1968", "Duster 340 1972", "Fury 1958", "GTX 1968", "HEMI 'Cuda 1970", "Reliant 1981", "Roadrunner 383 1968", "Scamp 1982", "Superbird 1970" };
            System.Object[] Pontiaccars = { "6000 STE AWD 1988", "Aztek 2001", "Bonneville Special 1954", "Bonneville SSEi 2000", "Fiero 1984", "Fiero GT 1988", "Firebird Trans Am 1970", "Firebird Trans Am 1985", "G6 2005", "G8 GXP 2010", "Grand Am 1986", "Grand Am GT 1992", "Grand Prix 2+2 1986", "Grand Prix GTP 1997", "Grand Prix GXP 2006", "GTO 2006", "GTO Judge Ram Air IV 1970", "Montana 2005", "Solstice GXP Coupe 2009", "Sunbird GT 1986", "Sunfire 1995", "Tempest Le Mans GTO 1966", "Torrent GXP 2008", "Trans Am 1978", "Trans Am 20th Anniversary 1989", "Trans Am 30th Anniversary 1999", "Trans Am 35th Anniversary 2002", "Vibe GT 2003" };
            System.Object[] Porschecars = { "356 1948", "356 1955", "911 1965", "914 1969", "917 1970", "924 1976", "928 1977", "944 1982", "959 1986", "968 1992", "356 B Convertible 1600 1965", "356 Speedster 1955", "550 Spyder 1955", "718 Boxster 2017", "718 Boxster S 2017", "718 Cayman 2016", "911 Carrera 1994", "911 Carrera 2004", "911 Carrera 2016", "911 Carrera 2 Targa 1989", "911 Carrera 2.7 RS 1973", "911 Carrera 4 1989", "911 Carrera 4 2000", "911 Carrera Cabriolet 2000", "911 Carrera GTS 2015", "911 Carrera RSR 3.0 1973", "911 Carrera S 2004", "911 Carrera S 2015", "911 Carrera S Cabriolet 2016", "911 GT1 race car 1997", "911 GT1 road car 1997", "911 GT2 2001", "911 GT2 2007", "911 GT2 RS 2011", "911 GT2 RS 2018", "911 GT3 1999", "911 GT3 2006", "911 GT3 2013", "911 GT3 RS 2004", "911 GT3 RS 2006", "911 GT3 RS 2015", "911 GT3 RS 2018", "911 GT3 RS 4.0 2011", "911 R 2016", "911 RS 1992", "911 Targa 4S 2004", "911 Targa 4S 2015", "911 Targa 4S 2016", "911 Turbo 1975", "911 Turbo 1990", "911 Turbo 1995", "911 Turbo 2001", "911 Turbo 2006", "911 Turbo 2013", "911 Turbo Martini 1978", "911 Turbo S 2013", "911S 2.4 Targa 1972", "911S 2.7 1974", "918 Spyder 2013", "924 Carrera GTS 1981", "924 Carrera GTS Rallye 1981", "924 Turbo 1979", "928 S 1980", "935 'Moby Dick' 1978", "959 Dakar 1986", "962 C 1985", "968 Clubsport 1993", "968 Turbo S 1993", "Boxster 1996", "Boxster 2005", "Boxster 2015", "Boxster GTS 2015", "Boxster S 2015", "Boxster Spyder 2009", "Boxster Spyder 2016", "Carrera GT 2003", "Cayenne GTS 2016", "Cayenne Turbo 2002", "Cayenne Turbo 2017", "Cayman 2005", "Cayman 2009", "Cayman 2012", "Cayman GT4 2015", "Cayman GTS 2014", "Macan GTS 2015", "Macan Turbo 2016", "Macan Turbo Performance Pack 2017", "Panamera Turbo 2010", "Panamera Turbo 2017" };
            System.Object[] Ramcars = { "1500 Rebel 2019", "Dodge 1st Gen 1981", "Dodge Li'l Red Express Truck 1978", "Dodge Ramcharger 1974", "Dodge Ramcharger 1981" };
            System.Object[] Renaultcars = { "4 1961", "5 1972", "5 1984", "6 1968", "12 1969", "14 1976", "16 1965", "18 1978", "30 1975", "17 Coupe 1976", "19 16S 1988", "21 2.0l Turbo Quadra 1986", "21 Savanna 1986", "25 V6 Turbo 1983", "3.5l V6 Espace MK4 2002", "5 GT Turbo 1985", "5 Turbo 1980", "9 Turbo 1981", "Alaskan 2015", "Alpine A110 1971", "Alpine A310 V6 Group 4/B 1983", "Alpine GTA V6 Turbo Le Mans 1990", "Avantime 3.0 V6 2002", "Captur 2016", "Clio 1990", "Clio 1998", "Clio 2005", "Clio 2016", "DeZir 2010", "Espace 1984", "Espace 1991", "Espace 1997", "Espace 2002", "Espace 2016", "Fluence 2013", "Fuego Turbo 1984", "Kadjar 2016", "Koleos 2008", "Koleos 2018", "Laguna 1994", "Laguna 2001", "Laguna 2007", "Laguna Coupe 2010", "Megane 1995", "Megane 2002", "Megane 2008", "R12 Gordini 1973", "R17 Gordini 1979", "R20 Turbo 4x4 1979", "R21 Turbo Europa Cup 1988", "R5 MAXI TURBO 1987", "R8 Gordini 1964", "Safrane Biturbo 1992", "Scenic 1996", "Scenic 2003", "Scenic 2016", "Sport Clio 172 Cup 1999", "Sport Clio 182 Trophy 2005", "Sport Clio 200 2009", "Sport Clio 220 Trophy 2016", "Sport Clio Cup Car 2014", "Sport Clio R.S.16 2016", "Sport Clio V6 2001", "Sport Clio V6 2003", "Sport Laguna BTCC 1999", "Sport Megane 2002", "Sport Megane 2.0 dCi 175 2008", "Sport Megane 275 Trophy-R 2016", "Sport Megane IV R.S. 2018", "Sport Megane R26.R 2008", "Sport Megane Trophy 2009", "Sport R.S. 01 2015", "Sport Spider 1996", "Sport Twingo 133 Cup 2012", "Sport Twingo GT 2016", "Talisman 2015", "Trezor 2016", "Twingo 1993", "Twingo 2007", "Twingo 2007", "Twizy 2016", "Twizy F1 2013", "Vel Satis 2002", "Wind 2010", "Zoe 2016" };
            System.Object[] Rimaccars = { "C_Two 2019", "Concept_One 2016" };
            System.Object[] Rovercars = { "200 1995", "216 1984", "400 1995", "623 1993", "800 1986", "220 Coupe Turbo 1992", "220 GSi 1989", "P6 1963", "SD1 1976" };
            System.Object[] RUFcars = { "3400S 1999", "3800S 2013", "BTR 1983", "BTR2 1993", "CTR \"Yellowbird\" 1987", "CTR2 1995", "CTR3 2007", "CTR3 Clubsport 2012", "Dakara 2009", "R Kompressor 2006", "R Turbo 2001", "R56.11 2011", "RCT 1991", "RGT 2000", "RK Coupe 2006", "Rt 12 S 2009", "Rt 35 2012", "RTR 2016", "SCR 1978", "SCR 4.2 2016", "Turbo 3.3 1977", "Turbo Florio 2015", "Turbo R Limited 2016" };
            System.Object[] ScuderiaCameronGlickenhauscars = { "SCG003S 2018" };
            System.Object[] Smartcars = { "Brabus Roadster 2005", "Crossblade 2002", "Forfour 2016", "Fortwo 2004", "Fortwo Cabrio 2016", "Fortwo Coupe T 2016", "Fortwo EV 2008" };
            System.Object[] Spykercars = { "C12 La Turbie 2006", "C12 Zagato 2007", "C8 Aileron 2009", "C8 Aileron Spyder 2010", "C8 Double 12 S (Stage V) 2002", "C8 Laviolette 2001", "C8 Laviolette LM85 2008", "C8 Preliator 2016", "C8 Preliator Spyder 2017", "C8 Spyder SWB 2000", "C8 Spyder T 2003", "D12 Peking-to-Paris 2006" };
            System.Object[] Subarucars = { "Alcyone SVX 1991", "Baja Turbo 2003", "Brat 1978", "BRZ 2016", "Forester 1997", "Forester 2002", "Forester 2008", "Forester 2016", "Impreza 22B 1998", "Impreza WRX 1993", "Impreza WRX STI 2005", "Impreza WRX STI 2010", "Justy 1984", "Legacy 1989", "Legacy 1993", "Legacy 1998", "Legacy 2003", "Legacy 2009", "Legacy 2016", "Leone 1971", "Leone 1979", "Leone 1984", "Levorg 2016", "Outback 2008", "Rex 1972", "Rex 1981", "Rex 1986", "Tribeca 2006", "WRX STI 2015", "XT 1985", "XV 2016" };
            System.Object[] Suzukicars = { "Alto 2004", "Baleno 2016", "Celerio 2016", "Ertiga 2016", "Ignis 2016", "Ignis Sport 2004", "Jimny 2007", "Kizashi 4x4 2010", "Liana 2001", "Pikes Peak XL7 2007", "SC100 1977", "Splash 2008", "Splash 2012", "Swift 2016", "Swift Rally Spec 2008", "Swift Sport 2006", "SX4 2006", "SX4 S-Cross 2016", "Vitara 2005", "Vitara S 2016", "Wagon R 1993", "X-90 1995", "XL-7 1998" };
            System.Object[] TVRcars = { "1600M 1972", "280i 1984", "3000S 1973", "400SE 1988", "450 SEAC 1988", "450SE 1989", "Cerbera Speed 12 2000", "Cerbera Speed Six 1998", "Chimaera 5.0 1993", "Grantura 1958", "Griffith 2020", "Griffith 200 1965", "Griffith 4.3 1992", "Griffith 400 1964", "Griffith 500 1993", "Sagaris 2005", "S-Series V8S 1986", "T350 2002", "Taimar 1976", "Taimar Turbo 1977", "Tamora 2001", "Tasmin 350i Convertible 1984", "Tuscan Convertible 2005", "Tuscan race car 1989", "Tuscan S 2005", "Tuscan V8 1967", "Typhon 2000", "Vixen S2 1970" };
            System.Object[] Vauxhallcars = { "Adam 1.2 2016", "Adam Rocks S 2015", "Antara 2.2CDTi 2016", "Astra 2016", "Astra 1.2 1984", "Astra 1.4i 1991", "Astra 1.4i 1998", "Astra 1.6 1979", "Astra 1.6 CDTi 2009", "Astra 1.6i 2004", "Astra GTE 1988", "Astra VXR 2010", "Calibra Turbo 1992", "Carlton GSi3000 24v 1989", "Cascada 2016", "Cavalier 1.6 1988", "Cavalier 1600L 1975", "Cavalier SRi 1981", "Chevette HSR 1980", "Corsa 1.4 2016", "Corsa 1.4i 1993", "Corsa VXR 2016", "Firenza 2000 SL Coupe 1971", "Firenza Baby Bertha 1974", "Firenza Old Nail 1971", "Frontera 1989", "GTC VXR 2016", "HP Firenza 1973", "Insignia 2.0 CDTi 2016", "Insignia Grand Sport 2018", "Insignia VXR S'sport 2016", "Insignia VXR Unlimited 2011", "Maloo R8 LSA 2016", "Mokka 4x4 2016", "Nova GTE 1987", "Opel Adam R2 2016", "Opel Admiral V8 1965", "Opel Ascona 400 1979", "Opel Corsa Super 1600 2001", "Opel Diplomat A V8 Coupe 1965", "Opel GT 1968", "Opel GT 2007", "Opel GT Concept 2016", "Opel GTC Concept 2007", "Opel Insignia Country Tourer 2013", "Opel Kadett GT/E 1975", "Opel Kadett Rallye E 4S 1985", "Opel Manta 400 1979", "Opel Manta 400 Rally 1982", "Opel Manta GTE 1988", "Opel Monza GSE 1983", "Opel OPC Extreme 2014", "Opel Vectra GSi 1988", "PA Velox 1959", "Senator 1987", "Signum 2003", "Tigra 1994", "Tigra TwinTop 2004", "Vectra 2.5 V6 1995", "Vectra VXR 2006", "VX220 2000", "VX220 Turbo 2003", "VXR8 GTS 2016" };
            System.Object[] Volkswagencars = { "Arteon 2017", "Atlas 2018", "Beetle 1970", "Beetle 2011", "Beetle Cabriolet 1970", "Beetle Cabriolet 2012", "CC 2008", "Corrado 1988", "Corrado 16v G60 1988", "Corrado VR6 1992", "Country Buggy 1968", "Fox 2005", "Golf 1974", "Golf 1983", "Golf 1991", "Golf 1997", "Golf 2003", "Golf 2017", "Golf G60 Rallye 1988", "Golf GTD 2009", "Golf GTI 1982", "Golf GTI 1985", "Golf GTI 1991", "Golf GTI 1997", "Golf GTI 2004", "Golf GTI 2009", "Golf GTI 2013", "Golf GTI G60 1990", "Golf GTI TCR 2018", "Golf GTI W12 2007", "Golf R 2012", "Golf R 2015", "Golf R32 2005", "Golf R400 2015", "Golf VR6 1991", "I.D. R Pikes Peak 2018", "Jetta 1980", "Jetta 2004", "Jetta 2008", "Jetta 2011", "Jetta 2019", "Jetta GTI 1988", "Jetta VR6 1992", "Karmann Ghia 1974", "Lupo GTI 2001", "New Beetle 1999", "New Beetle Cabriolet 2003", "New Beetle RSi 2000", "Passat 1975", "Passat 1983", "Passat 1988", "Passat 1993", "Passat 2006", "Passat 2018", "Phaeton 2002", "Phaeton 2014", "Polo 1976", "Polo 1984", "Polo 1994", "Polo 2003", "Polo 2009", "Polo 2018", "Polo GT G40 1987", "Polo GTI 1999", "Polo GTI 2006", "Polo GTI 2010", "Polo GTI 2018", "Scirocco 1982", "Scirocco 2008", "Scirocco GTI 1986", "Scirocco R 2009", "Sharan 2008", "Sharan 2015", "Tiguan 2011", "Tiguan 2017", "Touareg 2008", "Touareg 2010", "Touareg 2018", "Touran 2003", "Touran 2015", "Transporter 1996", "Transporter 2004", "Transporter 2016", "T-Roc 2017", "Type 2 1966", "Type 2 1970", "Type 2 1979", "up! 2013", "up! GTI 2018", "W12 Nardo 2001", "W12 Roadster 1997", "W12 Syncro 1997" };
            System.Object[] Volvocars = { "145 1971", "1800ES 1972", "240 GLT 1988", "360 GLT 1983", "440 GLT 1992", "480 Turbo 1988", "740 Turbo 1990", "850 AWD 1997", "850 BTCC 1994", "850 R 1997", "850 T-5R 1995", "960 3.0 1991", "Amazon 1958", "C30 Polestar Performance 2010", "C30 T5 R-Design 2008", "C303 Paris Dakar 1983", "C70 T5 2013", "C70 T5 2.3 2003", "P1800 1961", "Polestar 1 2020", "S60 R AWD 2004", "S60 T6 2013", "S60 T8 AWD 2020", "S80 V8 2006", "S90 T5 2016", "S90 T8 2018", "V40 T5 2018", "V60 Polestar 2015", "V60 T8 Polestar 2020", "V70 R 2000", "V90 T8 AWD 2018", "XC40 T5 2019", "XC60 T8 2018", "XC90 T5 2018", "XC90 T8 Twin Engine 2016", "XC90 V8 2010" };

            comboBox6.Items.Clear();
            comboBox6.Text = null;

            switch (comboBox5.Text)
            {
                case "Acura":
                    comboBox6.Items.AddRange(Acuracars);
                    break;
                case "Alfa Romeo":
                    comboBox6.Items.AddRange(AlfaRomeocars);
                    break;
                case "Ariel":
                    comboBox6.Items.AddRange(Arielcars);
                    break;
                case "Aston Martin":
                    comboBox6.Items.AddRange(AstonMartincars);
                    break;
                case "Audi":
                    comboBox6.Items.AddRange(Audicars);
                    break;
                case "Austin":
                    comboBox6.Items.AddRange(Austincars);
                    break;
                case "Bentley":
                    comboBox6.Items.AddRange(Bentleycars);
                    break;
                case "BMW":
                    comboBox6.Items.AddRange(BMWcars);
                    break;
                case "Bugatti":
                    comboBox6.Items.AddRange(Bugatticars);
                    break;
                case "Buick":
                    comboBox6.Items.AddRange(Buickcars);
                    break;
                case "Cadillac":
                    comboBox6.Items.AddRange(Cadillaccars);
                    break;
                case "Caterham":
                    comboBox6.Items.AddRange(Caterhamcars);
                    break;
                case "Chevrolet":
                    comboBox6.Items.AddRange(Chevroletcars);
                    break;
                case "Chrysler":
                    comboBox6.Items.AddRange(Chryslercars);
                    break;
                case "Citroen":
                    comboBox6.Items.AddRange(Citroencars);
                    break;
                case "De Tomaso":
                    comboBox6.Items.AddRange(DeTomasocars);
                    break;
                case "Dodge":
                    comboBox6.Items.AddRange(Dodgecars);
                    break;
                case "Donkervoort":
                    comboBox6.Items.AddRange(Donkervoortcars);
                    break;
                case "DS":
                    comboBox6.Items.AddRange(DScars);
                    break;
                case "Fiat":
                    comboBox6.Items.AddRange(Fiatcars);
                    break;
                case "Ford":
                    comboBox6.Items.AddRange(Fordcars);
                    break;
                case "GMC":
                    comboBox6.Items.AddRange(GMCcars);
                    break;
                case "Gumpert":
                    comboBox6.Items.AddRange(Gumpertcars);
                    break;
                case "Honda":
                    comboBox6.Items.AddRange(Hondacars);
                    break;
                case "Hummer":
                    comboBox6.Items.AddRange(Hummercars);
                    break;
                case "Infiniti":
                    comboBox6.Items.AddRange(Infiniticars);
                    break;
                case "Jaguar":
                    comboBox6.Items.AddRange(Jaguarcars);
                    break;
                case "Koenigsegg":
                    comboBox6.Items.AddRange(Koenigseggcars);
                    break;
                case "KTM":
                    comboBox6.Items.AddRange(KTMcars);
                    break;
                case "Lamborghini":
                    comboBox6.Items.AddRange(Lamborghinicars);
                    break;
                case "Lancia":
                    comboBox6.Items.AddRange(Lanciacars);
                    break;
                case "Land Rover":
                    comboBox6.Items.AddRange(LandRovercars);
                    break;
                case "Lotus":
                    comboBox6.Items.AddRange(Lotuscars);
                    break;
                case "Maserati":
                    comboBox6.Items.AddRange(Maseraticars);
                    break;
                case "Mazda":
                    comboBox6.Items.AddRange(Mazdacars);
                    break;
                case "McLaren":
                    comboBox6.Items.AddRange(McLarencars);
                    break;
                case "Mercedes-Benz":
                    comboBox6.Items.AddRange(MercedesBenzcars);
                    break;
                case "MG":
                    comboBox6.Items.AddRange(MGcars);
                    break;
                case "Mini":
                    comboBox6.Items.AddRange(Minicars);
                    break;
                case "Mitsubishi":
                    comboBox6.Items.AddRange(Mitsubishicars);
                    break;
                case "Nissan":
                    comboBox6.Items.AddRange(Nissancars);
                    break;
                case "Pagani":
                    comboBox6.Items.AddRange(Paganicars);
                    break;
                case "Peugeot":
                    comboBox6.Items.AddRange(Peugeotcars);
                    break;
                case "Plymouth":
                    comboBox6.Items.AddRange(Plymouthcars);
                    break;
                case "Pontiac":
                    comboBox6.Items.AddRange(Pontiaccars);
                    break;
                case "Porsche":
                    comboBox6.Items.AddRange(Porschecars);
                    break;
                case "Ram":
                    comboBox6.Items.AddRange(Ramcars);
                    break;
                case "Renault":
                    comboBox6.Items.AddRange(Renaultcars);
                    break;
                case "Rimac":
                    comboBox6.Items.AddRange(Rimaccars);
                    break;
                case "Rover":
                    comboBox6.Items.AddRange(Rovercars);
                    break;
                case "RUF":
                    comboBox6.Items.AddRange(RUFcars);
                    break;
                case "Scuderia Cameron Glickenhaus":
                    comboBox6.Items.AddRange(ScuderiaCameronGlickenhauscars);
                    break;
                case "Smart":
                    comboBox6.Items.AddRange(Smartcars);
                    break;
                case "Spyker":
                    comboBox6.Items.AddRange(Spykercars);
                    break;
                case "Subaru":
                    comboBox6.Items.AddRange(Subarucars);
                    break;
                case "Suzuki":
                    comboBox6.Items.AddRange(Suzukicars);
                    break;
                case "TVR":
                    comboBox6.Items.AddRange(TVRcars);
                    break;
                case "Vauxhall":
                    comboBox6.Items.AddRange(Vauxhallcars);
                    break;
                case "Volkswagen":
                    comboBox6.Items.AddRange(Volkswagencars);
                    break;
                case "Volvo":
                    comboBox6.Items.AddRange(Volvocars);
                    break;
                default:
                    break;
            }
        } //копия комбобокса2, PL12

        private void button2_Click(object sender, EventArgs e)
        {            
            PictureToNameTableAdd();
        }

        //From bot.v.0.07 ====================================================

        private void button7_Click(object sender, EventArgs e)
        {
            DevKit dk = new DevKit();
            dk.SortCarDB();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DevKit dk = new DevKit();
            string text1 = textBox2.Text;
            string text2 = textBox3.Text;
            label6.Text = dk.CalculateDifShades(text1, text2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int x0 = Convert.ToInt32(textBox4.Text);
            int y0 = Convert.ToInt32(textBox5.Text);
            int x1 = Convert.ToInt32(textBox6.Text);
            int y1 = Convert.ToInt32(textBox7.Text);
            int rectwidth = x1 - x0;
            int rectheight = y1 - y0;
            string commonpath = @"C:\Bot\";
            string path = "test.jpg";
            this.WindowState = FormWindowState.Minimized;
            Thread.Sleep(2000);
            Rectangle rect = new Rectangle(x0, y0, rectwidth, rectheight);
            MasterOfPictures.MakePicture(rect, commonpath + path);
            this.WindowState = FormWindowState.Normal;
        }
        
        public class NotePad
        {
            public static void DoErrorLog(string text)
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Bot\Errors.txt", true, System.Text.Encoding.Default))//true для дописывания 
                {
                    sw.WriteLine(text);
                    sw.Close();
                }
            }

            public static void DoLog(string text)
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", true, System.Text.Encoding.Default))//true для дописывания 
                {
                    sw.WriteLine(text + "  " + DateTime.Now.ToLongTimeString());
                    sw.Close();
                }
            }

            public static void ClearLog()
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", false, System.Text.Encoding.Default))//true для дописывания 
                {
                    sw.WriteLine("Начинаю новую сессию");
                    sw.Close();
                }
            }
        }

        public class MasterOfPictures
        {
            private static Bitmap captured; //создаем объект Bitmap (растровое изображение), будет нужен как при самом получении изображения, так и при сохранении изображения

            public static void MakePicture(Rectangle bounds, string PATH)
            {
                PixelFormat format = PixelFormat.Format24bppRgb;
                captured = new Bitmap(bounds.Width, bounds.Height, format);
                Graphics gdi = Graphics.FromImage(captured);
                gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
                if (captured != null)
                {
                    captured.Save(PATH, ImageFormat.Jpeg);
                }
                gdi.Dispose();
                captured.Dispose();
            }

            public static bool Verify(string PATH, string ORIGINALPATH)
            {
                Bitmap picturetest = new Bitmap("C:\\Bot\\" + PATH + ".jpg");
                Bitmap picture = new Bitmap("C:\\Bot\\" + ORIGINALPATH + ".jpg");
                bool flag1 = true;
                for (int x = 0; x < picturetest.Width; x++)
                {
                    if (flag1 == true)
                    {
                        for (int y = 0; y < picturetest.Height; y++)
                        {
                            if (picturetest.GetPixel(x, y) != picture.GetPixel(x, y))
                            {
                                Console.WriteLine("разные");
                                flag1 = false;
                                break;
                            }
                        }
                    }
                }
                picturetest.Dispose();
                picture.Dispose();
                return flag1;
            }

            public static void TrackCapture(Rectangle bounds, string PATH)
            {
                PixelFormat format = PixelFormat.Format24bppRgb;
                captured = new Bitmap(bounds.Width, bounds.Height, format);
                Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
                Graphics gdi = Graphics.FromImage(captured);
                gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
                for (int row = 0; row < captured.Width; row++) // Indicates row number
                {
                    for (int column = 0; column < captured.Height; column++) // Indicate column number
                    {
                        var colorValue = captured.GetPixel(row, column); // Get the color pixel                    
                        var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white
                        if (averageValue > 220) averageValue = 255;
                        else averageValue = 0;
                        BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                    }
                }

                BW.Save("C:\\Bot\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black and white image         

                gdi.Dispose();
                captured.Dispose();
                BW.Dispose();
            }

            public static void BW2Capture(Rectangle bounds, string PATH)
            {
                PixelFormat format = PixelFormat.Format24bppRgb;
                captured = new Bitmap(bounds.Width, bounds.Height, format);
                Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
                Graphics gdi = Graphics.FromImage(captured);
                gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
                for (int row = 0; row < captured.Width; row++) // Indicates row number
                {
                    for (int column = 0; column < captured.Height; column++) // Indicate column number
                    {
                        var colorValue = captured.GetPixel(row, column); // Get the color pixel
                        var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white
                        if (averageValue > 200) averageValue = 255;
                        else averageValue = 0;
                        BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                    }
                }

                BW.Save("C:\\Bot\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black ad white image            

                gdi.Dispose();
                captured.Dispose();
                BW.Dispose();
            }

            public static bool VerifyBW(string PATH, string ORIGINALPATH, int maxdiffernces)
            {
                Bitmap picturetest = new Bitmap("C:\\Bot\\" + PATH + ".jpg");
                Bitmap picture = new Bitmap("C:\\Bot\\" + ORIGINALPATH + ".jpg");
                bool flag1 = true;
                int differences = 0;
                for (int x = 0; x < picturetest.Width; x++)
                {
                    if (flag1 == true)
                    {
                        for (int y = 0; y < picturetest.Height; y++)
                        {
                            //Console.Write("сравниваю пиксель " + x + " " + y + " " + DateTime.Now.ToLongTimeString() + " ");
                            //Console.Write(picturetest.GetPixel(x, y) + " ");
                            //Console.Write(picture.GetPixel(x, y) + " ");
                            if (Math.Abs((int)picturetest.GetPixel(x, y).R - (int)picture.GetPixel(x, y).R) < 200)
                            {
                                //Console.WriteLine("совпали");
                            }
                            else
                            {
                                //Console.WriteLine("разные");
                                differences++;

                                if (differences == maxdiffernces)
                                {
                                    flag1 = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("различие в " + differences + " пикселей");
                picturetest.Dispose();
                picture.Dispose();
                return flag1;
            }
        }

        public class DevKit
        { 
            public void BestPiece()
            {
                Bitmap picture = new Bitmap("C:\\Bot\\testcars1\\test1.jpg");
                Bitmap picturetest = new Bitmap("C:\\Bot\\testcars3\\test1.jpg");

                int x0 = 32;
                int y0 = 7;
                int bestposx = 0;
                int bestposy = 0;
                int minshadesdifs = -1;
                for (int zeroposx = 0; zeroposx < 114 - 50; zeroposx++)
                {
                    for (int zeroposy = 0; zeroposy < 64 - 50; zeroposy++)
                    {
                        int shadesdifs0 = 0;
                        for (int x1 = 0; x1 < 50; x1++)
                        {
                            for (int y1 = 0; y1 < 50; y1++)
                            {
                                var colorValue0 = picture.GetPixel(x0 + x1, y0 + y1);
                                var colorValue1 = picturetest.GetPixel(zeroposx + x1, zeroposy + y1);
                                int shadesdifs1 = (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                    Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                    Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                                shadesdifs0 += shadesdifs1;
                            }
                        }
                        NotePad.DoErrorLog("стартовая позиция второй картинки " + zeroposx + " " + zeroposy + ", отличие " + shadesdifs0 + " оттенков");
                        if (minshadesdifs == -1 || minshadesdifs > shadesdifs0)
                        {
                            minshadesdifs = shadesdifs0;
                            bestposx = zeroposx;
                            bestposy = zeroposy;
                        }
                    }
                }

                NotePad.DoErrorLog("наиболее подходящий кусок " + bestposx + " " + bestposy + " с отличием в " + minshadesdifs + " оттенков");

                picture.Dispose();
                picturetest.Dispose();
            } //pay attention

            public void MapsofDifs()
            {
                Bitmap picture = new Bitmap("C:\\Bot\\testcars1\\test.jpg");
                Bitmap picturetest = new Bitmap("C:\\Bot\\testcars5\\test.jpg");
                PixelFormat format = PixelFormat.Format24bppRgb;
                Bitmap Rmap = new Bitmap(picture.Width, picture.Height, format);
                Bitmap Gmap = new Bitmap(picture.Width, picture.Height, format);
                Bitmap Bmap = new Bitmap(picture.Width, picture.Height, format);
                Bitmap Noirmap = new Bitmap(picture.Width, picture.Height, format);

                int rMaxShadesDifs = 0;
                int gMaxShadesDifs = 0;
                int bMaxShadesDifs = 0;
                int noirMaxShadesDifs = 0;

                int rIdentical = 0;
                int gIdentical = 0;
                int bIdentical = 0;
                int noirIdentical = 0;

                for (int x = 0; x < picture.Width; x++)
                {
                    for (int y = 0; y < picture.Height; y++)
                    {
                        var colorValue0 = picture.GetPixel(x, y);
                        var colorValue1 = picturetest.GetPixel(x, y);
                        Rmap.SetPixel(x, y, (Color.FromArgb(Math.Abs((int)colorValue0.R - (int)colorValue1.R) * 10, 255, 255)));
                        if (rMaxShadesDifs < Math.Abs((int)colorValue0.R - (int)colorValue1.R)) rMaxShadesDifs = Math.Abs((int)colorValue0.R - (int)colorValue1.R);
                        if ((int)colorValue0.R - (int)colorValue1.R == 0) rIdentical++;

                        Gmap.SetPixel(x, y, (Color.FromArgb(255, Math.Abs((int)colorValue0.G - (int)colorValue1.G) * 10, 255)));
                        if (gMaxShadesDifs < Math.Abs((int)colorValue0.G - (int)colorValue1.G)) gMaxShadesDifs = Math.Abs((int)colorValue0.G - (int)colorValue1.G);
                        if ((int)colorValue0.G - (int)colorValue1.G == 0) gIdentical++;

                        Bmap.SetPixel(x, y, (Color.FromArgb(255, 255, Math.Abs((int)colorValue0.B - (int)colorValue1.B) * 10)));
                        if (bMaxShadesDifs < Math.Abs((int)colorValue0.B - (int)colorValue1.B)) bMaxShadesDifs = Math.Abs((int)colorValue0.B - (int)colorValue1.B);
                        if ((int)colorValue0.B - (int)colorValue1.B == 0) bIdentical++;

                        int noir = Math.Abs(((int)colorValue0.R + (int)colorValue0.G + (int)colorValue0.B) / 3 -
                            ((int)colorValue1.R + (int)colorValue1.G + (int)colorValue1.B) / 3);
                        Noirmap.SetPixel(x, y, (Color.FromArgb(noir, noir, noir)));
                        if (noirMaxShadesDifs < noir) noirMaxShadesDifs = noir;
                        if (noir == 0) noirIdentical++;
                    }
                }

                NotePad.DoErrorLog("Максимальное отклонение красный " + rMaxShadesDifs);
                NotePad.DoErrorLog("Максимальное отклонение зеленый " + gMaxShadesDifs);
                NotePad.DoErrorLog("Максимальное отклонение синий " + bMaxShadesDifs);
                NotePad.DoErrorLog("Максимальное отклонение нуар " + noirMaxShadesDifs);

                NotePad.DoErrorLog("красные совпали " + rIdentical);
                NotePad.DoErrorLog("зеленые совпали " + gIdentical);
                NotePad.DoErrorLog("синие совпали " + bIdentical);
                NotePad.DoErrorLog("нуар совпали " + noirIdentical);

                Rmap.Save("C:\\Bot\\Maps\\Rmap.jpg", ImageFormat.Jpeg);
                Gmap.Save("C:\\Bot\\Maps\\Gmap.jpg", ImageFormat.Jpeg);
                Bmap.Save("C:\\Bot\\Maps\\Bmap.jpg", ImageFormat.Jpeg);
                Noirmap.Save("C:\\Bot\\Maps\\Noirmap.jpg", ImageFormat.Jpeg);

                Rmap.Dispose();
                Gmap.Dispose();
                Bmap.Dispose();
                Noirmap.Dispose();
                picture.Dispose();
                picturetest.Dispose();
            } //for fun

            public void TestPictures()
            {
                Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);
                Rectangle HandSlot2 = new Rectangle(277, 725, 115, 65);
                Rectangle HandSlot3 = new Rectangle(469, 725, 115, 65);
                Rectangle HandSlot4 = new Rectangle(661, 725, 115, 65);
                Rectangle HandSlot5 = new Rectangle(853, 725, 115, 65);

                string carsDB = "testcars";
                Rectangle[] b = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
                for (int i = 0; i < 5; i++)
                {
                    MasterOfPictures.MakePicture(b[i], (carsDB + (i + 1) + "\\test1"));
                }
            } //fingers for test

            public string CalculateDifShades(string first, string second)
            {
                string result;
                Bitmap picture = new Bitmap(first);
                Bitmap picturetest = new Bitmap(second);
                int shadesdifs0 = 0;
                for (int x = 0; x < 50; x++)
                {
                    for (int y = 0; y < 50; y++)
                    {
                        var colorValue0 = picture.GetPixel(x, y);
                        var colorValue1 = picturetest.GetPixel(x, y);
                        int shadesdifs1 = (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                            Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                            Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                        shadesdifs0 += shadesdifs1;
                    }
                }
                result = shadesdifs0 + " diffs";
                picturetest.Dispose();
                picture.Dispose();
                return result;
            }

            public void SortCarDB()
            {
                int unknowncarsN = 0;
                int lastcar = 2000;
                int x0 = 32;
                int y0 = 7;
                NotePad.ClearLog();
                int foundcars = 0;
                int predictcars = 0;
                /*
                for(int i = 1; i < 1000; i++)
                {
                    if (File.Exists("C:\\Bot\\Finger1\\" + i + ".jpg"))
                    {
                        Bitmap picture = new Bitmap("C:\\Bot\\Finger1\\" + i + ".jpg");
                        for (int i1 = 1; i1 < 1000 - i; i1++)
                        {
                            if(File.Exists("C:\\Bot\\Finger1\\" + (i1 + i) + ".jpg"))
                            {
                                Bitmap picturetest = new Bitmap("C:\\Bot\\Finger1\\" + (i1 + i) + ".jpg");
                                int shadesdifs0 = 0;
                                Console.WriteLine("проверяю: позиция " + i + ", " + (i1 + i));
                                for (int x = 0; x < 50; x++)
                                {
                                    for (int y = 0; y < 50; y++)
                                    {
                                        var colorValue0 = picture.GetPixel(x + x0, y + y0);
                                        var colorValue1 = picturetest.GetPixel(x + x0, y + y0);
                                        int shadesdifs1 = (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                            Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                            Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                                        shadesdifs0 += shadesdifs1;
                                    }
                                }
                                if(shadesdifs0 > 0 && shadesdifs0 < 2000)
                                {
                                    Console.WriteLine("Проверь " + i + " и " + (i1 + i));
                                    NotePad.DoLog("");
                                }
                                picturetest.Dispose();
                            }
                        }
                        picture.Dispose();
                    }
                }
                */

                for (int i = 1; i < 5; i++)
                {
                    for (int i1 = 1; i1 < lastcar + 1; i1++)
                    {
                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i1 + ".jpg")) //несортированные
                        {
                            unknowncarsN++;
                            if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i1 + "old.jpg"))
                            {
                                File.Move("C:\\Bot\\Finger" + (i + 1) + "\\" + i1 + "old.jpg", "C:\\Bot\\Finger" + (i + 1) + "\\old" + i1 + ".jpg");
                            }
                            Bitmap picture = new Bitmap("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i1 + ".jpg");
                            Console.WriteLine("проверяю: позиция " + (i + 1) + ", unsorted " + i1);
                            for (int i0 = 1; i0 < lastcar; i0++)
                            {
                                if (File.Exists("C:\\Bot\\Finger1\\" + i0 + ".jpg"))
                                {
                                    Bitmap picturetest = new Bitmap("C:\\Bot\\Finger1\\" + i0 + ".jpg");
                                    int shadesdifs0 = 0;
                                    for (int x = 0; x < 50; x++)
                                    {
                                        for (int y = 0; y < 50; y++)
                                        {
                                            var colorValue0 = picture.GetPixel(x + x0, y + y0);
                                            var colorValue1 = picturetest.GetPixel(x + x0, y + y0);
                                            int shadesdifs1 = (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                                Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                                Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                                            shadesdifs0 += shadesdifs1;
                                        }
                                    }
                                    if (shadesdifs0 < 40000)
                                    {
                                        picture.Dispose();
                                        Console.WriteLine("совпали");
                                        NotePad.DoLog("");
                                        NotePad.DoLog("Считаю одинаковыми Finger" + (i + 1) + "\\unsorted" + i1);
                                        NotePad.DoLog("и Finger1\\" + i0);
                                        NotePad.DoLog("Различие в " + shadesdifs0 + " оттенков");
                                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg"))
                                        {
                                            File.Move("C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg",
                                                "C:\\Bot\\Finger" + (i + 1) + "\\old" + i0 + ".jpg");
                                            NotePad.DoLog("Обновляю C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg" + i0);
                                            Console.WriteLine("Обновляю C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg" + i0);
                                        }
                                        File.Move("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i1 + ".jpg",
                                            "C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg");
                                        foundcars++;
                                        break;
                                    }
                                    if (shadesdifs0 >= 40000 && shadesdifs0 < 60000)
                                    {
                                        picture.Dispose();
                                        Console.WriteLine("похожи");
                                        NotePad.DoLog("");
                                        NotePad.DoLog("Вероятно, одинаковые Finger" + (i + 1) + "\\unsorted" + i1);
                                        NotePad.DoLog("и Finger1\\" + i0);
                                        NotePad.DoLog("Различие в " + shadesdifs0 + " оттенков");
                                        File.Copy("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i1 + ".jpg",
                                            "C:\\Bot\\Finger" + (i + 1) + "\\" + i0 + ".jpg");
                                        predictcars++;
                                        break;
                                    }
                                    picturetest.Dispose();
                                }
                                else break; //ВЫКЛЮЧИТЬ если есть пробелы нумерации
                            }
                            picture.Dispose();
                        }
                    }
                }

                NotePad.DoLog("");
                Console.WriteLine("найдено машин: " + foundcars);
                Console.WriteLine("вероятных совпадений " + predictcars);
                NotePad.DoLog("найдено машин: " + foundcars);
                NotePad.DoLog("вероятных совпадений " + predictcars);
                Console.WriteLine("осталось неизвестных " + (unknowncarsN - foundcars));
            }
        }

        // Rest ====================================================================================================

        private void CutTheRest()
        {
            int lines = 0;
            
            using (StreamReader sr = new StreamReader(@"D:\Bot\thereisnothinginteresting\lol.txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    lines++;
                }
                sr.Close();
            }
            string[] a = new string[lines];
            
            using (StreamReader sr = new StreamReader(@"D:\Bot\thereisnothinginteresting\lol.txt", System.Text.Encoding.Default))
            {
                for (int i = 0; i < lines; i++)
                {
                    a[i] = sr.ReadLine();
                }
                sr.Close();
            }
            string[] b = new string[lines / 3];
            string[] c = new string[lines / 3];
            for (int i = 0; i < lines / 3; i++)
            {
                b[i] = a[i * 3];
            }
            int[] b1 = new int[lines / 3];
            for (int i = 0; i < lines / 3; i++)
            {
                b1[i] = Transform(b[i]);
            }
            for (int i = 0; i < lines / 3; i++)
            {
                c[i] = a[(i * 3) + 1];
            }
            string[] c1 = new string[lines / 3];
            for (int i = 0; i < lines / 3; i++)
            {
                c1[i] = Transform1(c[i]);
            }
            for (int i = 0; i < lines / 3; i++)
            {
                for (int i1 = 0; i1 < lines / 3; i1++)
                {
                    if (b1[i] < b1[i1])
                    {
                        int integer = b1[i];
                        b1[i] = b1[i1];
                        b1[i1] = integer;
                        string name = c1[i];
                        c1[i] = c1[i1];
                        c1[i1] = name;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\CarPictureToCarNameRemastered.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < lines / 3; i++)
                {
                    sw.WriteLine(b1[i] + " " + c1[i]);
                }
                sw.Close();
            }
        }

        public int Transform(string t)
        {
            string a = t.Trim();
            string b;
            int c;
            char[] word = new char[a.Length - 6];
            for (int i = 0; i < word.Length; i++)
            {
                word[i] = a[i + 5];
            }
            b = new string(word);
            c = Convert.ToInt32(b);
            return c;
        }

        public string Transform1(string t)
        {
            string a = t.Trim();
            string b;
            char[] word = new char[a.Length - 13];
            for (int i = 0; i < word.Length; i++)
            {
                word[i] = a[i + 11];
            }
            b = new string(word);
            return b;
        }
        
    }
}