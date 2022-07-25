
using EjemploDetalle2022_02.BLL.Reports;
using EjemploDetalle2022_02.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class RptResult : PdfFooterPart
{
    PdfWriter _PdfWriter;
    int _maxColumn = 4;
    Document _document;
    PdfPTable _pdfPTable = new PdfPTable(8);
    PdfPCell _pdfPCell;
    Font _fontStyle;
    MemoryStream _memotyStream = new MemoryStream();
    Productos _productos = new Productos();

    public byte[] Report(Productos productos)
    {
        _productos = productos;
        _document = new Document(PageSize.A4, 10f, 10f, 20f, 30f);
        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

        _PdfWriter = PdfWriter.GetInstance(_document, _memotyStream);
        _PdfWriter.PageEvent = new PdfFooterPart();

        _document.Open();
        _document.Add(new Phrase(productos.Descripcion + " klk"));
        //this.OnEndPage(_PdfWriter,_document);
        _document.Close();

        return _memotyStream.ToArray();
    }
}