using Aspose.Words;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace Shablon
{



    public partial class Form1 : Form
    {
        const string Nr = "nr";
        const string Variable_bt = "variable_bt";
        const string Variable_sn = "variable_sn";
        const string Variable_year2 = "variable_year2";
        const string Variable_fio = "variable_fio";
        const string Variable_datepr = "variable_datepr";
        const string Variable_year1 = "variable_year1";

        Excel.Application objApp;
        Excel._Workbook objBook;

        public Form1()
        {
            InitializeComponent();
        }
        //загрузить исходные данные
        private void button1_Click(object sender, System.EventArgs e)
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

                     
 
                  

                    for (long rowCounter = 1; rowCounter <= iRows; rowCounter++)
                    {
                       
                        for (long colCounter = 1; colCounter <= iCols; colCounter++)
                        {
                                var   valueString = saRet[rowCounter, 1];
                            //Write the next value into the string.
                            valueString = String.Concat(valueString, saRet[rowCounter, colCounter].ToString() + ", ");


                        }
 
                    }
 
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


    }

    internal class DataElement
    {
        public required string Nr { get; set; }
        public required bool Variable_bt { get; set; }
        public required string Variable_sn { get; set; }
        public required string Variable_year2 { get; set; }
        public required string Variable_fio { get; set; }
        public required string Variable_datepr { get; set; }
        public required string Variable_year1 { get; set; }

    }
}

