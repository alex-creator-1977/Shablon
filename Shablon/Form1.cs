
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Json.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
namespace Shablon
{

    public partial class Form1 : Form
    {
        const string settingspath = "settings.json";
        bool loadSettingFromFile = false;
        Settings settings = new Settings();

        /* string? resultpath = null;
         string? templatefile = null;*/

        Excel.Application objApp;
        Excel._Workbook objBook;
        List<DataElement>? DataList = null;
        public Form1()
        {
            InitializeComponent();
            settings.FileNamePrefix = "прибор_SN_";
            settings.LoadDataPath = string.Empty;
            settings.ResultFolderPath = string.Empty;
            btnSaveSettings.Enabled = false;
        }
        //загрузить исходные данные
        private void btnLoadData_Click(object sender, System.EventArgs e)
        {
            LoadData();
            if (loadSettingFromFile)
            {
                btnFillTemplate.Enabled = true;
                btnSaveSettings.Enabled = true;
            }
            else
            {
                btnLoadData.Enabled = false;
                btnChooseResultFolder.Enabled = true;
                //btnSaveSettings.Enabled = true;

            }

        }

        void LoadData()
        {
            Excel.Sheets objSheets;
            Excel._Worksheet objSheet;
            Excel.Range range;
            Excel.Workbooks objBooks;

            DataList = new List<DataElement>();

            try
            {
                // Instantiate Excel and start a new workbook.
                objApp = new Excel.Application();

                if (settings.LoadDataPath == string.Empty)
                    settings.LoadDataPath = GetFileFromDialog();


                // string filePath = "C:\\Users\\Besitzer\\source\\repos\\Shablon\\Shablon\\данные2.xlsx";
                if (!string.IsNullOrEmpty(settings.LoadDataPath))
                {
                    try
                    {
                        //Get a reference to the first sheet of the workbook.

                        objBook = objApp.Workbooks.Open(settings.LoadDataPath);
                        objSheets = objBook.Worksheets;
                        objSheet = (Excel._Worksheet)objSheets.get_Item(1);
                    }

                    catch (Exception theException)
                    {
                        String errorMessage;
                        errorMessage = "Can't find the Excel workbook.  Try clicking Button1";

                        MessageBox.Show(errorMessage, "Missing Workbook?");

                        //You can't automate Excel if you can't find the data you created, so 
                        //leave the subroutine.
                        return;
                    }

                    //Get a range of data.
                    //range = objSheet.get_Range("A1", "G2");
                    range = objSheet.UsedRange;
                    //Retrieve the data from the range.
                    Object[,] saRet;
                    saRet = (System.Object[,])range.get_Value(Missing.Value);

                    //Determine the dimensions of the array.
                    long iRows;
                    long iCols;
                    iRows = saRet.GetUpperBound(0);
                    iCols = saRet.GetUpperBound(1);

                    DataElement? Element = null;

                    for (long rowCounter = 1; rowCounter <= iRows; rowCounter++)
                    {
                        if (rowCounter > 1)
                            Element = new DataElement();

                        for (long colCounter = 1; colCounter <= iCols; colCounter++)
                        {
                            var DataFiled = saRet[1, colCounter];

                            if (rowCounter > 1)
                            {
                                //Write the next value into the string.
                                var objFieldvalue = saRet[rowCounter, colCounter];

                                if (objFieldvalue != null && DataFiled != null)

                                {
                                    string fieldvalue = objFieldvalue.ToString().Trim();


                                    switch (DataFiled.ToString().Trim())
                                    {
                                        case DataFields.nr:
                                            Element.Nr = fieldvalue;
                                            break;
                                        case DataFields.variable_bt:
                                            Element.Variable_bt = "нет";
                                            if (fieldvalue == "+")
                                                Element.Variable_bt = "есть";
                                            break;
                                        case DataFields.variable_sn:
                                            Element.Variable_sn = fieldvalue;
                                            break;
                                        case DataFields.variable_year2:
                                            Element.Variable_year2 = fieldvalue;
                                            break;
                                        case DataFields.variable_fio:
                                            Element.Variable_fio = fieldvalue;
                                            break;
                                        case DataFields.variable_datepr:

                                            string? dateString = null;

                                            if (objFieldvalue is DateTime)
                                            {
                                                dateString = Convert.ToDateTime(fieldvalue).ToString("dd.MM.yyyy");

                                            }
                                            else
                                            {
                                                dateString = fieldvalue;
                                            }

                                            Element.Variable_datepr = dateString;


                                            break;
                                        case DataFields.variable_year1:
                                            Element.Variable_year1 = fieldvalue;
                                            break;
                                        default:

                                            break;
                                    }
                                }
                            }

                        }
                        if (Element != null)
                        {
                            if (!String.IsNullOrEmpty(Element.Nr)
                                && !String.IsNullOrEmpty(Element.Variable_bt)
                                && !String.IsNullOrEmpty(Element.Variable_sn)
                                && !String.IsNullOrEmpty(Element.Variable_year2)
                                && !String.IsNullOrEmpty(Element.Variable_fio)
                                && !String.IsNullOrEmpty(Element.Variable_datepr)
                                && !String.IsNullOrEmpty(Element.Variable_year1))
                            {
                                DataList.Add(Element);
                            }

                        }
                    }

                    lblDataElement.Text = string.Concat("Путь к данным: ", settings.LoadDataPath, " загружено: ", DataList.Count, " объекта");
                    MessageBox.Show(lblDataElement.Text);


                }
            }

            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
            finally
            {
                if (objBook != null)
                {
                    objBook.Close();
                }
            }
        }



