using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using gymwebproject.Models;
using gymwebproject.Repositorio;
namespace gymwebproject.Controllers
{
    public class PDFController : Controller
    {

        private readonly Irepositoriopdf repositoriopdf;

        public PDFController(Irepositoriopdf irepositoriopdf)
        { 
            this.repositoriopdf= irepositoriopdf;
        
        
        }


        public IActionResult pdfInventario()
        {
            // Generar el PDF
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Título del documento
            document.Add(new Paragraph("Listado de Usuarios")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            // Tabla con encabezados
            Table table = new Table(6, true); // 6 columnas

            table.AddHeaderCell("Nombre");
            table.AddHeaderCell("Correo");
            table.AddHeaderCell("Apellido");
            table.AddHeaderCell("Sexo");
            table.AddHeaderCell("Rol");
            table.AddHeaderCell("contraseña");

            // Llenar la tabla con datos
            RegistrarseModel pdfinventario = new RegistrarseModel();
            var inventario = repositoriopdf.Invetariopdf(pdfinventario);

            foreach (var item in inventario)
            {
                table.AddCell(item.nombre);
                table.AddCell(item.correo);
                table.AddCell(item.apellido);
                table.AddCell(item.Tiposexo.ToString());
                table.AddCell(item.rol.ToString()); // formato moneda
                table.AddCell(item.contraseña);

            }

            // Agregar tabla al documento y cerrar
            document.Add(table);
            document.Close();

            // Devolver el archivo como PDF
            byte[] pdfBytes = stream.ToArray();
            Response.Headers.Add("Content-Disposition", "inline; filename=ListadoInventario.pdf");
            return File(pdfBytes, "application/pdf");
        }


        public IActionResult pdfsuscripciones()
        {
            // Generar el PDF
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Título del documento
            document.Add(new Paragraph("Listado de Suscripciones")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            // Tabla con encabezados
            Table table = new Table(6, true); // 6 columnas

            table.AddHeaderCell("Oro");
            table.AddHeaderCell("Plata");
            table.AddHeaderCell("Bronce");
            

            // Llenar la tabla con datos
            gestionmodel pdfsuscripciones = new gestionmodel();
            var suscripciones = repositoriopdf.suscripcionespdf(pdfsuscripciones);

            foreach (var item in suscripciones)
            {
                table.AddCell(item.oro.ToString());
                table.AddCell(item.plata.ToString());
                table.AddCell(item.bronce.ToString());

            }

            // Agregar tabla al documento y cerrar
            document.Add(table);
            document.Close();

            // Devolver el archivo como PDF
            byte[] pdfBytes = stream.ToArray();
            Response.Headers.Add("Content-Disposition", "inline; filename=ListadoSuscripciones.pdf");
            return File(pdfBytes, "application/pdf");
        }


        public IActionResult pdfregistroC()
        {
            // Generar el PDF
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Título del documento
            document.Add(new Paragraph("Listado de Compras")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            // Tabla con 7 columnas (ya sin el 'true')
            Table table = new Table(7);

            // Encabezados
            table.AddHeaderCell("Nombre");
            table.AddHeaderCell("Correo");
            table.AddHeaderCell("Suscripción");
            table.AddHeaderCell("Precio");
            table.AddHeaderCell("Número");
            table.AddHeaderCell("Tarjeta");
            table.AddHeaderCell("Método");

            // Obtener datos
            compraPmodel pagopdf = new compraPmodel();
            var pago = repositoriopdf.registroC(pagopdf);

            // Agregar filas
            foreach (var item in pago)
            {
                table.AddCell(item.nombre ?? "N/A");
                table.AddCell(item.correo ?? "N/A");
                table.AddCell(item.suscripcion ?? "N/A");
                table.AddCell(item.precio.ToString());
                table.AddCell(item.numero.ToString());
                table.AddCell(item.tarjeta?.ToString() ?? "N/A");
                table.AddCell(item.metodo ?? "N/A");
            }

            // Agregar tabla al documento
            document.Add(table);
            document.Close();

            // Devolver el archivo como PDF
            byte[] pdfBytes = stream.ToArray();
            Response.Headers.Add("Content-Disposition", "inline; filename=ListadoCompra.pdf");
            return File(pdfBytes, "application/pdf");
        }




        // GET: PDFController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PDFController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PDFController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PDFController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PDFController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PDFController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PDFController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PDFController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
