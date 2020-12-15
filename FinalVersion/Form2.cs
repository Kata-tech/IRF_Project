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

namespace FinalVersion
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            List<Adat> Lista = new List<Adat>();
            Lista = GetLista(@"C:/Temp/ajanlatok.csv");
            dataGridView1.DataSource = Lista;

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
    }
}
