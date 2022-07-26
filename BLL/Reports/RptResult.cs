using EjemploDetalle2022_02.BLL.Reports;
using EjemploDetalle2022_02.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class RptResult : PdfFooterPart
{
    PdfWriter _PdfWriter;
    Document _document;
    Font _fontStyle;
    MemoryStream _memotyStream = new MemoryStream();
    //Productos _productos = new Productos();

    public byte[] Report(List<Productos> productos)
    {
        // _productos = productos;
        _document = new Document(PageSize.A4);
        _fontStyle = FontFactory.GetFont("Tahoma", 16f, 1);

        _PdfWriter = PdfWriter.GetInstance(_document, _memotyStream);
        _PdfWriter.PageEvent = new PdfFooterPart();

        _document.Open();

        Paragraph _titlePricipal = new Paragraph();
        _titlePricipal.Font = _fontStyle;
        _titlePricipal.Alignment = Element.ALIGN_CENTER;
        _titlePricipal.Add("Lista de productos del " + DateTime.Now.ToString("dddd d / MMMM / yyyy"));
        _titlePricipal.SpacingAfter = 10;
        _document.Add(_titlePricipal);

        Font fontTituloTabla = new Font(Font.TIMES_ROMAN, 12, Font.BOLD, BaseColor.Black);
        Font fontItems = new Font(Font.TIMES_ROMAN, 12, Font.NORMAL, BaseColor.Black);

        PdfPTable _tablaProducto = new PdfPTable(5);
        _tablaProducto.WidthPercentage = 100;
        float[] widths = new float[] { 4f, 9f, 3f, 3f, 5f };
        _tablaProducto.SetWidths(widths);

        PdfPCell cellTituloCodigo = new PdfPCell(new Phrase("Producto Id", fontTituloTabla));
        PdfPCell cellTituloDescripcion = new PdfPCell(new Phrase("Descripción", fontTituloTabla));
        PdfPCell cellTituloCosto = new PdfPCell(new Phrase("Costo", fontTituloTabla));
        PdfPCell cellTituloExistencia = new PdfPCell(new Phrase("Existencia", fontTituloTabla));
        PdfPCell cellTituloValorInventario = new PdfPCell(new Phrase("Valor Inventario", fontTituloTabla));

        _tablaProducto.AddCell(cellTituloCodigo);
        _tablaProducto.AddCell(cellTituloDescripcion);
        _tablaProducto.AddCell(cellTituloCosto);
        _tablaProducto.AddCell(cellTituloExistencia);
        _tablaProducto.AddCell(cellTituloValorInventario);

        Double total = 0.0;

        foreach (var _productos in productos)
        {
            PdfPCell cellItemCodigo = new PdfPCell(new Phrase(_productos.ProductoId.ToString(), fontItems));

            PdfPCell cellItemDescripcion = new PdfPCell(new Phrase(_productos.Descripcion, fontItems));

            PdfPCell cellItemCosto = new PdfPCell(new Phrase(_productos.Existencia.ToString("C"), fontItems));

            PdfPCell cellItemExistencia = new PdfPCell(new Phrase(_productos.Costo.ToString(), fontItems));

            PdfPCell cellItemValorInventario = new PdfPCell();

            var valorInventario = (_productos.Existencia * _productos.Costo);
            total += valorInventario;

            cellItemValorInventario = new PdfPCell(new Phrase(valorInventario.ToString("C"), fontItems));

            cellItemExistencia.HorizontalAlignment = 2;
            cellItemCosto.HorizontalAlignment = 2;
            cellItemValorInventario.HorizontalAlignment = 2;

            _tablaProducto.AddCell(cellItemCodigo);
            _tablaProducto.AddCell(cellItemDescripcion);
            _tablaProducto.AddCell(cellItemCosto);
            _tablaProducto.AddCell(cellItemExistencia);
            _tablaProducto.AddCell(cellItemValorInventario);

        }
         _tablaProducto.SpacingAfter = 10;
        _document.Add(_tablaProducto);

        _tablaProducto = new PdfPTable(2);
        _tablaProducto.WidthPercentage = 50;
        _tablaProducto.HorizontalAlignment = 2;
        PdfPCell celltotalProducto = new PdfPCell(new Phrase("Total Producto", fontTituloTabla));
        PdfPCell celltotalProductotexto = new PdfPCell(new Phrase(productos.Count.ToString(), fontTituloTabla));
        celltotalProductotexto.HorizontalAlignment = 2;
        _tablaProducto.AddCell(celltotalProducto);
        _tablaProducto.AddCell(celltotalProductotexto);

        _document.Add(_tablaProducto);

        _tablaProducto = new PdfPTable(2);
        _tablaProducto.WidthPercentage = 50;
        _tablaProducto.HorizontalAlignment = 2;
       
        celltotalProducto = new PdfPCell(new Phrase("Total Valor Inventario", fontTituloTabla));
        celltotalProductotexto = new PdfPCell(new Phrase(total.ToString("C"), fontTituloTabla));
        celltotalProductotexto.HorizontalAlignment = 2;
        _tablaProducto.AddCell(celltotalProducto);
        _tablaProducto.AddCell(celltotalProductotexto);

        _document.Add(_tablaProducto);

        this.OnEndPage(_PdfWriter, _document);
        _document.Close();

        return _memotyStream.ToArray();
    }
}