using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCrud.Excel.Metadatas;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;

namespace GenericCrud.Excel.Impl
{
    public class ExcelProxyOpenXML : ExcelProxyAbstract<Workbook, SpreadsheetDocument, WorksheetPart>
    {
        public override void Dispose()
        {
            if(this.app != null)
            {
                this.app.Dispose();
            }
        }

        public WorkbookPart WorkbookPart { get; set; }

        public ExcelProxyOpenXML() : base()
        {
            base.zeroBasedIndex = true;
        }

        public ExcelProxyOpenXML(string fullFileName) : base(fullFileName)
        {
            base.zeroBasedIndex = true;
        }
        private SheetData InitElementsWithIndex(WorksheetPart worksheetpart, int rowIndex, int colIndex)
        {
            if (worksheetpart.Worksheet == null)
                worksheetpart.Worksheet = new Worksheet();

            var worksheet = worksheetpart.Worksheet;
            var sheetData = worksheet.Elements<SheetData>().FirstOrDefault();

            if (sheetData == null)
            {
                sheetData = new SheetData();
                worksheet.Append(sheetData);
            }
            
            var rows = sheetData.Elements<Row>();

            if(rows != null)
            {
                var count = rows.Count();
                if ((count - 1) < rowIndex)
                {
                    var length = rowIndex - (count - 1);
                    for(int index = 0; index < length; index++)
                    {
                        Row row = new Row();
                        sheetData.Append(row);
                    }
                }
                rows = sheetData.Elements<Row>();

                var indexRow = rows.ToList()[rowIndex];

                var cells = indexRow.Elements<Cell>();

                if(cells != null)
                {
                    var count1 = cells.Count();
                    if ((count1 - 1) < colIndex)
                    {
                        var length = colIndex - (count1 - 1);
                        for (int index = 0; index < length; index++)
                        {
                            Cell cell = new Cell();
                            indexRow.Append(cell);
                        }
                    }
                }
            }
            return sheetData;
        }

        public override void EscreverCabecalho(WorksheetPart worksheetpart, string label, object value, int rowIndex, int colIndex, CellOptions cellOptions)
        {
            
            var sheetData = InitElementsWithIndex(worksheetpart, 0, colIndex);
            var cell = GetCell(sheetData, 0, colIndex);
            cell.DataType = CellValues.InlineString;

            InlineString inlineString = new InlineString();
            Text text = new Text();
            text.Text = label;

            inlineString.Append(text);
            cell.Append(inlineString);
            
        }

        private Cell GetCell(SheetData sheetData, int rowIndex, int colIndex)
        {
            var rows = sheetData.Elements<Row>();
            if((rows.Count() -1) <= rowIndex)
            {
                var row = rows.ToList()[rowIndex];
                if(row != null)
                {
                    var cells = row.Elements<Cell>();
                    if(cells != null && (cells.Count() - 1) <= colIndex)
                    {
                        return cells.ToList()[colIndex];
                    }
                }
            }
            return null;
        }

        public override void EscreverValorNaCelula(WorksheetPart worksheetpart, string label, object value, int rowIndex, int colIndex, CellOptions cellOptions)
        {
            var sheetData = InitElementsWithIndex(worksheetpart, rowIndex, colIndex);
            var cell = GetCell(sheetData, rowIndex, colIndex);
            OpenXmlElement dataObject = null;

            if (value != null)
            {
                
                if ((value is int || value is int?) &&
                    (value is short || value is short?) &&
                    (value is long || value is long?) &&
                    (value is float || value is float?) &&
                    (value is double || value is double?) &&
                    (value is decimal || value is decimal?)
                    )
                {
                    cell.DataType = CellValues.Number;
                    NumberItem numberItem = new NumberItem();

                    Text text = new Text();
                    text.Text = value.ToString();
                    numberItem.Append(text);

                    dataObject = numberItem;

                }
                else if (value is DateTime && value is DateTime?)
                {
                    cell.DataType = CellValues.Date;
                    DateTimeItem dateTimeItem = new DateTimeItem();
                    dateTimeItem.Val = new DateTimeValue((DateTime)value);

                    dataObject = dateTimeItem;
                }
                else
                {
                    cell.DataType = CellValues.InlineString;
                    InlineString inlineString = new InlineString();

                    Text text = new Text();
                    text.Text = value.ToString();

                    inlineString.Append(text);
                    dataObject = inlineString;
                }
                cell.Append(dataObject);
            }
            if (cellOptions.Comentario != null)
            {
               
            }

        }

        public override ICollection<WorksheetPart> GetSheets(Workbook workbook)
        {
            if(workbook != null && 
                workbook.WorkbookPart != null && 
                workbook.WorkbookPart.WorksheetParts != null)
            {
                
               return workbook.WorkbookPart.WorksheetParts.ToList();
            }
            return null;
        }

        public override WorksheetPart NewFile(string sheetName = "Planilha 1", string path = null)
        {
            SpreadsheetDocument document = SpreadsheetDocument.Create(path, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook);
            this.app = document;
            WorkbookPart workbookPart = document.AddWorkbookPart();
            this.WorkbookPart = workbookPart;
            Workbook workBook = new Workbook();
            workBook.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");

            Sheets sheets1 = new Sheets();
            Sheet sheet1 = new Sheet() {Name = sheetName, SheetId = 1U, Id = "rId1" };
            sheets1.Append(sheet1);
            workBook.Append(sheets1);

            workbookPart.Workbook = workBook;

            this.WorkBook = workBook;
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>("rId1");
            return worksheetPart;
        }

        public override Workbook OpenFile(string fullFileName)
        {
            throw new NotImplementedException();
        }

        public override void SaveFile(string path)
        {
            if(this.app != null)
            {
                this.app.Save();
            }
        }

        public override void ToDTO<T>(WorksheetPart sheet, ICollection<T> lstDTO, int limitTo = -1)
        {
            throw new NotImplementedException();
        }
    }
}
