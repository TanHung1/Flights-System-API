using FlightSystemAPI.Models;

namespace Flight_System_API.Repository.DocumentTypeRepository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private FlightContext _context;




        public DocumentTypeRepository(FlightContext context)
        {
            _context = context;

        }
        public bool CreateDocumentType(DocumentType documentType)
        {


            _context.DocumentTypes.Add(documentType);

            _context.SaveChanges();
            return true;
        }

        public bool DeleteDocumentType(int id)
        {
            DocumentType document = _context.DocumentTypes.FirstOrDefault(x => x.DocumentTypeId == id);
            _context.DocumentTypes.Remove(document);
            _context.SaveChanges();
            return true;
        }

        public List<DocumentType> GetAll()
        {
            return _context.DocumentTypes.ToList();
        }

        public DocumentType GetById(int id)
        {
            DocumentType document = _context.DocumentTypes.FirstOrDefault(x => x.DocumentTypeId == id);
            return document;
        }

        public bool UpdateDocumentType(DocumentType documentType)
        {
            DocumentType document = _context.DocumentTypes.FirstOrDefault(x => x.DocumentTypeId == documentType.DocumentTypeId);
            if (document != null)
            {
                _context.Entry(document).CurrentValues.SetValues(documentType);
                _context.SaveChanges();
            }
            return true;
        }


    }
}
