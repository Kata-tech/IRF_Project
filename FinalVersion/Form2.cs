using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalVersion.Entities;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace FinalVersion
{
    public partial class Form2 : Form
    {
        Excel.Application xlApp; // A Microsoft Excel alkalmazás
        Excel.Workbook xlWB; // A létrehozott munkafüzet
        Excel.Worksheet xlSheet; // Munkalap a munkafüzeten belül

        List<Adat> Lista = new List<Adat>();

        public Form2()
        {
            
            InitializeComponent();
            
            Lista = GetLista(@"C:/Temp/ajanlatok.csv");
            dataGridView1.DataSource = Lista;

            

            CreateExcel();

        }
        public List<Adat> GetLista(string csvpath)
        {

            List<Adat> lista = new List<Adat>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                sr.ReadLine(); // Remove headers
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    lista.Add(new Adat()
                    {
                        Telepules = line[0],
                        Hotelnev = line[1],
                        Sorszam = line[2],
                        Ejszaka = int.Parse(line[3]),
                        Forint = int.Parse(line[4])
                    });
                }

            }
            return lista;

        }

        public void CreateExcel()
        {

            try
            {
                // Excel elindítása és az applikáció objektum betöltése
                xlApp = new Excel.Application();

                // Új munkafüzet
                xlWB = xlApp.Workbooks.Add(Missing.Value);

                // Új munkalap
                xlSheet = xlWB.ActiveSheet;

                // Tábla létrehozása
                CreateTable(); // Ennek megírása a következő feladatrészben következik

                // Control átadása a felhasználónak
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex) // Hibakezelés a beépített hibaüzenettel
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                // Hiba esetén az Excel applikáció bezárása automatikusan
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        public void CreateTable()
        {
            string[] headers = new string[] {
             "Település",
             "Hotel név",
             "Sorszám",
             "Éjszakák száma",
             "Fő/éjszaka (forint)",
             };

            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, 1 + i] = headers[i];
            }

            object[,] values = new object[Lista.Count, headers.Length];

            int counter = 0;
            foreach (Adat a in Lista)
            {
                values[counter, 0] = a.Telepules;
                values[counter, 1] = a.Hotelnev;
                values[counter, 2] = a.Sorszam;
                values[counter, 3] = a.Ejszaka;
                values[counter, 4] = a.Forint;
                counter++;
            }

            string GetCell(int x, int y)
            {
                string ExcelCoordinate = "";
                int dividend = y;
                int modulo;

                while (dividend > 0)
                {
                    modulo = (dividend - 1) % 26;
                    ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                    dividend = (int)((dividend - modulo) / 26);
                }
                ExcelCoordinate += x.ToString();

                return ExcelCoordinate;
            }
            xlSheet.get_Range(
             GetCell(2, 1),
             GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
        }
        }
}