        private string GetFileFromDialog(string sMask = "excel files (*.xlsx)|*.xlsx;")
        {
            string filePath = string.Empty;
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = sMask; /*"excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";*/
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                    }
                }
            }
            catch (Exception theException)
            {
                MessageBox.Show(theException.Message);
            }

            return filePath;
        }

        //Выбрать папку для результа
        private void btnChooseResultFolder_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        settings.ResultFolderPath = folderBrowserDialog1.SelectedPath;
                        lblResult.Text = lblResult.Text + " " + settings.ResultFolderPath;
                        btnChooseResultFolder.Enabled = false;
                        btnChooseTemplate.Enabled = true;
                    }
                }
            }
            catch (Exception theException)
            {
                MessageBox.Show(theException.Message);
            }

        }

        private void btnChooseTemplate_Click(object sender, EventArgs e)
        {
            settings.TemplateFile = GetFileFromDialog("word files (*.docx)|*.docx;");
            if (settings.TemplateFile != string.Empty)
            {
                lblTemplate.Text = lblTemplate.Text + " " + settings.TemplateFile;
                btnChooseTemplate.Enabled = false;
                btnFillTemplate.Enabled = true;
                btnSaveSettings.Enabled = true;
            }

        }

        private void btnFillTemplate_Click(object sender, EventArgs e)
        {
            Word._Application? oWord = null;
            Word.Document? oDoc = null;
            try
            {
                oWord = new Word.Application();
                oDoc = oWord.Documents.Add(settings.TemplateFile);

                int iCount = 0;
                if (!String.IsNullOrEmpty(settings.TemplateFile))
                {
                    if (DataList != null)
                    {
                        foreach (DataElement element in DataList)
                        {

                            // Debug.WriteLine(oDoc.ContentControls.Count); 
                            foreach (ContentControl item in oDoc.ContentControls)
                            {

                                // ContentControls controls = oDoc.SelectContentControlsByTitle(item.Tag);
                                ContentControls controls = oDoc.SelectContentControlsByTag(item.Tag);
                                ContentControl control = controls[1];
                                //  control.Range.Text = "тест";

                                //Debug.WriteLine(item.Tag);
                                switch (item.Tag)
                                {

                                    case DataFields.variable_bt:
                                        control.Range.Text = element.Variable_bt;

                                        break;
                                    case DataFields.variable_sn:
                                        control.Range.Text = element.Variable_sn;
                                        break;
                                    case DataFields.variable_year2:
                                        control.Range.Text = element.Variable_year2;
                                        break;
                                    case DataFields.variable_fio:
                                        control.Range.Text = element.Variable_fio;
                                        break;
                                    case DataFields.variable_datepr:
                                        control.Range.Text = element.Variable_datepr;
                                        break;
                                    case DataFields.variable_year1:
                                        control.Range.Text = element.Variable_year1;
                                        break;
                                    default:

                                        break;
                                }
                            }
                            // oWord.Selection.Range.ContentControls    Item(DataFields.variable_bt);

                            //  Debug.WriteLine(item.SetPlaceholderText); 

                            oDoc.SaveAs(FileName: settings.ResultFolderPath + "\\" + settings.FileNamePrefix + element.Variable_sn + "_" + DateTime.Now.ToString("dd.MM.yyyyTHH-mm-ss") + ".docx");   //Путь к заполненному шаблону
                            iCount++;
                        }


                    }
                    MessageBox.Show("Выполнено! " + iCount + " файлов создано!");
                    btnFillTemplate.Enabled = false;
                    btnLoadData.Enabled = true;

                    lblDataElement.Text = "Путь к данным:";
                    lblResult.Text = "Путь к результату:";
                    lblTemplate.Text = "Выбран шаблон:";
                    lblResultData.Text = "Заполнено шаблонов:";
                    loadSettingFromFile = false;
                    settings = null;
                    /* btnSaveSettings.Enabled = true;
                     if (loadSettingFromFile)*/
                    btnSaveSettings.Enabled = false;


                }
            }
            catch (Exception theException)
            {
                MessageBox.Show(theException.Message);
            }
            finally
            {
                if (oDoc != null)
                    oDoc.Close();
            }

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {

            WriteToJsonFile(settingspath, settings);
            // btnChooseResultFolder
            //btnChooseTemplate

        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            if (File.Exists(settingspath))
            {
                settings = ReadFromJsonFile<Settings>(settingspath);
                //btnFillTemplate.Enabled = true;
                lblResult.Text = "Путь к результату: " + settings.ResultFolderPath;
                lblTemplate.Text = "Выбран шаблон: " + settings.TemplateFile;
                lblDataElement.Text = "Путь к данным: " + settings.LoadDataPath;
                loadSettingFromFile = true;
            }
            else
            {

                MessageBox.Show(settingspath + " не найден");
            }

        }

        /// <summary>
        /// Writes the given object instance to a Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

        }
    }

}

