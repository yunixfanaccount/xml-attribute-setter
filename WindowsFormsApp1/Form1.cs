using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        XDocument doc;
        public Form1()
        {
            InitializeComponent();

        }


        //specify attribute
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //specify element1
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //specify element1 value
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        //button1
        private void button1_Click(object sender, EventArgs e)
        {
            if(doc == null) {
                MessageBox.Show("select a file first");
                return;
            }

            //if element doesnt exist, go away
            if(!doc.Root.Elements().Any(v => v.Name == elementName.Text)) {
                MessageBox.Show("error. invalid element");
                return;
            }

            var element = doc.Root.Element(elementName.Text);

            label2.Text = "success!";
            
            if(element.Attributes().Any(v => v.Name == attributeName.Text)) {
                DialogResult result = MessageBox.Show("The attribute already exists. Overwrite it?", "Overwrite?", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    var attribute = element.Attribute(attributeName.Text);
                    attribute.SetValue(attributeValue.Text);
                }
                else
                {
                    return;

                }

            } else {
                element.Add(new XAttribute(attributeName.Text, attributeValue.Text));
            }
            label3.Text = "success!";
            // create the attribute
            
            label4.Text = "success!";

            doc.Save(openFileDialog1.FileName);

            /*
            <root>
                <foo></foo>
            </root>
            */
        }

        //button browse
        private void button3_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                doc = XDocument.Load(openFileDialog1.FileName);
                label1.Text = openFileDialog1.FileName;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }



        //label if good or not 1
        private void label2_Click(object sender, EventArgs e)
        {
         
        }

        //label if good or not 2
        private void label3_Click(object sender, EventArgs e)
        {

        }

        //label if good or not 3
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
