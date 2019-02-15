using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Laboration4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void StartIntegrationButton_Click(object sender, EventArgs e)
        {
            integrationInProgressLabel.Visible = true;

            string directory = Directory.GetCurrentDirectory() + @"\frMediaShop";
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher()
            {
                Path = directory,
                Filter = "*.csv",
                NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite
            };
            fileSystemWatcher.Created += FileCreatedOrChanged;
            fileSystemWatcher.Changed += FileCreatedOrChanged;
            fileSystemWatcher.EnableRaisingEvents = true;

            string reverseDirectory = Directory.GetCurrentDirectory() + @"\frSimpleMedia";
            FileSystemWatcher reverseFileSystemWatcher = new FileSystemWatcher()
            {
                Path = reverseDirectory,
                Filter = "*.xml",
                NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite
            };
            reverseFileSystemWatcher.Created += ReverseFileCreatedOrChanged;
            reverseFileSystemWatcher.Changed += ReverseFileCreatedOrChanged;
            reverseFileSystemWatcher.EnableRaisingEvents = true;
        }

        private void FileCreatedOrChanged(object sender, FileSystemEventArgs e)
        {
            CreateXMLFromCsv();
        }

        private void ReverseFileCreatedOrChanged(object sender, FileSystemEventArgs e)
        {
            CreateCsvFromXML();
        }

        private void CreateXMLFromCsv()
        {
            string CSVFilePath = Directory.GetCurrentDirectory() + @"\frMediaShop\Products.csv";
            string XMLFilePath = Directory.GetCurrentDirectory() + @"\tillSimpleMedia\Products.xml";
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true
            };
            XmlWriter xmlWriter = XmlWriter.Create(XMLFilePath, xmlWriterSettings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Inventory");

            using (StreamReader streamReader = new StreamReader(CSVFilePath))
            {
                string line;
                string[] lineData;
                while ((line = streamReader.ReadLine()) != null)
                {
                    lineData = line.Split(';');
                    xmlWriter.WriteStartElement("Item");

                    xmlWriter.WriteStartElement("Name");
                    xmlWriter.WriteString(lineData[1]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Count");
                    xmlWriter.WriteString(lineData[6]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Price");
                    xmlWriter.WriteString(lineData[2]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Comment");
                    xmlWriter.WriteString("");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Artist");
                    xmlWriter.WriteString(lineData[4]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Publisher");
                    xmlWriter.WriteString(lineData[5]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Genre");
                    xmlWriter.WriteString("");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("Year");
                    xmlWriter.WriteString("0");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement("ProductID");
                    xmlWriter.WriteString(lineData[0]);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement(); // </Item>
                }
            }

            xmlWriter.WriteEndElement(); // </Inventory>
            xmlWriter.Close();
        }

        private void CreateCsvFromXML()
        {
            string XMLFilePath = Directory.GetCurrentDirectory() + @"\frSimpleMedia\Products.xml";
            string CSVFilePath = Directory.GetCurrentDirectory() + @"\tillMediaShop\Products.csv";
            XDocument xDocument = XDocument.Load(XMLFilePath);
            using (StreamWriter streamWriter = new StreamWriter(CSVFilePath))
            {
                foreach (XElement item in xDocument.Descendants("Item"))
                {
                    List<XElement> elements = item.Descendants().ToList();
                    string product = elements.First(x => x.Name == "ProductID").Value + ";";
                    product += elements.First(x => x.Name == "Name").Value + ";";
                    product += elements.First(x => x.Name == "Price").Value + ";";
                    product += "Ospecifierad;"; // Det finns ingen motsvarighet till varutyp från SimpleMedia.
                    product += elements.First(x => x.Name == "Artist").Value + ";";
                    product += elements.First(x => x.Name == "Publisher").Value + ";";
                    product += elements.First(x => x.Name == "Count").Value + ";";
                    product += "0"; // Det finns ingen motsvarighet till antal sålda från SimpleMedia.
                    streamWriter.WriteLine(product);
                }
            }
        }
    }
}
