using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Huffman
{
    public partial class HuffmanMain : Form
    {
        private Tree huffmanTree;

        public HuffmanMain()
        {
            InitializeComponent();
            huffmanTree = new Tree();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                label_file.Text = "Файл выбран: " + openFileDialog.FileName;
                try
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        var sb = new StringBuilder();
                        StreamReader sr;
                        using (sr = new StreamReader(openFileDialog.FileName))
                        {
                            Int64 length = 0;
                            String line;
                            while (sr.Peek() >= 0)
                            {
                                line = sr.ReadLine();
                                sb.AppendLine(line);
                                length += line.Length;
                            }
                            sr.Close();
                            huffmanTree.textLength = length;
                        }
                        RTB_text.Text = sb.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось прочитать файл. Подробная информация об ошибке: " + ex.Message);
                }
            }
        }

        private void buildTree()
        {
            huffmanTree.Clear();
            huffmanTree.textLength = RTB_text.Text.Length;
            huffmanTree.Build(RTB_text.Text);
        }

        private void buildTable() {
            label_compressionPercent.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Key", "Символ");
            dataGridView1.Columns.Add("Count", "Кол-во");
            dataGridView1.Columns.Add("Code", "Код");
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 120;

            Double sum = 0;
            foreach (KeyValuePair<char, int> item in huffmanTree.Frequencies)
            {
                List<bool> codeBoolean = huffmanTree.Root.Traverse(item.Key, new List<bool>());
                var sb = new StringBuilder();
                foreach (bool bit in codeBoolean)
                {
                    sb.Append(bit ? 1 : 0);
                }
                dataGridView1.Rows.Add(item.Key, item.Value, sb.ToString());
                sum += ((Double)item.Value / huffmanTree.textLength) * sb.Length;
            }
            dataGridView1.Sort(dataGridView1.Columns[1], System.ComponentModel.ListSortDirection.Descending);
            this.label_averageCodeLength.Text = "Средняя длина кода: " + String.Format("{0:0.000}", sum);
        }

        private void открытьКодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                label_file.Text = "Файл кода выбран: " + openFileDialog.FileName;
                try
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        byte[] byteArray = File.ReadAllBytes(openFileDialog.FileName);
                        var sb = new StringBuilder();
                        List<bool> bits = byteArray.SelectMany(Helpers.GetBitsStartingFromLSB).ToList();
                        foreach (var b in bits)
                        {
                            sb.Append(b ? 1 : 0);
                        }
                        RTB_code.Text = sb.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось прочитать файл кода. Подробная информация об ошибке: " + ex.Message);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void построитьКодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<bool> encodedBits = huffmanTree.Encode(RTB_text.Text);

            var sb = new StringBuilder();
            foreach (bool bit in encodedBits)
            {
                sb.Append(bit ? 1 : 0);
            }
            RTB_code.Text = sb.ToString();
        }

        private void декодироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<bool> encodedBits = new List<bool>();
            foreach (char sym in RTB_code.Text)
            {
                if (sym == '1') {
                    encodedBits.Add(true);
                }
                else if (sym == '0')
                {
                    encodedBits.Add(false);
                }
            }
            RTB_text.Text = huffmanTree.Decode(encodedBits);
        }

        private void сохранитьКодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: move to helpers
            List<bool> encodedBits = new List<bool>();
            foreach (char sym in RTB_code.Text)
            {
                if (sym == '1')
                {
                    encodedBits.Add(true);
                }
                else if (sym == '0')
                {
                    encodedBits.Add(false);
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Бинарный файл|*.bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        byte[] bytes = Helpers.PackBoolsInByteArray(encodedBits);
                        fs.Write(bytes, 0, bytes.Length);
                    }

                    //Расчёт ведётся по размеру в RTB. Считается, что 1 символ текста = 8 бит, 1 символ кода = 1 бит
                    long inputSize = RTB_text.Text.Length * 8;
                    long outputSize = RTB_code.Text.Length;
                    label_compressionPercent.Text = "Степерь сжатия: " + String.Format("{0:0.000%}", ((Double)outputSize / inputSize));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось сохранить файл кода. Подробная информация об ошибке: " + ex.Message);
                }
            }
        }

        private void сохранитьДеревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Бинарный файл|*.bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        formatter.Serialize(fs, huffmanTree);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось сохранить файл дерева. Подробная информация об ошибке: " + ex.Message);
                }
            }      
        }

        private void открытьДеревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        huffmanTree = (Tree)formatter.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось прочитать файл дерева. Подробная информация об ошибке: " + ex.Message);
                }
                buildTable();
            }
        }

        private void построитьДеревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buildTree();
            buildTable();
        }
    }
}
