using FlightSystemAPI.Models;

namespace Flight_System_API.Repository.DocumentTypeRepository
{
    public interface IDocumentTypeRepository
    {
        List<DocumentType> GetAll();
        public DocumentType GetById(int id);
        public bool CreateDocumentType(DocumentType documentType);

        public bool UpdateDocumentType(DocumentType documentType);
        public bool DeleteDocumentType(int id);

    }
}
