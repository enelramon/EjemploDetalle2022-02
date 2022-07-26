
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
    //Productos _productos = new Productos();

    public byte[] Report(List<Productos> productos)
    {
       // _productos = productos;
        _document = new Document(PageSize.A4, 10f, 10f, 20f, 30f);
        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

        _PdfWriter = PdfWriter.GetInstance(_document, _memotyStream);
        _PdfWriter.PageEvent = new PdfFooterPart();

        _document.Open();

        Paragraph titlePricipal = new Paragraph();
        titlePricipal.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14f);
        titlePricipal.Alignment = Element.ALIGN_CENTER;
        titlePricipal.Add("Lista De Productos");
        titlePricipal.SpacingAfter = 5;
        _document.Add(titlePricipal);

        Font fontHeader = new Font(Font.TIMES_ROMAN, 12, Font.BOLD, BaseColor.Black);
        Font fontNormal = new Font(Font.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.Black);

        //tabla detalle monto mensual
        PdfPTable tblLocal = new PdfPTable(4);
        tblLocal.WidthPercentage = 100;
        float[] widths = new float[] { 12f, 5f, 3f, 4f };
        tblLocal.SetWidths(widths);

        PdfPCell clID = new PdfPCell(new Phrase("ID", fontHeader));
        PdfPCell clDescripcion = new PdfPCell(new Phrase("Descripcion", fontHeader));
        PdfPCell clExistencia = new PdfPCell(new Phrase("Existencia", fontHeader));
        PdfPCell clCosto = new PdfPCell(new Phrase("Costo", fontHeader));
        PdfPCell clInventario = new PdfPCell(new Phrase("Valor Inventario", fontHeader));
        
        tblLocal.AddCell(clID);
        tblLocal.AddCell(clDescripcion);
        tblLocal.AddCell(clExistencia);
        tblLocal.AddCell(clCosto);
        tblLocal.AddCell(clInventario);

        PdfPCell celda = new PdfPCell();
        foreach (var _productos in productos)
        {
            celda = new PdfPCell(new Phrase(_productos.ProductoId.ToString(), fontNormal));
            tblLocal.AddCell(celda);
            celda = new PdfPCell(new Phrase(_productos.Descripcion, fontNormal));
            tblLocal.AddCell(celda);
            celda = new PdfPCell(new Phrase(_productos.Existencia.ToString("C"), fontNormal));
            tblLocal.AddCell(celda);
            celda = new PdfPCell(new Phrase(_productos.Costo.ToString("C"), fontNormal));
            tblLocal.AddCell(celda);
            celda = new PdfPCell(new Phrase((_productos.Costo*_productos.Existencia).ToString("C"), fontNormal));
            tblLocal.AddCell(celda);
        }

        _document.Add(tblLocal);

        this.OnEndPage(_PdfWriter, _document);
        _document.Close();

        return _memotyStream.ToArray();
    }
}