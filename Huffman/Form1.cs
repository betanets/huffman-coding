using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Huffman
{
    public partial class Form1 : Form
    {
        private TextKeeper keeper;
        private HuffmanKeeper huffmanKeeper;
        private Tree huffmanTree;

        public Form1()
        {
            InitializeComponent();
            keeper = new TextKeeper();
            huffmanKeeper = new HuffmanKeeper();
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
                        keeper.clearText();
                        StreamReader sr;
                        using (sr = new StreamReader(openFileDialog.FileName))
                        {
                            Int64 length = 0;
                            String line;
                            while (sr.Peek() >= 0)
                            {
                                line = sr.ReadLine();
                                keeper.addLine(line);
                                length += line.Length;
                            }
                            sr.Close();
                            keeper.textLength = length;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось прочитать файл. Подробная информация об ошибке: " + ex.Message);
                }

                buildTreeAndTable();
            }
        }

        private void buildTreeAndTable()
        {
            huffmanTree.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            richTextBox_result.Clear();
            /*Thread treeCreator = new Thread(() => { */
            huffmanTree.Build(keeper.getText());// });
                                                //treeCreator.Start();
            dataGridView1.Columns.Add("Key", "Символ");
            dataGridView1.Columns.Add("Count", "Кол-во");
            dataGridView1.Columns.Add("Code", "Код");
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 120;
            Double sum = 0;
            foreach (KeyValuePair<char, int> item in huffmanTree.Frequencies)
            {
                //Node node = new Node();
                List<bool> codeBoolean = huffmanTree.Root.Traverse(item.Key, new List<bool>());
                var sb = new StringBuilder();
                foreach (bool bit in codeBoolean)
                {
                    sb.Append(bit ? 1 : 0);
                }
                dataGridView1.Rows.Add(item.Key,
                                        /*String.Format("{0:0.00%}", ((Double)*/item.Value/* / keeper.textLength))*/,
                                        sb.ToString()
                                        );
                sum += ((Double)item.Value / keeper.textLength) * sb.Length;
            }
            dataGridView1.Sort(dataGridView1.Columns[1], System.ComponentModel.ListSortDirection.Descending);
            this.label_averageCodeLength.Text = "Средняя длина кода: " + String.Format("{0:0.000}", sum);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void построитьКодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            huffmanKeeper.clearKeeper();

            huffmanKeeper.setEncodedText(huffmanTree.Encode(keeper.getText()));

            var sb = new StringBuilder();
            foreach (bool bit in huffmanKeeper.getEncodedText())
            {
                sb.Append(bit ? 1 : 0);
            }
            richTextBox_result.Text = sb.ToString();
        }

        private void декодироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_result.Text = huffmanTree.Decode(huffmanKeeper.getEncodedText());
        }
    }
}
