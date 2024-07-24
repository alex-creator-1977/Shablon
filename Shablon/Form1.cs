using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Shablon
{

    public partial class Form1 : Form
    {
        string? resultpath = null;
        string? templatepath = null;

        Excel.Application objApp;
        Excel._Workbook objBook;

        public Form1()
        {
            InitializeComponent();
        }
        //загрузить исходные данные
        private void btnLoadData_Click(object sender, System.EventArgs e)
        {
            Excel.Sheets objSheets;
            Excel._Worksheet objSheet;
            Excel.Range range;
            Excel.Workbooks objBooks;

            var DataList = new List<DataElement>();

            try
            {
                // Instantiate Excel and start a new workbook.
                objApp = new Excel.Application();

                // string filePath = GetFileFromDialog();
                string filePath = "C:\\Users\\Besitzer\\source\\repos\\Shablon\\Shablon\\данные2.xlsx";
                if (!string.IsNullOrEmpty(filePath))
                {
                    try
                    {
                        //Get a reference to the first sheet of the workbook.

                        objBook = objApp.Workbooks.Open(filePath);
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
                    lblDataElement.Text = lblDataElement.Text + " " + DataList.Count;
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
        }



        private string GetFileFromDialog(string sMask = "excel files (*.xlsx)|*.xlsx;")
        {
            string filePath = string.Empty;

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
            return filePath;
        }

        //Выбрать папку для результа
        private void btnChooseResultFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                resultpath = folderBrowserDialog1.SelectedPath;
                lblResult.Text = resultpath;
            }
        }

        private void btnChooseTemplate_Click(object sender, EventArgs e)
        {
            templatepath = GetFileFromDialog("word files (*.docx)|*.docx;");
            lblTemplate.Text = lblTemplate.Text + " " + templatepath;
        }

        private void btnFillTemplate_Click(object sender, EventArgs e)
        {

        }
    }



}

