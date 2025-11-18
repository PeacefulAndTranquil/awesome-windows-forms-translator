using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui_translator
{
    public partial class Form1 : Form
    {

        static Translator translator;
        public Form1()
        {
            InitializeComponent();
            translator = new Translator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void import_csv_button_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory="Downloads";
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                translator = Translator.ImportFromCSV(path);

                lang_1_name_label.Text = translator.GetLang1Name();
                lang_2_name_label.Text = translator.GetLang2Name();
            }
        }

        private void import_ftl_button_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory="Downloads";
            openFileDialog1.Filter = "SS14 ftl accent files (*.ftl)|*.ftl|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                translator = Translator.ImportFromSS14FTL(path);
                lang_1_name_label.Text = translator.GetLang1Name();
                lang_2_name_label.Text = translator.GetLang2Name();
            }
            
        }

        static bool byCode;
        private void lang_1_box_TextChanged(object sender, EventArgs e)
        {
            if (!byCode)
            {
                byCode = true;
                lang_2_box.Text = translator.Translate1To2(lang_1_box.Text);
                byCode = false;
            }
        }
        private void lang_2_box_TextChanged_1(object sender, EventArgs e)
        {
            if (!byCode)
            {
                byCode = true;
                lang_1_box.Text = translator.Translate2To1(lang_2_box.Text);
                byCode = false;
            }
        }
    }
}
